using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class DietView1
    {
        public static string GetOptionDietNotExist()
        {
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[Green]Chose an option[/]")
                .AddChoices(new[] { "Save Diet", "Generate Again", "Exit" })
                .HighlightStyle(new Style(foreground: Color.Aqua)));
            return option;
        }

        public static string GetOptionDietExist()
        {
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[Green]Chose an option[/]")
                            .AddChoices(new[] { "Generate Again", "Exit" })
                            .HighlightStyle(new Style(foreground: Color.Aqua)));
            return option;
        }

    }
}
