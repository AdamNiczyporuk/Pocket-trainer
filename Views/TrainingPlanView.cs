﻿using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class TrainingPlanView

    {
        public static string GetOption()
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
           .Title("Choose an option:")
           .AddChoices(new[] {
                "Add exercises to training plan",
                "Add training plan",
                "Edit training plan",
                "Delete training plan",
                "Back"
           }).WrapAround());

            return option;
        }
        public static void TrainingPlanWriting()
        {
            AnsiConsole.Write(new FigletText("Training Plan").Color(Color.Green).Centered());
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("green")));
        }
        public static string GetName()
        {
            var name = AnsiConsole.Ask<string>("Enter the name of the training plan:");
            return name;
        }
        public static string GetDescription()
        {
            var description = AnsiConsole.Ask<string>("Enter the description of the training plan:");
            return description;
        }
        public static void ShowTrainingPlan(List<TrainingPlan> trainingPlans)
        {
            if (trainingPlans == null || trainingPlans.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No training plans available.[/]");
                return;
            }

            var table = new Table();

            table.Border = TableBorder.Rounded;
            table.AddColumn("[yellow]ID[/]");
            table.AddColumn("[green]Name[/]");
            table.AddColumn("[blue]Description[/]");
            table.AddColumn("[purple]Created At[/]");
            table.AddColumn("[red]Exercises Count[/]");

            foreach (var plan in trainingPlans)
            {
                using (var context = new ApplicationDbContext())
                {
                    var exerciseRepository = new ExerciseRepository(context);
                    var exercisesCount = exerciseRepository.GetExercisesByTrainingPlan(plan.Id).Count;
                    table.AddRow(
                        plan.Id.ToString(),
                        plan.Name ?? "[italic]No name[/]",
                        plan.Description ?? "[italic]No description[/]",
                        plan.CreatedAt.ToString("yyyy-MM-dd"),
                        exercisesCount.ToString() );
                        
                }
            }

            AnsiConsole.Write(table);
        }
    }
}
