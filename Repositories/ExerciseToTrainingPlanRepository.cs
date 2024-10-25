using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Linq;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    public class ExerciseToTrainingPlanRepository : IExerciseToTrainingPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseToTrainingPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ExerciseToTrainingPlan exerciseToTrainingPlan)
        {
            _context.ExercisesToTrainingPlans.Add(exerciseToTrainingPlan);
            return Save();
        }

        public bool Delete(ExerciseToTrainingPlan exerciseToTrainingPlan)
        {
            _context.ExercisesToTrainingPlans.Remove(exerciseToTrainingPlan);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool Update(ExerciseToTrainingPlan exerciseToTrainingPlan)
        {
            _context.ExercisesToTrainingPlans.Update(exerciseToTrainingPlan);
            return Save();
        }
        public ExerciseToTrainingPlan GetExerciseToTrainingPlan(int trainingPlanId, int exerciseId)
        {
            return _context.ExercisesToTrainingPlans.FirstOrDefault(e => e.TrainingPlanId == trainingPlanId && e.ExerciseId == exerciseId);
        }
    }
}
