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
        private static async Task GenerateDiet(DietRepository dietRepository)
        {
            Console.Clear();
            ChatGPT_diet.SetUpSetting();
            string prompt = ($"My weigh={Program.user.Weight},Height={Program.user.Height},TrainingsPerWeek={Program.user.TrainingsPerWeek}.Write me a diet plan for 7 seven days.");

            var responseTask = ChatGPT_diet.SendRequestToChatGPT(prompt);

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
            }
            else if (option == "Generate Again")
            {
                GenerateDiet(dietRepository);
            }
            else if (option == "Exit")
            {
                AnsiConsole.MarkupLine("[red]Exiting without saving the diet plan...[/]");
            }
        }

        public static async Task Execute()
        {

            using (var context = new ApplicationDbContext())
            {
                var dietRepository = new DietRepository(context);
                var existingDiet = dietRepository.GetUserDiets(Program.user.Id);

                bool exit = false;

                while (!exit)
                {
                    if (existingDiet.Any())
                    {
                        AnsiConsole.MarkupLine("[turquoise2]You have already have diet plans:[/]");
                        AnsiConsole.MarkupLine(existingDiet[0].Text);

                        var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[Green]Chose an option[/]")
                            .AddChoices(new[] { "Generate Again", "Exit" })
                            .HighlightStyle(new Style(foreground: Color.Aqua)));

                        if (option == "Generate Again")
                        {
                            await GenerateDiet(dietRepository);
                            exit = true;
                        }
                        else if (option == "Exit")
                        {
                            AnsiConsole.MarkupLine("[red]Exiting without saving the diet plan...[/]");
                            exit = true;
                        }
                    }
                    else
                    {
                        GenerateDiet(dietRepository);
                    }
                }
            }


        }
    }
}
