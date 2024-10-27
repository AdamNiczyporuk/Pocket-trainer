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
using Azure;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;


namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class DietViewController
    {
        public DietViewController()
        {

        }
        private static async Task DisplayTextSlowly(string text, int delay = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                await Task.Delay(delay);
            }
            Console.WriteLine();
        }
        private static async Task<String> GenerateDiet(DietRepository dietRepository)
        {
            AnsiConsole.Clear();
            ChatGPT_diet.SetUpSetting();
            string prompt = ($"My weigh={Program.user.Weight},Height={Program.user.Height},TrainingsPerWeek={Program.user.TrainingsPerWeek}.Write me a diet plan for 7 seven days.");

            var responseTask = ChatGPT_diet.SendRequestToChatGPT(prompt);

            //Console.CursorVisible = false;
            //AnsiConsole.MarkupLine("[bold green]Generating Diet....[/]");
            await AnsiConsole.Progress()
            .AutoClear(false)
            .StartAsync(async context =>
            {
                var progressTask = context.AddTask("[green]Generating Diet...[/]");

                while (!responseTask.IsCompleted)
                {
                    // Simuluj progres (np. zwiększaj o losowy procent w przedziale)
                    progressTask.Increment(1.0);

                    // Krótkie opóźnienie, aby symulować postęp ładowania
                    await Task.Delay(100);
                }
                if(responseTask.IsCompleted)
                {
                    progressTask.Value = 100;
                    await Task.Delay(500);
                }
                // Ustaw pasek na pełny postęp po zakończeniu responseTask
                
               
            });

            var response = await responseTask;
            AnsiConsole.Clear(); 
            //Console.CursorVisible = true;
            //AnsiConsole.Clear();
            //AnsiConsole.MarkupLine("[bold green]Diet Plan:[/]");
            //AnsiConsole.MarkupLine(response);

            //var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[Green]Chose an option[/]")
            //    .AddChoices(new[] { "Save Diet", "Generate Again", "Exit" })
            //    .HighlightStyle(new Style(foreground: Color.Aqua)));
            return response;
        }
        public static async Task Execute()
        {
            if (Program.user == null)
            {
                var userController = new UserController();
                await userController.Run();
            }
            if (Program.user.Weight == null || Program.user.Height == null || Program.user.TrainingsPerWeek == null)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[red]You need to fill in your data first!\n Click any key to go back[/]");
                Console.ReadKey();
                return;
            }
            using (var context = new ApplicationDbContext())
            {   
                
                var dietRepository = new DietRepository(context);
                var existingDiet = dietRepository.GetUserDiets(Program.user.Id);

                bool exit = false;

                while (!exit)
                { //There is a need to Add checker if user has data to generate diet
                    if (existingDiet.Any())
                    {
                        AnsiConsole.Clear();
                        DietView.DietWriting();
                        DietView.LineBettwenScetion();
                        AnsiConsole.MarkupLine("[turquoise2]You have already have diet plans:[/]");
                        AnsiConsole.MarkupLine(existingDiet[0].Text);

                        var option = Views.DietView.GetOptionDietExist();

                        //var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[Green]Chose an option[/]")
                        //    .AddChoices(new[] { "Generate Again", "Exit" })
                        //    .HighlightStyle(new Style(foreground: Color.Aqua)));

                        if (option == "Generate Again")
                        {
                            AnsiConsole.Clear();
                            DietView.DietWriting();
                            DietView.LineBettwenScetion();
                            string newDiet = await GenerateDiet(dietRepository);
                            await DisplayTextSlowly(newDiet, 5);
                            Console.WriteLine();
                            AnsiConsole.Clear();
                            AnsiConsole.MarkupLine("[bold green]Diet Plan Generated:[/]");
                            AnsiConsole.MarkupLine(newDiet);

                            var  answer = DietView.SaveDietOrNO();

                            if (answer == "Yes")
                            {
                                
                                existingDiet[0].Text = newDiet;
                                dietRepository.Update(existingDiet[0]);
                                AnsiConsole.MarkupLine("[bold green]New diet saved successfully![/]");
                            }
                        }
                        else if (option == "Exit")
                        {
                            AnsiConsole.MarkupLine("[red]Exiting without saving the diet plan...[/]");
                            exit = true;
                        }
                    }
                    else
                    {
                        AnsiConsole.Clear();
                        DietView.DietWriting();
                        DietView.LineBettwenScetion();
                        var response = await GenerateDiet(dietRepository);
                        AnsiConsole.MarkupLine(response);
                        var option = Views.DietView.GetOptionDietNotExist();
                        if (option == "Save Diet")
                        {
                            Diet diet = new Diet()
                            {
                                Text = response,
                                UserId = Program.user.Id,
                            };

                            dietRepository.Add(diet);
                            AnsiConsole.MarkupLine("[bold green]Diet saved successfully!\n Click Any key to exit[/]");
                            Console.ReadKey();  
                            exit = true;
                        }
                        else if (option == "Generate Again")
                        {
                            
                        }
                        else if (option == "Exit")
                        {
                            AnsiConsole.MarkupLine("[red]Exiting without saving the diet plan...[/]");
                            exit = true;
                        }

                    }
                }
            }


        }
    }
}
