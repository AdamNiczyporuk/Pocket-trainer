using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
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
                        "Do Training", "Training Plans","Check Progress","See Exercises", "Back"
                    })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
        return option;
    }
        public static void TrainingWriting()
        {
            AnsiConsole.Write(new FigletText("Training").Color(Color.Green).Centered());
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("green")));
        }
        public static void ShowExerciseDoneAndToDo(List<ExerciseWithSets> exerciseDone, List<ExerciseWithSets> exerciseToDo)
        {
            var table = new Table();
            table.Border = TableBorder.Rounded;
            table.AddColumn("[green]Exercises Done[/]");
            table.AddColumn("[yellow]Exercises To Do[/]");

            int maxCount = Math.Max(exerciseDone.Count, exerciseToDo.Count);

            for (int i = 0; i < maxCount; i++)
            {
                var doneExercise = i < exerciseDone.Count ? FormatExercise(exerciseDone[i]) : "";
                var toDoExercise = i < exerciseToDo.Count ? FormatExercise(exerciseToDo[i]) : "";

                table.AddRow(doneExercise, toDoExercise);
            }

            AnsiConsole.Write(table);
        }
        public static void ShowExerciseDoing(ExerciseWithSets ex)
        {
            if (ex == null)
            {
                AnsiConsole.MarkupLine("[red]No exercise selected.[/]");
                return;
            }

            // Panel z nazwą ćwiczenia
            var namePanel = new Panel(
                Align.Center(new Markup($"[bold yellow]{ex.Name}[/]"), VerticalAlignment.Middle))
                .Expand()
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Green);

            // Tabela z podstawowymi informacjami o ćwiczeniu
            var exerciseInfo = new Grid().Centered();
            exerciseInfo.AddColumn();
            exerciseInfo.AddColumn();

            exerciseInfo.AddRow("[bold]Type[/]", ex.Type);
            exerciseInfo.AddRow("[bold]Target Muscle[/]", ex.Muscle);
            exerciseInfo.AddRow("[bold]Equipment[/]", ex.Equipment);
            exerciseInfo.AddRow("[bold]Difficulty[/]", ex.Difficulty.ToString());

            // Panel z instrukcjami
            var instructionsPanel = new Panel(new Text(ex.Instructions ?? "N/A").LeftJustified())
                .Header("[yellow]Instructions[/]")
                .Expand()
                .Border(BoxBorder.Rounded);

            // Tabela z informacjami o seriach
            var setsInfo = new Table();
            setsInfo.AddColumn("Set");
            setsInfo.AddColumn("Reps x Weight");

            for (int i = 0; i < ex.Sets; i++)
            {
                setsInfo.AddRow($"Set {i + 1}", $"{ex.RepsList[i]} x {ex.WeightList[i]} kg");
            }

            // Organizacja layoutu: wyświetlanie
            AnsiConsole.Write(namePanel);
            AnsiConsole.Write(new Panel(exerciseInfo)
                .Header("[yellow]Exercise Details[/]")
                .Expand()
                .Border(BoxBorder.Rounded));
            AnsiConsole.Write(instructionsPanel);
            AnsiConsole.Write(new Panel(setsInfo)
                .Header("[yellow]Sets Info[/]")
                .Expand()
                .BorderColor(Color.Yellow));
        }
        public static List<int> GetSetInfo(int setNumber)
        {
            List<int> setInfo = new List<int>();

            // Pobieranie liczby powtórzeń z walidacją
            int reps = AnsiConsole.Prompt(
                new TextPrompt<int>($"[yellow]Enter the number of reps for set {setNumber}:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid number of reps greater than 0.[/]")
                    .Validate(input => input > 0)
            );
            setInfo.Add(reps);

            // Pobieranie ciężaru z walidacją
            int weight = AnsiConsole.Prompt(
                new TextPrompt<int>($"[yellow]Enter the weight for set {setNumber} (in kg):[/]")
                    .ValidationErrorMessage("[red]Please enter a valid weight greater than or equal to 0.[/]")
                    .Validate(input => input >= 0)
            );
            setInfo.Add(weight);

            return setInfo;
        }
        public static string DoYouWantToFinishTraining()
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Choose option:[/]")
                    .PageSize(10)
                    .WrapAround(true)
                    .AddChoices(new[] { "Do another exercise", "Finish Training" })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
        private static string FormatExercise(ExerciseWithSets exercise)
        {
            return $"[bold]{exercise.Name}[/] ({exercise.Type})\n{exercise.SetsToString()}";
        }
    }
}
