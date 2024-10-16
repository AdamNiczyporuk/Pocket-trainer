using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class Panel
    {
        public static async Task Execute()
        {
            bool exit = false;
            Console.Clear();
            while (!exit)
            {
                // Tworzenie prompta z opcjami menu

                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Wybierz opcję:[/]")
                        .PageSize(10)
                        .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                        .AddChoices(new[] {
                        "Add Training", "See Data", "Write Diet","Settings" ,"Exit"
                        })
                        .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

                // Obsługa wsybranej opcji
                switch (option)
                {
                    case "Add Training":
                        AnsiConsole.MarkupLine("[green]Add Training![/]");
                        break;
                    case "See Data":
                        AnsiConsole.MarkupLine("[green]See Data![/]");
                        break;
                    case "Write Diet":
                        await Diet.Execute();
                        break;
                    case "Settings":
                        AnsiConsole.MarkupLine("[green]Settings![/]");
                        break;
                    case "Exit":
                        AnsiConsole.MarkupLine("[red]Program End.[/]");
                        exit = true;
                        await StartMenu.Execute();
                        break;
                }


            }
        }
    }
}
