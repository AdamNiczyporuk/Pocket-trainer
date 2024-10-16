using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public float? Weight { get; set; }
        public float? Height { get; set; }
        public int? TrainingsPerWeek { get; set; }
        public ICollection<TrainingPlan> TrainingPlans { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public ICollection<ExerciseDone> ExercisesDone { get; set; }

        public ICollection<Diet> Diets { get; set; }
    }
}
