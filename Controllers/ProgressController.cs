using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Services;
using KCK_Project__Console_Pocket_trainer_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class ProgressController
    {
        private TrainingPlan _trainingPlan;
        public ProgressController(TrainingPlan trainingPlan)
        {
            _trainingPlan = trainingPlan;
        }
        public void Run()
        {
            var context = new ApplicationDbContext();
            var trainingRepository = new TrainingRepository(context);
            var trainings = trainingRepository.GetTrainingsByTrainingPlan(_trainingPlan.Id);
            trainings.RemoveAll(t => t.EndTime == null);
            List<int> volumes = new List<int>();
            foreach (var training in trainings)
            {
                volumes.Add(TrainingService.getVolume(training));
            }
            Console.Clear();
            ProgressView.CheckProgressWriting();
            ProgressView.ShowProgress(_trainingPlan.Name,trainings, volumes);
            StartMenuView.ShowMessage("\n\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
