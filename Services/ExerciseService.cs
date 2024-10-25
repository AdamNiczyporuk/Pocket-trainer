using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Services
{
    public class ExerciseService
    {
        public static string RepsAndWeightsToString(List<int> items)
        {
            var s = "";
            for (int i = 0; i < items.Count; i++)
            {
                s += items[i].ToString() + ",";
            }
            s = s.Remove(s.Length - 1);
            return s;
        }
    }
}
