using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class StartMenu
    {
        public static async Task Execute()
        {

            Console.Clear();
            bool exit = false;

            while (!exit)
            {
                // Tworzenie prompta z opcjami menu

                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Wybierz opcję:[/]")
                        .PageSize(10)
                        .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                        .AddChoices(new[] {
                        "Log IN", "Sign IN", "Exit"
                        })
                        .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

                // Obsługa wsybranej opcji
                switch (option)
                {
                    case "Log IN":
                        exit = true;
                        await LogIN();
                        break;
                    case "Sign IN":
                        await SignIN();
                        AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 2![/]");
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[red]Koniec programu.[/]");
                        exit = true;
                        break;
                }


            }
        }
    }
}
