using CHATAPI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_Project__Console_Pocket_trainer_.Views;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using Microsoft.EntityFrameworkCore;
using KCK_Project__Console_Pocket_trainer_.Data;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class DietView
    {
        public static async Task Execute()
        {
            using (var context = new ApplicationDbContext())
            {
                var dietRepository = new DietRepository(context);
                var exisitingDiet = dietRepository.GetUserDiets(Program.user.Id);
                if(exisitingDiet.Any())
                {
                    AnsiConsole.MarkupLine("[turquoise2]You have already have diet plans:[/]");
                    AnsiConsole.MarkupLine(exisitingDiet[0].Text);
                    Console.ReadKey();
                }
                else
                {

                    while (true)
                    {
                        ChatGPT_diet.SetUpSetting();
                        string Prompt = ($"My weigh={Program.user.Weight},Height={Program.user.Height},TrainingsPerWeek={Program.user.TrainingsPerWeek}.Write me a diet plan for 7 seven days.");

                        var responseTask = ChatGPT_diet.SendRequestToChatGPT(Prompt);

                        Console.CursorVisible = false;
                        AnsiConsole.MarkupLine("[bold green]Generating Diet....[/]");

                        var response = await responseTask;

                        Console.CursorVisible = true;
                        AnsiConsole.Clear();
                        AnsiConsole.MarkupLine("[bold green]Diet Plan:[/]");
                        AnsiConsole.MarkupLine(response);

                        var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[Green]Chose an option[/]")
                            .AddChoices(new[] { "Save Diet", "Generate Again", "Exit" })
                            .HighlightStyle(new Style(foreground: Color.Aqua)));
                        if (option == "Save Diet")
                        {
                            Diet diet = new Diet()
                            {
                                Text = response,
                                UserId = Program.user.Id,

                            };

                            dietRepository.Add(diet);
                            AnsiConsole.MarkupLine("[bold green]Diet saved successfully![/]");
                            break;
                        }
                        else if (option == "Generate Again")
                        {
                            continue;
                        }
                        else if (option == "Exit")
                        {
                            AnsiConsole.MarkupLine("[red]Exiting without saving the diet plan...[/]");
                            break;
                        }


                    }
                }
               


            }

        }
    }
}
