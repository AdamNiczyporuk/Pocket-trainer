using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Collections.Generic;
using System.Linq;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Training training)
        {
            _context.Trainings.Add(training);
            return Save();
        }

        public bool Delete(Training training)
        {
            _context.Trainings.Remove(training);
            return Save();
        }

        public bool Update(Training training)
        {
            _context.Trainings.Update(training);
            return Save();
        }

        public Training GetTrainingById(int id)
        {
            return _context.Trainings.FirstOrDefault(t => t.Id == id);
        }

        public List<Training> GetTrainingsByTrainingPlan(int trainingPlanId)
        {
            return _context.Trainings.Where(t => t.TreningPlanId == trainingPlanId).ToList();
        }

        public List<Training> GetTrainingsByUser(int userId)
        {
            return _context.Trainings.Where(t => t.UserId == userId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
