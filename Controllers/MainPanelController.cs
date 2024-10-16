﻿using KCK_Project__Console_Pocket_trainer_.Views;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class MainPanelController
{
        public MainPanelController()
        {

        }
        public async Task Run()
        {
            if(Program.user == null)
            {
               var userController = new UserController();
               await userController.Run();
            }
            var exit= false;
            while (!exit)
            {
                Console.Clear();
                var option = Views.MainPanelView.GetOption();
                // Obsługa wsybranej opcji
                switch (option)
                {
                    case "Add Training":
                        AnsiConsole.MarkupLine("[green]Add Training![/]");
                        break;
                    case "See Data":
                        AnsiConsole.MarkupLine("[green]See Data![/]");
                        break;
                    case "Write Diet":
                        await Diet.Execute();
                        break;
                    case "Settings":
                        AnsiConsole.MarkupLine("[green]Settings![/]");
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[red]Program End.[/]");
                        MainPanelView.Wait();
                        exit = true;
                        break;
                }
            }

        }
    }
}