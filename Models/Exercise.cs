using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Muslce { get; set; }
        public string Equipment { get; set; }
        public string Difficulty { get; set; }

        public string Instructions { get; set; }    
        public ICollection<ExerciseToTrainingPlan> TrainingPlans { get; set; }
        public ICollection<ExerciseDone> ExercisesDone { get; set; }

    }
}
