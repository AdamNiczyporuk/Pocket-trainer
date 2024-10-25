using KCK_Project__Console_Pocket_trainer_.Views;
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
                MainPanelView.PocketTrainerWriting();
                MainPanelView.LineBettwenScetion();
                AnsiConsole.WriteLine();
                MainPanelView.Greet(Program.user.UserName);
                var option = Views.MainPanelView.GetOption();
                // Obsługa wsybranej opcji
                switch (option)
                {
                    case "Trainings":
                        var trainingController = new TrainingController();
                        await trainingController.Run();
                        break;
                    case "See Data":
                        AnsiConsole.MarkupLine("[green]See Data![/]");
                        break;
                    case "Diet":
                        var DietView = new DietViewController();
                        await DietViewController.Execute();
                        break;
                    case "Settings":
                        var settingsController = new SettingsController();
                        await settingsController.Run();
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
