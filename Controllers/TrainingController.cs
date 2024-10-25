using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Views;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class TrainingController
{
        public TrainingController()
        {
        }
        public async Task Run()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                MainPanelView.PocketTrainerWriting();
                var option = TrainingView.GetOption();
                switch(option)
                {
                    case "Do training":
                        //Do training
                        break;
                    case "Training Plans":
                        ShowTrainingPlans();
                        break;
                    case "Track your progress":
                        //Track your progress
                        break;
                    case "See exercises":
                        new ExerciseController().ShowExercises();
                        break;
                    case "Back":
                        exit = true;
                        break;
                }
            }
        }
        public void ShowTrainingPlans()
        {
            var option = "";
            while (option != "Back")
            {
                Console.Clear();
                TrainingPlanView.TrainingPlanWriting();
                using(var context = new ApplicationDbContext())
                {
                    var trainingPlanRepository = new TrainingPlanRepository(context);
                    var trainingPlans = trainingPlanRepository.GetUserTrainingPlans(Program.user.Id);
                    TrainingPlanView.ShowTrainingPlan(trainingPlans);
                }
                option = TrainingPlanView.GetOption();
                switch (option)
                {
                    case "Add exercise to training plan":
                        AddTrainingPlan();
                        break;
                    case "Add training plan":
                        AddTrainingPlan();
                        break;
                    case "Edit training plan":
                        //Edit training plan
                        break;
                    case "Delete training plan":
                        //Delete training plan
                        break;
                    case "Back":
                        break;
                }
            }

        }
        public void AddTrainingPlan()
        {
            Console.Clear();
            TrainingPlanView.TrainingPlanWriting();
            TrainingPlan trainingPlan = new TrainingPlan();
            trainingPlan.Name = TrainingPlanView.GetName();
            trainingPlan.Description = TrainingPlanView.GetDescription();
            trainingPlan.CreatedAt = DateTime.Now;
            trainingPlan.UserId = Program.user.Id;
            using(var context = new ApplicationDbContext())
            {
                var trainingPlanRepository = new TrainingPlanRepository(context);
                if(trainingPlanRepository.Add(trainingPlan))
                {
                    AnsiConsole.MarkupLine("[green]Training plan added![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Training plan not added![/]");
                }
            }


        }
    }
}
