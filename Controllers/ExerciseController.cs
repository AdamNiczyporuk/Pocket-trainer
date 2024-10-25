using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class ExerciseController
{
        private ApplicationDbContext _context;
        private ExerciseRepository _exerciseRepository;
        private List<string> exerciseMuscles = new List<string>()
        {
                 "abdominals",
            "abductors",
            "adductors",
            "biceps",
            "calves",
            "chest",
            "forearms",
            "glutes",
            "hamstrings",
            "lats",
            "lower_back",
            "middle_back",
            "neck",
            "quadriceps",
            "traps",
            "triceps"
        };
        public ExerciseController()
        {
            _context = new ApplicationDbContext();
            _exerciseRepository =  new ExerciseRepository(_context);
        }

        public void ShowExercises()
        {
            var muscle = Views.ExerciseView.GetExerciseMuscle(exerciseMuscles);
            var exercises = _exerciseRepository.GetExercisesByMuscle(muscle);
            Views.ExerciseView.ShowExercises(exercises);
            var option = ExerciseView.YesNoDialogue("Do you want to see details?");
            Console.Clear();
            if (option == "Yes")
            {
                var name = Views.ExerciseView.GetExerciseName(exercises);
                var exercise = _exerciseRepository.GetExercisesByName(name)[0];
                Views.ExerciseView.ShowExerciseDetails(exercise);
                StartMenuView.ShowMessage("[yellow]Press any key to return...[/]");
                Console.ReadKey();
            }

        }
        public Exercise ChooseExercise()
        {
            var muscle = Views.ExerciseView.GetExerciseMuscle(exerciseMuscles);
            var exercises = _exerciseRepository.GetExercisesByMuscle(muscle);
            Views.ExerciseView.ShowExercises(exercises);
            var name = Views.ExerciseView.GetExerciseName(exercises);
            return exercises.FirstOrDefault(e => e.Name == name);
        }
      
        
    }
}
