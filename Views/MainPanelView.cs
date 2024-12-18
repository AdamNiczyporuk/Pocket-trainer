﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class MainPanelView
{
        public static string GetOption()
        {
            var option = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("[yellow]Choose option:[/]")
                       .PageSize(10)
                       .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                       .AddChoices(new[] {
                        "Trainings", "Diet","Settings" ,"Exit"
                       })
                       .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
        public static void Wait()
        {
            Thread.Sleep(1000);
        }
        public static void Greet(string username)
        {
            AnsiConsole.MarkupLine($"[yellow]Welcome to Pocket Trainer, {username}![/]");
        }
        public static void PocketTrainerWriting()
        {
            AnsiConsole.Write(new FigletText("POCKET TRAINER").Color(Color.Red).Centered());
        }
        public static void LineBettwenScetion()
        {
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("red")));
        }
       
    }
}
