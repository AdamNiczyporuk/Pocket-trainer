using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_Project__Console_Pocket_trainer_.Views;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Repositories;


namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class SignIN
    {
        public static async Task Execute()
        {
            var context = new ApplicationDbContext();
            var userRepository = new UserRepository(context);
            while (true)
            {
                var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
                var password = AnsiConsole.Prompt(
                               new TextPrompt<string>("Enter your [yellow]Password[/]:")
                                              .PromptStyle("red")
                                                             .Secret());  // Mask the input for password

                // Wyświetlenie opcji wyboru
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Choose an option:[/]")
                        .AddChoices(new[] { "SignIN", "Exit" })
                        .HighlightStyle(new Style(foreground: Color.Aqua)));

                if (option == "Exit")
                {
                    AnsiConsole.MarkupLine("[red]Exiting the application...[/]");
                    break; // Wyjście z pętli i zakończenie aplikacji
                }
                if (option == "SignIN")
                {
                    var existingUser = userRepository.GetUserByUserName(username);
                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    {
                        AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
                        await SignIN.Execute();
                    }
                    else if(existingUser != null)
                    {
                        AnsiConsole.MarkupLine("[red]User already exists!LogIN!!!![/]");
                        await LogIN.Execute();
                        break;
                    }
                    else if (existingUser != null)
                    {
                        // Check if the user already exists
                        // Seraching user thorugh Mail a
                        //Validate password and Username
                        // Add the user to the database
                        // AddUserToDatabase(mail, username, password);
                        AnsiConsole.MarkupLine("[red]User already exists![/]");
                        await SignIN.Execute();
                    }
                    else
                    {
                        var newUser = new User
                        {
                            UserName = username,
                            Password = password
                        };
                        userRepository.Add(newUser);
                        await Panel.Execute();
                        break;


                    }

                }

            }
        }
    }
}
