using KCK_Project__Console_Pocket_trainer_.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class SettingsView
    {

        public static string UpdateDataView()
        {
            var option = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                      .Title("[yellow]Choose option:[/]")
                      .PageSize(10)
                      .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                      .AddChoices(new[] {
                        "Update Account Data" ,"Exit"
                      })
                      .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
        public static string AddDataView()
        {
            var option = AnsiConsole.Prompt(
                              new SelectionPrompt<string>()
                                  .Title("[yellow]Choose option:[/]")
                                  .PageSize(10)
                                  .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                                  .AddChoices(new[] {
                        "Add Account Data" ,"Exit"
                                  })
                                  .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
        public static float GetHeight()
        {
            float height;
            while (true)
            {
                var input = AnsiConsole.Ask<string>("Enter your [yellow]Height[/]:");

                // Sprawdzamy, czy wejście jest liczbą i ma 3 cyfry
                if (float.TryParse(input, out height) && input.Length == 3 && height < 300.00)
                {
                    return height;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Please enter a valid height [/]");
                }
            }
        }
        public static float GetWeight()
        {
            float weight;
            while (true)
            {
                var input = AnsiConsole.Ask<string>("Enter your [yellow]Weight[/]:");

                // Sprawdzamy, czy wejście jest liczbą i ma 2 cyfry
                if (float.TryParse(input, out weight) && input.Length == 2 && weight< 400)
                {
                    return weight;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Please enter a valid Weight.[/]");
                }
            }

        } public static int GetTrainings()
        {
            int trainings;
            while (true)
            {
                var input = AnsiConsole.Ask<string>("Enter your [yellow]Traings Per Week[/]:");

                // Sprawdzamy, czy wejście jest liczbą i ma 3 cyfry
                if (int.TryParse(input, out trainings) && input.Length == 1)
                {
                    return trainings;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Please enter a valid Traings Per Week.[/]");
                }
            }
        }
        public static void ShowUserSettings(User user)
        {

            var table = new Table();
            table.AddColumn("[green]Property[/]");
            table.AddColumn("[blue]Value[/]");
            table.AddRow("Username", user.UserName);
            string password = "";
            for (int i = 0; i < user.Password.Length; i++)
            {
                password += "*";
            }
            table.AddRow("Password", $"[red]{password}[/]");
            table.AddRow("Weight", user.Weight.HasValue ? user.Weight.ToString() : "unprovided");
            table.AddRow("Height", user.Height.HasValue ? user.Height.ToString() : "unprovided");
            table.AddRow("Weekly trainings", user.TrainingsPerWeek.HasValue ? user.TrainingsPerWeek.ToString() : "unprovided");
            table.Border = TableBorder.Rounded;
            table.Collapse();
            table.Centered();
            table.Columns[0].LeftAligned().Width(30);
            table.Columns[1].Centered();
            AnsiConsole.Render(table);
        }
    }
}
