using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console.Views
{
    public class SignIN
    {
        public static async Task Execute()
        {
            while (true)
            {
                var mail = AnsiConsole.Ask<string>("Enter your [yellow]E-mail[/]:");
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
                    if (mail == "" || username == "" || password == "")
                    {
                        AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
                        SignIN();
                    }
                    else if (mail.Contains("@") == false)
                    {
                        AnsiConsole.MarkupLine("[red]Invalid email![/]");
                        SignIN();
                    }
                    else
                    {
                        // Check if the user already exists
                        // Seraching user thorugh Mail a
                        //Validate password and Username
                        // Add the user to the database
                        // AddUserToDatabase(mail, username, password);
                        AnsiConsole.MarkupLine("[green]User added successfully![/]");
                        await Program.Panel();
                    }

                }

            }
        }
    }
}
