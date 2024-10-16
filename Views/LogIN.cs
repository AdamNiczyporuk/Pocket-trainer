using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class LogIN
    {
        public static async Task Execute()
        {
            while (true)
            {
                // Wyświetlenie opcji logowania
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
                    break; // Wyjście z pętli i zakończenie aplikacji
                }

                // Symulacja walidacji logowania (możesz zastąpić to własną logiką)
                if (ValidateLogin(username, password))
                {
                    await Panel.Execute();
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
                }
            }
        }

        // Metoda symulująca walidację logowania
        private static bool ValidateLogin(string username, string password)
        {
            // Przykładowa walidacja - zastąp to własną logiką
            return username == "admin" && password == "admin";
        }
    }
}
