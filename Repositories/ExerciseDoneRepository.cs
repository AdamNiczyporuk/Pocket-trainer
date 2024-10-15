using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace KCK_Project__Console_Pocket_trainer_.Repositories
{
    public class ExerciseDoneRepository : IExerciseDoneRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseDoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ExerciseDone exerciseDone)
        {
            _context.ExercisesDone.Add(exerciseDone);
            return Save();
        }

        public bool Delete(ExerciseDone exerciseDone)
        {
            _context.ExercisesDone.Remove(exerciseDone);
            return Save();
        }

        public bool Update(ExerciseDone exerciseDone)
        {
            _context.ExercisesDone.Update(exerciseDone);
            return Save();
        }

        public ExerciseDone GetExerciseDoneById(int id)
        {
            return _context.ExercisesDone.FirstOrDefault(e => e.Id == id);
        }

        public List<ExerciseWithSets> GetExercisesDoneByUser(int userId, int exerciseId)
        {
            var exercisesWithDetails = _context.ExercisesDone
                .Where(ed => ed.UserId == userId && ed.ExerciseId == exerciseId)
                .Select(e => new
                {
                    Exercise = e.Exercise,
                    ExerciseDone = e
                })
                .ToList();

            List<ExerciseWithSets> exercisesWithSets = new List<ExerciseWithSets>();

            foreach (var detail in exercisesWithDetails)
            {
                exercisesWithSets.Add(new ExerciseWithSets(
                    detail.Exercise,
                    detail.ExerciseDone.Sets,
                    detail.ExerciseDone.Reps,
                    detail.ExerciseDone.Weight
                ));
            }

            return exercisesWithSets;
        }

        public List<ExerciseWithSets> GetExercisesDoneByTraining(int trainingId)
        {
            var exercisesWithDetails = _context.ExercisesDone
                .Where(ed => ed.TrainingId == trainingId)
                .Select(e => new
                {
                    Exercise = e.Exercise,
                    ExerciseDone = e
                })
                .ToList();

            List<ExerciseWithSets> exercisesWithSets = new List<ExerciseWithSets>();

            foreach (var detail in exercisesWithDetails)
            {
                exercisesWithSets.Add(new ExerciseWithSets(
                    detail.Exercise,
                    detail.ExerciseDone.Sets,
                    detail.ExerciseDone.Reps,
                    detail.ExerciseDone.Weight
                ));
            }

            return exercisesWithSets;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
