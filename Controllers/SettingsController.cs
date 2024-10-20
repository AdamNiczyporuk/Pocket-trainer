using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Views;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class SettingsController
{
        public SettingsController()
        {

        }
        public async Task Run()
        {
           
            if (Program.user.Weight == null && Program.user.Height == null && Program.user.TrainingsPerWeek == null)
            {
                var exit = false;
                while (!exit)
                {
                    Console.Clear();
                    SettingsView.ShowUserSettings(Program.user);
                    var option = Views.SettingsView.AddDataView();
                    // Obsługa wsybranej opcji
                    switch (option)
                    {
                        case "Add Account Data":
                          
                            break;
                        case "Exit":
                            exit = true;
                            break;
                    }
                }
            }
            
        }
        public async Task AddingData()
        {
            Console.Clear();
            using (var context = new ApplicationDbContext())
            {
                var userRepository = new UserRepository(context);
                while (true)
                {
                    Console.Clear();
                    var username = StartMenuView.GetUsername();
                    var password = StartMenuView.GetPassword();

                    var existingUser = userRepository.GetUserByUserName(username);
                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    {
                        StartMenuView.ShowMessage("[red]Invalid username or password![/]");
                        MainPanelView.Wait();

                    }
                    if (existingUser != null)
                    {
                        if (existingUser.Password == password)
                        {
                            StartMenuView.ShowMessage("[green]Login sucess![/]");
                            Program.user = existingUser;
                            MainPanelView.Wait();
                            break;
                        }
                        else
                        {
                            StartMenuView.ShowMessage("[red]Invalid username or password![/]");
                            MainPanelView.Wait();
                        }
                    }
                    else
                    {
                        StartMenuView.ShowMessage("[red]User does not exist![/]");
                        MainPanelView.Wait();
                    }
                    var option = StartMenuView.DoYouWantToTryAgain();
                    if (option == "No")
                    {
                        StartMenuView.ShowMessage("[red]Returning to Start Menu...[/]");
                        MainPanelView.Wait();
                        return;
                    }

                }
            }

        }
    }
}
