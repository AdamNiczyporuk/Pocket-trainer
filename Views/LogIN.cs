using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class LogIN
    {
        public static async Task Execute()
        {

            var context = new ApplicationDbContext();
            var userRepository = new UserRepository(context);
            while (true)
            {
                // Wyświetlenie opcji logowania
                AnsiConsole.MarkupLine("To Log IN Enter username and password");
                var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
                var password = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter your [yellow]Password[/]:")
                        .PromptStyle("red")
                        .Secret());

                // Wyświetlenie opcji wyboru
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Choose an option:[/]")
                        .AddChoices(new[] { "Login", "Exit" })
                        .HighlightStyle(new Style(foreground: Color.Aqua)));

                if (option == "Exit")
                {
                    AnsiConsole.MarkupLine("[red]Exiting the application...[/]");
                    await StartMenu.Execute();
                    break; // Wyjście z pętli i zakończenie aplikacji
                }
                if (option == "Login")
                {
                    var existingUser = userRepository.GetUserByUserName(username);
                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    {
                        AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
                        await LogIN.Execute();
                    }
                    if (existingUser != null)
                    {
                        if (existingUser.Password == password)
                        {
                            await Panel.Execute();
                            break;
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]Invalid password!Try Again!![/]");
                            await LogIN.Execute();
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]User does not exist![/]");
                        await SignIN.Execute();
                    }


                }
            }



        }
    }
}

