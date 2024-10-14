using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Interfaces
{
    public interface ITrainingRepository
    {
        bool Add(Training trainig);
        bool Delete(Training trainig);
        bool Update(Training trainig);
        bool Save();
        List<Training> GetTrainingsByTrainingPlan(int trainingPlanId);
        List<Training> GetTrainingsByUser(int userId);
        Training GetTrainingById(int id);
    }
}
