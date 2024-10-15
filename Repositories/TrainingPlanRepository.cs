using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Collections.Generic;
using System.Linq;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(TrainingPlan trainingPlan)
        {
            _context.TreningPlans.Add(trainingPlan);
            return Save();
        }

        public bool Delete(TrainingPlan trainingPlan)
        {
            _context.TreningPlans.Remove(trainingPlan);
            return Save();
        }

        public bool Update(TrainingPlan trainingPlan)
        {
            _context.TreningPlans.Update(trainingPlan);
            return Save();
        }

        public TrainingPlan GetTrainingPlanById(int id)
        {
            return _context.TreningPlans.FirstOrDefault(tp => tp.Id == id);
        }

        public List<TrainingPlan> GetUserTrainingPlans(int userId)
        {
            return _context.TreningPlans.Where(tp => tp.UserId == userId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
