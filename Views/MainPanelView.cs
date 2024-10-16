using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class MainPanelView
{
        public static string GetOption()
        {
            var option = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("[yellow]Wybierz opcję:[/]")
                       .PageSize(10)
                       .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                       .AddChoices(new[] {
                        "Add Training", "See Data", "Write Diet","Settings" ,"Exit"
                       })
                       .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
}
}
