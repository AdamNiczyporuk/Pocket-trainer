using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KCK_Project__Console_Pocket_trainer_.Models
{
    public class Training
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TreningPlanId { get; set; }
        public TrainingPlan TreningPlan { get; set; }

        public ICollection<ExerciseDone> ExercisesDone { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
