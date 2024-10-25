using Azure;
using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Views;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Models;

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
            else
            {
                var exit = false;
                while (!exit)
                {
                    Console.Clear();
                    SettingsView.ShowUserSettings(Program.user);
                    var option = Views.SettingsView.UpdateDataView();
                    // Obsługa wsybranej opcji
                    switch (option)
                    {
                        case "Update Account Data":

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
                       
                        float  Weight = StartMenuView.GetUsername();
                        float Height = StartMenuView.GetPassword();
                        int WeeklyTrainings = StartMenuView.GetPassword();
                        User user = new User()
                        {
                           UserName = Program.user.UserName,
                           Password = Program.user.Password,
                           Weight = Weight,
                        };
                    userRepository.Update(Program.user);


                    

                }
            }

        }
    }
}
