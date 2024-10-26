using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Services;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using KCK_Project__Console_Pocket_trainer_.Views;
using Microsoft.Identity.Client;
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
                MainPanelView.LineBettwenScetion();
                var option = TrainingView.GetOption();
                switch (option)
                {
                    case "Do training":
                        DoTraining();
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
        public void DoTraining()
        {

            Console.Clear();
            TrainingView.TrainingWriting();
            using (var context = new ApplicationDbContext())
            {
                var trainingPlanRepository = new TrainingPlanRepository(context);
                var exerciseRepository = new ExerciseRepository(context);
                var trainingRepository = new TrainingRepository(context);

                var trainingPlans = trainingPlanRepository.GetUserTrainingPlans(Program.user.Id);
                TrainingPlanView.ShowTrainingPlan(trainingPlans);

                var id = TrainingPlanView.ChooseTrainingPlan(trainingPlans);
                if (id == -1)
                {
                    StartMenuView.ShowMessage("No training plans available...");
                    Thread.Sleep(2000);
                    return;
                }
                Console.Clear();
                TrainingView.TrainingWriting();
                var exercises = exerciseRepository.GetExercisesByTrainingPlan(id);
               // ExerciseView.ShowExercisesWithSets(exercises);
                var Trening = new Training();
                Trening.TreningPlanId = id;
                Trening.UserId = Program.user.Id;
                Trening.StartTime = DateTime.Now;
                var answer = ExerciseView.YesNoDialogue("[blue]Do you want to start training?[/]");
                if (answer == "Yes")
                {
                    trainingRepository.Add(Trening);
                    StartMenuView.ShowMessage("Starting training...");
                    StartTraining(Trening);
                    return;

                }
                else
                {
                    AnsiConsole.MarkupLine("[green]Returning...[/]");
                    return;
                }


            }
            


        }
        public void StartTraining(Training training)
        {
            var context = new ApplicationDbContext();
            var exeerciseDoneRepository = new ExerciseDoneRepository(context);
            var exerciseRepository = new ExerciseRepository(context);
            var exit = false;
            while (!exit)
            {
                var exercisesDone = exeerciseDoneRepository.GetExercisesDoneByTraining(training.Id);
                var exercisesToDo = exerciseRepository.GetExercisesByTrainingPlan(training.TreningPlanId);
                exercisesToDo.RemoveAll(e => exercisesDone.Any(ed => ed.Id == e.Id));
                if(exercisesToDo.Count == 0)
                {
                    training.EndTime = DateTime.Now;
                    if (new TrainingRepository(context).Update(training))
                    {
                        StartMenuView.ShowMessage("[green]Training Finished![/]");
                        Thread.Sleep(2000);
                    }
                    return;
                }
                Console.Clear();
                TrainingView.TrainingWriting();
                TrainingView.ShowExerciseDoneAndToDo(exercisesDone, exercisesToDo);
                var exerciseId = TrainingPlanView.ChooseExercise(exercisesToDo);
                DoExercise(exercisesToDo.FirstOrDefault(e => e.Id == exerciseId), training.Id);
                var answer = TrainingView.DoYouWantToFinishTraining();
                if (answer == "Finish Training")
                {
                    exit = true;
                    training.EndTime = DateTime.Now;
                    if (new TrainingRepository(context).Update(training))
                    {
                        StartMenuView.ShowMessage("[green]Training Finished![/]");
                        Thread.Sleep(2000);
                    }
                }
            }
        }
        public void DoExercise(ExerciseWithSets ex,int trainingId)
        {
            Console.Clear();
            TrainingView.TrainingWriting();
            TrainingView.ShowExerciseDoing(ex);
            var numberOfSets = ex.Sets;
            List<int> RepsList = new List<int>();
            List<int> WeightList = new List<int>();
            for (int i = 0; i < numberOfSets; i++)
            {
                var info = TrainingView.GetSetInfo(i + 1);
                RepsList.Add(info[0]);
                WeightList.Add(info[1]);
            }
            StartMenuView.ShowMessage("[green]Exercise Finished![/]");
            var context = new ApplicationDbContext();
            var exeerciseDoneRepository = new ExerciseDoneRepository(context);
            var exerciseDone = new ExerciseDone()
            {
                ExerciseId = ex.Id,
                TrainingId = trainingId,
                UserId = Program.user.Id,
                Sets = numberOfSets,
                Reps = ExerciseService.RepsAndWeightsToString(RepsList),
                Weight = ExerciseService.RepsAndWeightsToString(WeightList)
            };
            exeerciseDoneRepository.Add(exerciseDone);
            Thread.Sleep(2000);
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
                        EditTrainingPlan();
                        break;
                    case "Delete training plan":
                        DeleteTrainingPlan();
                        break;
                    case "Back":
                        break;
                }
            }

        }
        public void EditTrainingPlan()
        {
            var context = new ApplicationDbContext();
            var trainingPlanRepository = new TrainingPlanRepository(context);
            var trainingPlans = trainingPlanRepository.GetUserTrainingPlans(Program.user.Id);
            var id = TrainingPlanView.ChooseTrainingPlan(trainingPlans);
            if (id == -1)
            {
                StartMenuView.ShowMessage("No training plans available...");
                Thread.Sleep(2000);
                return;
            }
            var trainingPlan = trainingPlanRepository.GetTrainingPlanById(id);
            trainingPlan.Name = TrainingPlanView.GetName();
            trainingPlan.Description = TrainingPlanView.GetDescription();
            var answer = ExerciseView.YesNoDialogue("[blue]Do you want to save changes?[/]");
            if (answer == "Yes")
            {
                if (trainingPlanRepository.Update(trainingPlan))
                {
                    AnsiConsole.MarkupLine("[green]Training plan updated![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Training plan not updated![/]");
                }

            }
            else
            {
                AnsiConsole.MarkupLine("[green]Returning...[/]");
            }
            Thread.Sleep(2000);




        }
        public void DeleteTrainingPlan()
        {
            var context = new ApplicationDbContext();
            var trainingPlanRepository = new TrainingPlanRepository(context);
            var trainingPlans = trainingPlanRepository.GetUserTrainingPlans(Program.user.Id);
            var id = TrainingPlanView.ChooseTrainingPlan(trainingPlans);
            if (id == -1)
            {
                StartMenuView.ShowMessage("No training plans available...");
                Thread.Sleep(2000);
                return;
            }
            var trainingPlan = trainingPlanRepository.GetTrainingPlanById(id);
            var answer = ExerciseView.YesNoDialogue("[blue]Are you sure you want to delete this training plan?[/]");
            if (answer == "Yes")
            {
                if (trainingPlanRepository.Delete(trainingPlan))
                {
                    AnsiConsole.MarkupLine("[green]Training plan deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Training plan not deleted![/]");
                }

            }
            else
            {
                AnsiConsole.MarkupLine("[green]Returning...[/]");
            }
            Thread.Sleep(2000);

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
            var id = -1;
            using (var context = new ApplicationDbContext())
            {
                var trainingPlanRepository = new TrainingPlanRepository(context);
                var exerciseRepository = new ExerciseRepository(context);

                Console.Clear();
                TrainingPlanView.TrainingPlanWriting();
                var trainingPlans = trainingPlanRepository.GetUserTrainingPlans(Program.user.Id);
                id = TrainingPlanView.ChooseTrainingPlan(trainingPlans);
                if (id == -1)
                {
                    StartMenuView.ShowMessage("No training plans available...");
                    Thread.Sleep(2000);
                    return;
                }


                var option = "";

                while (option != "Back")
                {

                    Console.Clear();
                    TrainingPlanView.TrainingPlanWriting();
                    var exercises = exerciseRepository.GetExercisesByTrainingPlan(id);
                    ExerciseView.ShowExercisesWithSets(exercises);

                    option = TrainingPlanView.GetManageExerciseOption();
                    switch (option)
                    {

                        case "Add exercise":
                            AddExerciseToTrainingPlan(id);
                            break;
                        case "Edit exercise":
                            EditExerciseFromTrainingPlan(id);
                            break;
                        case "Delete exercise":
                            DeleteExerciseFromTrainingPlan(id);
                            break;
                        case "Back":
                            break;
                    }
                }
            }

        }
        public void EditExerciseFromTrainingPlan(int trainingPlanId)
        {
            var context = new ApplicationDbContext();
            var exerciseRepository = new ExerciseRepository(context);
            var exerciseToTrainingPlanRepository = new ExerciseToTrainingPlanRepository(context);
            var exercises = exerciseRepository.GetExercisesByTrainingPlan(trainingPlanId);
            var exerciseId = TrainingPlanView.ChooseExercise(exercises);
            if (exerciseId == -1)
            {
                StartMenuView.ShowMessage("No exercises available...");
                Thread.Sleep(2000);
                return;
            }
            var exerciseToTrainingPlan = exerciseToTrainingPlanRepository.GetExerciseToTrainingPlan(trainingPlanId, exerciseId);

            var sets = ExerciseView.GetSets();
            var Reps = ExerciseView.GetReps(sets);
            var Weight = ExerciseView.GetWeight(sets);
            exerciseToTrainingPlan.Sets = sets;
            exerciseToTrainingPlan.Reps = ExerciseService.RepsAndWeightsToString(Reps);
            exerciseToTrainingPlan.Weight = ExerciseService.RepsAndWeightsToString(Weight);
            var answer = ExerciseView.YesNoDialogue("[blue]Do you want to save changes?[/]");
            if (answer == "Yes")
            {
                if (exerciseToTrainingPlanRepository.Update(exerciseToTrainingPlan))
                {
                    AnsiConsole.MarkupLine("[green]Exercise updated![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Exercise not updated![/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[green]Returning...[/]");
            }

            Thread.Sleep(2000);
        }
        public void DeleteExerciseFromTrainingPlan(int trainingPlanId)
        {
            var context = new ApplicationDbContext();
            var exerciseRepository = new ExerciseRepository(context);
            var exerciseToTrainingPlanRepository = new ExerciseToTrainingPlanRepository(context);
            var exercises = exerciseRepository.GetExercisesByTrainingPlan(trainingPlanId);
            var exerciseId = TrainingPlanView.ChooseExercise(exercises);
            if (exerciseId == -1)
            {
                StartMenuView.ShowMessage("No exercises available...");
                Thread.Sleep(2000);
                return;
            }
            var exerciseToTrainingPlan = exerciseToTrainingPlanRepository.GetExerciseToTrainingPlan(trainingPlanId, exerciseId);
            var answer = ExerciseView.YesNoDialogue("[blue]Are you sure you want to delete this exercise from training plan?[/]");
            if (answer == "Yes")
            {
                if (exerciseToTrainingPlanRepository.Delete(exerciseToTrainingPlan))
                {
                    AnsiConsole.MarkupLine("[green]Exercise deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Exercise not deleted![/]");
                }

            }
            else
            {
                AnsiConsole.MarkupLine("[green]Returning...[/]");
            }
            Thread.Sleep(2000);
        }

        public void AddExerciseToTrainingPlan(int trainingPlanId)
        {

            using (var context = new ApplicationDbContext())
            {
                var trainingPlanRepository = new TrainingPlanRepository(context);
                var exerciseRepository = new ExerciseRepository(context);

                Console.Clear();
                TrainingPlanView.TrainingPlanWriting();

                var trainingPlan = trainingPlanRepository.GetTrainingPlanById(trainingPlanId);
                var exit = false;
                while (!exit)
                {


                    var exercises = exerciseRepository.GetExercisesByTrainingPlan(trainingPlanId);


                    Console.Clear();
                    ExerciseView.ExerciseWriting();

                    var exercise = new ExerciseController().ChooseExercise();
                    var isAlreadyAdded = exercises.Any(e => e.Id == exercise.Id);
                    if (isAlreadyAdded)
                    {
                        StartMenuView.ShowMessage("[red]Exercise already added to this training plan...[/]");
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
                            TrainingPlanId = trainingPlanId,
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
