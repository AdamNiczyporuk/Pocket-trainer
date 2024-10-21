using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            return Save();
        }

        public bool Delete(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
            return Save();
        }

        public bool Update(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            return Save();
        }

        public Exercise GetExerciseById(int id)
        {
            return _context.Exercises.FirstOrDefault(e => e.Id == id);
        }

        public List<Exercise> GetExercisesByMuscle(string muscle)
        {
            return _context.Exercises.Where(e => e.Muscle == muscle).ToList();
        }

        public List<Exercise> GetExercisesByName(string name)
        {
            return _context.Exercises.Where(e => e.Name.Contains(name)).ToList();
        }

        public List<ExerciseWithSets> GetExercisesByTrainingPlan(int trainingPlanId)
        {
            var exercisesWithDetails = _context.ExercisesToTrainingPlans
                .Where(e => e.TrainingPlanId == trainingPlanId)
                .Select(e => new
                {
                    Exercise = e.Exercise,
                    ExerciseToTrainingPlan = e
                })
                .ToList();

            List<ExerciseWithSets> exercisesWithSets = new List<ExerciseWithSets>();

            foreach (var detail in exercisesWithDetails)
            {
                exercisesWithSets.Add(new ExerciseWithSets(
                    detail.Exercise,
                    detail.ExerciseToTrainingPlan.Sets,
                    detail.ExerciseToTrainingPlan.Reps,
                    detail.ExerciseToTrainingPlan.Weight
                ));
            }

            return exercisesWithSets;
        }
        public List<Exercise> GetAllExercises()
        {
            return _context.Exercises.ToList();
        }



        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
