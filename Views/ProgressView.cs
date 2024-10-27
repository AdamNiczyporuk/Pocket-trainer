using KCK_Project__Console_Pocket_trainer_.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class ProgressView
    {
        public static void ShowProgress(string trainingPlanName, List<Training> trainings, List<int> volumes)
        {
            // Sprawdzenie poprawności danych
            if (trainings == null || volumes == null || trainings.Count != volumes.Count || trainings.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid data: Please ensure the trainings and volumes lists are non-empty and of the same length.[/]");
                return;
            }

            // Nagłówek z nazwą planu treningowego
            AnsiConsole.MarkupLine($"[bold yellow]Progress for Training Plan: {trainingPlanName}[/]\n");

            // Przygotowanie wykresu słupkowego
            var chart = new BarChart()
                .Width(60)
                .Label("[bold yellow]Training Volume Progress (kg)[/]")
                .CenterLabel();

            // Dodawanie pozycji na wykresie dla każdego treningu z objętością w kg
            for (int i = 0; i < trainings.Count; i++)
            {
                string trainingName = $"Training {i + 1}";
                chart.AddItem(trainingName, volumes[i], Color.Blue);
            }

            AnsiConsole.Write(chart);
        }
        public static void CheckProgressWriting()
        {
            AnsiConsole.Write(new FigletText("Training Plan").Color(Color.Pink1).Centered());
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("Pink1")));
        }
    }

}