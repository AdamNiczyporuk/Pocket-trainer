using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Interfaces
{
    public interface ITrainingPlanRepository
    {
        bool Add(TrainingPlan trainingPlan);
        bool Delete(TrainingPlan trainingPlan);
        bool Update(TrainingPlan trainingPlan);
        bool Save();
        TrainingPlan GetTrainingPlanById(int id);
        List<TrainingPlan> GetUserTrainingPlans(int userId);

    }

}
