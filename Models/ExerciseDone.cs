using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Models
{
    public class ExerciseDone
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Sets { get; set; }
        public string Reps { get; set; }    //format: tyle numerów ile serii rozdzielone przecinkiem np.:
                                            //dla 3 serii 10 powtórzeń: 10,10,10
        public string Weight { get; set; }  //format: tyle numerów ile serii rozdzielone przecinkiem np.:
                                            //dla 3 serii pierwsza wagą 100kg, druga 110kg, trzecia 120kg: 100,110,120
    }
}
