﻿using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class ExerciseView
    {
        public static void ShowExercises(List<Exercise> exercises)
        {
            var table = new Table();
           
            table.Border = TableBorder.Rounded;
            table.Expand();

           

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.AddColumn(new TableColumn("[green]Name[/]").Centered());
                    ctx.Refresh();
                    Thread.Sleep(100);
                    table.AddColumn(new TableColumn("[blue]Type[/]").Centered());
                    ctx.Refresh();
                    Thread.Sleep(100);
                    table.AddColumn(new TableColumn("[red]Muscle[/]").Centered());
                    ctx.Refresh();
                    Thread.Sleep(100);
                    table.AddColumn(new TableColumn("[yellow]Equipment[/]").Centered());
                    ctx.Refresh();
                    Thread.Sleep(100);
                    table.AddColumn(new TableColumn("[magenta]Difficulty[/]").Centered());
                    ctx.Refresh();
                    Thread.Sleep(100);
                    foreach (var exercise in exercises)
                    {
                        table.AddRow(
                            new Markup(exercise.Name),
                            new Markup(exercise.Type),
                            new Markup(exercise.Muscle),
                            new Markup(exercise.Equipment),
                            new Markup(exercise.Difficulty)
                        );
                        table.AddEmptyRow(); // Add an empty row to separate each exercise
                        ctx.Refresh();
                        Thread.Sleep(100);
                    }
                });
        }
        public static void ShowExercisesWithSets(List<ExerciseWithSets> exercises)
        {
            var table = new Table();
            table.AddColumn(new TableColumn("[green]Name[/]").Centered());
            table.AddColumn(new TableColumn("[blue]Sets[/]").Centered());
            table.AddColumn(new TableColumn("[red]Reps and Weight[/]").Centered());
            table.Border = TableBorder.Rounded;
            table.Expand();

            foreach (var exercise in exercises)
            {
                table.AddRow(
                    new Markup(exercise.Name),
                    new Markup(exercise.Sets.ToString()),
                    new Markup(exercise.SetsToString())

                );
                 // Add an empty row to separate each exercise
            }

            AnsiConsole.Render(table);
        }
        public static string GetExerciseMuscle(List<string> exerciseMuscles)
        {
            
            var muscle = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Choose witch muscle you want to build.:[/]")
                    .PageSize(10)
                    .WrapAround(true)
                    .AddChoices(exerciseMuscles)
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return muscle;
        }
        public static string GetExerciseName(List<Exercise> exercises)
        {
            List<string> exerciseNames = new List<string>();
            foreach (var exercise in exercises)
            {
                exerciseNames.Add(exercise.Name);
            }
            
            var name = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Choose exercise.:[/]")
                    .PageSize(10)
                    .WrapAround(true)
                    .AddChoices(exerciseNames)
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return name;
        }
        public static string YesNoDialogue(string question)
        {
            var option = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title($"[yellow]{question}[/]")
                   .PageSize(10)
                   .WrapAround(true)
                   .AddChoices("Yes","No")
                   .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));
            return option;
        }
        public static void ShowExerciseDetails(Exercise exercise)
        {
            var instructions = new Panel(
                    new Text(exercise.Instructions)
                        .LeftJustified())
                    .Header("[yellow]Instructions[/]")
                    .Border(BoxBorder.Rounded)
                    .Expand();
            var name = new Panel(
                    Align.Center(
                        new Markup($"[blue]{exercise.Name}[/]"),
                        VerticalAlignment.Middle))
                    .Expand();

            

            // Update the right column's bottom section with exercise properties
           var data= new Panel(
                    new Grid().Centered()
                        .AddColumn()
                        .AddColumn()
                        .AddRow("[green]Muscle[/]", exercise.Muscle)
                        .AddRow("[green]Type[/]", exercise.Type)
                        .AddRow("[green]Equipment[/]", exercise.Equipment)
                        .AddRow("[green]Difficulty[/]", exercise.Difficulty))
                    .Header("[yellow]Exercise Details[/]")
                    .Border(BoxBorder.Rounded)
                    .Expand();

            // Render the layout
            AnsiConsole.Render(name);
            AnsiConsole.Render(data);
            AnsiConsole.Render(instructions);

        }
        public static int GetSets()
        {
            int sets;
            while (true)
            {
                var input = AnsiConsole.Ask<string>("Enter number of [yellow]Sets[/]:");

                
                if (Int32.TryParse(input, out sets) && sets >= 1 && sets<=10)
                {
                    return sets;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Please enter valid number of Sets.[/]");
                }
            }

        }
        public static List<int> GetReps(int sets)
        {
            
            while (true)
            {
                var format = "";
                for (int i = 0; i < sets; i++)
                {
                    format += "X,";
                }
                format = format.Remove(format.Length - 1);
                var input = AnsiConsole.Ask<string>($"Enter number of [blue]Reps[/] for each [yellow]Set[/] (separeted by comma {format} ):");

                var reps = input.Split(',');
                List<int> repsList = new List<int>();
                bool isValid = true;
                if (reps.Length == sets)
                {

                    for (int i = 0; i < sets; i++)
                    {
                        if (Int32.TryParse(reps[i], out int rep) && rep >= 1 && rep <= 100)
                        {
                            repsList.Add(rep);
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    if (isValid)
                    {
                        return repsList;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]Please enter valid Reps.[/]");
                    }

                }

            }
        }
        public static List<int> GetWeight(int sets)
        {
            while (true)
            {
                var format = "";
                for (int i = 0; i < sets; i++)
                {
                    format += "X,";
                }
                format = format.Remove(format.Length - 1);
                var input = AnsiConsole.Ask<string>($"Enter [blue]Weight[/] in kg for each [yellow]Set[/] (separeted by comma {format} ):");

                var reps = input.Split(',');
                List<int> repsList = new List<int>();
                bool isValid = true;
                if (reps.Length == sets)
                {

                    for (int i = 0; i < sets; i++)
                    {
                        if (Int32.TryParse(reps[i], out int rep) && rep >= 1 && rep <= 100)
                        {
                            repsList.Add(rep);
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    if (isValid)
                    {
                        return repsList;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]Please enter valid Weight.[/]");
                    }
                }


            }
            
        }
        public static void ExerciseWriting()
        {
            AnsiConsole.Write(new FigletText("Exercise").Color(Color.Orange1).Centered());
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("Orange1")));
        }
    }
}
