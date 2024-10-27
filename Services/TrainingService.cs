using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Services
{
    public class TrainingService
    {
        public static int getVolume(Training training)
        {
            var context = new ApplicationDbContext();
            var exerciseDoneRepository = new ExerciseDoneRepository(context);
            var exercisesDone = exerciseDoneRepository.GetExercisesDoneByTraining(training.Id);
            int volume = 0;
            for (int i = 0; i< exercisesDone.Count; i++)
            {
                for(int j = 0; j< exercisesDone[i].Sets;j++)
                {
                    volume += exercisesDone[i].RepsList[j] * exercisesDone[i].WeightList[j];

                }
            }
            return volume;
        }
    }
}
