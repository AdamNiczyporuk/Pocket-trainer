using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Interfaces
{
    public interface IExerciseToTrainingPlanRepository
{
        bool Add(ExerciseToTrainingPlan exercise);
        bool Delete(ExerciseToTrainingPlan exercise);
        bool Update(ExerciseToTrainingPlan exercise);
        bool Save();
        ExerciseToTrainingPlan GetExerciseToTrainingPlan(int trainingPlanId, int exerciseId);

    }
}
