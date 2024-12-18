﻿    using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
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
    public class UserController
    {
        public UserController()
        {
        }
        public async Task Run()
        {
            while (Program.user == null)
            {
                Console.Clear();
                //StartMenuView.Greet();
                StartMenuView.PocketTrainerWriting();
                StartMenuView.LineBettwenScetion();
                AnsiConsole.WriteLine();
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
        }
        public async Task Login()
        {
            Console.Clear();
           
            using (var context = new ApplicationDbContext())
            {
                var userRepository = new UserRepository(context);
                while (true)
                {
                    Console.Clear();
                    StartMenuView.PocketTrainerWriting();
                    StartMenuView.LineBettwenScetion();
                    AnsiConsole.WriteLine();
                    StartMenuView.Logging();
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
                            Console.WriteLine();
                            StartMenuView.ShowMessage("[green]Login sucess![/]");
                            Program.user = existingUser;
                            MainPanelView.Wait();
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            StartMenuView.ShowMessage("[red]Invalid username or password![/]");
                            MainPanelView.Wait();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        StartMenuView.ShowMessage("[red]User does not exist![/]");
                        MainPanelView.Wait();
                    }
                    var option = StartMenuView.DoYouWantToTryAgain();
                    if (option == "No")
                    {
                        Console.WriteLine();
                        StartMenuView.ShowMessage("[red]Returning to Start Menu...[/]");
                        MainPanelView.Wait();
                        return;
                    }

                }
            }

        }
        public async Task SignIn()
        {
            AnsiConsole.Clear();
           
            using (var context = new ApplicationDbContext())
            {
                var userRepository = new UserRepository(context);
                while (true)
                {
                    AnsiConsole.Clear();
                    StartMenuView.PocketTrainerWriting();
                    StartMenuView.LineBettwenScetion();
                    AnsiConsole.WriteLine();

                    StartMenuView.Singin();
                    var username = StartMenuView.GetUsername();
                    var password = StartMenuView.GetPassword();

                    var existingUser = userRepository.GetUserByUserName(username);
                    if (existingUser != null)
                    {
                        Console.WriteLine();
                        StartMenuView.ShowMessage("[red]User already exists if it's you please login\nor try other username.[/]");

                    }
                    else
                    {
                        User user = new User()
                        {
                            UserName = username,
                            Password = password
                        };
                        userRepository.Add(user);
                        Program.user = user;
                        Console.WriteLine();
                        StartMenuView.ShowMessage("[green]User added successfully![/]");
                        MainPanelView.Wait();
                        return;

                    }
                    var option = StartMenuView.DoYouWantToTryAgain();
                    if (option == "No")
                    {
                        Console.WriteLine();
                        StartMenuView.ShowMessage("[red]Returning to Start Menu...[/]");
                        MainPanelView.Wait();
                        return;
                    }
                }
            }
        }
    }

}

