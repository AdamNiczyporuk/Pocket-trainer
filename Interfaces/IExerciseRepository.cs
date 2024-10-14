﻿using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Interfaces
{
    public interface IExerciseRepository
{
        bool Add(Exercise exercise);
        bool Delete(Exercise exercise);
        bool Update(Exercise exercise);
        bool Save();
        Exercise GetExerciseById(int id);
        List<Exercise> GetUserExercises(int userId);
        List<Exercise> GetExercisesByMuscle(string muscle);
        List<Exercise> GetExercisesByName(string name);
        List<Exercise> GetExercisesByTrainingPlan(string type);

    }
}