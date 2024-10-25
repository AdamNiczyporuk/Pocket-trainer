using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Services;
using KCK_Project__Console_Pocket_trainer_.Views;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                switch (option)
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
                using (var context = new ApplicationDbContext())
                {
                    var trainingPlanRepository = new TrainingPlanRepository(context);
                    var trainingPlans = trainingPlanRepository.GetUserTrainingPlans(Program.user.Id);
                    TrainingPlanView.ShowTrainingPlan(trainingPlans);
                }
                option = TrainingPlanView.GetOption();
                switch (option)
                {
                    case "Manage Training Plan Exercises":
                        ManageExercises();
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
            using (var context = new ApplicationDbContext())
            {
                var trainingPlanRepository = new TrainingPlanRepository(context);

                if (trainingPlanRepository.Add(trainingPlan))
                {
                    AnsiConsole.MarkupLine("[green]Training plan added![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Training plan not added![/]");
                }
            }


        }
        public void ManageExercises()
        {
            var option = "";
            while (option != "Back")
            {
                Console.Clear();
                
                option = TrainingPlanView.GetManageExerciseOption();
                switch (option)
                {
                    
                    case "Add exercise":
                        AddExerciseToTrainingPlan();
                        break;
                    case "Edit exercise":
                        //Edit training plan
                        break;
                    case "Delete exercise":
                        //Delete training plan
                        break;
                    case "Back":
                        break;
                }
            }

        }
        public void AddExerciseToTrainingPlan()
        {

            using (var context = new ApplicationDbContext())
            {
                var trainingPlanRepository = new TrainingPlanRepository(context);
                var exerciseRepository = new ExerciseRepository(context);

                Console.Clear();
                TrainingPlanView.TrainingPlanWriting();
                var trainingPlans = trainingPlanRepository.GetUserTrainingPlans(Program.user.Id);
                var id = TrainingPlanView.ChooseTrainingPlan(trainingPlans);
                if (id == -1)
                {
                    StartMenuView.ShowMessage("No training plans available...");
                    Thread.Sleep(2000);
                    return;
                }
                var exit = false;
                while (!exit)
                {
                    Console.Clear();
                    TrainingPlanView.TrainingPlanWriting();

                    var exercises = exerciseRepository.GetExercisesByTrainingPlan(id);
                    ExerciseView.ShowExercisesWithSets(exercises);
                    StartMenuView.ShowMessage($"Choose exercise to add to {trainingPlans.FirstOrDefault(tp => tp.Id == id).Name} training plan:");

                    var exercise = new ExerciseController().ChooseExercise();
                    var isAlreadyAdded = exercises.Any(e => e.Id == exercise.Id);
                    if (isAlreadyAdded)
                    {
                        StartMenuView.ShowMessage("Exercise already added to this training plan...");
                        var answer = ExerciseView.YesNoDialogue("Do you want to add another exercise?");
                        if (answer == "No")
                        {
                            exit = true;
                        }

                    }
                    else
                    {
                        var sets = ExerciseView.GetSets();
                        var Reps = ExerciseView.GetReps(sets);
                        var Weight = ExerciseView.GetWeight(sets);
                        var exerciseWithSets = new ExerciseToTrainingPlan()
                        {
                            ExerciseId = exercise.Id,
                            TrainingPlanId = id,
                            Sets = sets,
                            Reps = ExerciseService.RepsAndWeightsToString(Reps),
                            Weight = ExerciseService.RepsAndWeightsToString(Weight)
                        };

                        var exerciseToTrainingPlanRepository = new ExerciseToTrainingPlanRepository(context);
                        exerciseToTrainingPlanRepository.Add(exerciseWithSets);
                        StartMenuView.ShowMessage("[green]Exercise added to training plan...[/]");
                        var answer = ExerciseView.YesNoDialogue("Do you want to add another exercise?");
                        if (answer == "No")
                        {
                            exit = true;
                        }
                    }
                }
            }
        }
    }
}
