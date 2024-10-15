using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Interfaces
{
    public interface IExerciseDoneRepository
{
        bool Add(ExerciseDone exerciseDone);
        bool Delete(ExerciseDone exerciseDone);
        bool Update(ExerciseDone exerciseDone);
        bool Save();
        ExerciseDone GetExerciseDoneById(int id);
        List<ExerciseWithSets> GetExercisesDoneByUser(int userId, int exerciseId);
        List<ExerciseWithSets> GetExercisesDoneByTraining(int trainingId);
        


    }
}
