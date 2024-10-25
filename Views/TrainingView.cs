using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class TrainingView
{
    public static string GetOption()
    {
        var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Choose option:[/]")
                    .PageSize(10)
                    .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                    .AddChoices(new[] {
                        "Do training", "Training Plans","Track your progress","See exercises", "Back"
                    })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
        return option;
    }
}
}
