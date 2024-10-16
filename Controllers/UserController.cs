using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class UserController
    {
        public UserController()
        {
        }
        public async Task Run()
        {
            var option = StartMenuView.GetOption();
            switch (option)
            {
                case "Login":
                    await Login();
                    break;
                case "Sign in":
                    await SignIn();
                    break;
                case "Exit":
                    StartMenuView.ShowMessage("[red]Exiting the application...[/]");
                    Environment.Exit(0);
                    break;
            }
        }
        public async Task Login()
        {
            Console.Clear();
            using (var context = new ApplicationDbContext())
            {
                var userRepository = new UserRepository(context);
                while (true)
                {
                    var username = StartMenuView.GetUsername();
                    var password = StartMenuView.GetPassword();

                    var existingUser = userRepository.GetUserByUserName(username);
                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    {
                        StartMenuView.ShowMessage("[red]Invalid username or password![/]");
                        Console.ReadKey();

                    }
                    if (existingUser != null)
                    {
                        if (existingUser.Password == password)
                        {
                            StartMenuView.ShowMessage("[green]Login sucess![/]");
                            Program.user = existingUser;
                            break;
                        }
                        else
                        {
                            StartMenuView.ShowMessage("[red]Invalid username or password![/]");

                        }
                    }
                    else
                    {
                        StartMenuView.ShowMessage("[red]User does not exist![/]");

                    }
                    var option = StartMenuView.DoYouWantToTryAgain();
                    if (option == "No(Exit)")
                    {
                        StartMenuView.ShowMessage("[red]Exiting the application...[/]");
                        Environment.Exit(0);
                    }

                }
            }

        }
        public async Task SignIn()
        {
        }
    }
}

