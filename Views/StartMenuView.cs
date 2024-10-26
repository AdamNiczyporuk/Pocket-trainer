using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class StartMenuView
    {
        public static string GetOption()
        {
            var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Choose option:[/]")
                        .PageSize(10)
                        .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                        .AddChoices(new[] {
                        "Login", "Sign in", "Exit"
                        })
                        .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
        public static void ShowMessage(string message)
        {
            AnsiConsole.MarkupLine(message);
        }
        public static string GetUsername()
        {
            var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
            return username;
        }
        public static string GetPassword()
        {
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter your [yellow]Password[/]:")
                    .PromptStyle("red")
                    .Secret());
            return password;
        }

        public static string DoYouWantToTryAgain()
        {
            Console.WriteLine();
            var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Do you want to try again?:[/]")
                        .PageSize(10)
                        .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                        .AddChoices(new[] {
                        "Yes",  "No"
                        })
                        .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
        public static void Greet()
        {
            AnsiConsole.MarkupLine($"[green]Hello user! To use Pocket Trainer first you need to login.[/]");
        }
        public static void PocketTrainerWriting()
        {
            AnsiConsole.Write(new FigletText("POCKET TRAINER").Color(Color.Red).Centered());
        }
        public static void LineBettwenScetion()
        {
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("red")));
        }
        public static void Singin()
        {
            AnsiConsole.MarkupLine("Sign In");
        }
        public static void Logging()
        {
            AnsiConsole.MarkupLine("Log In");
        }
    }
}

