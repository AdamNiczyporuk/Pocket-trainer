using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.ViewModels
{
    public class ExerciseWithSets : Exercise
    {
       
        public int Sets { get; set; }
        public List<int> RepsList { get; set; }
        public List<int> WeightList { get; set; }
        public ExerciseWithSets(Exercise exercsie, int sets, string reps, string weight)
        {
            string[] repsArray = reps.Split(',');
            string[] weightArray = weight.Split(',');
            RepsList = new List<int>();
            WeightList = new List<int>();
            for (int i = 0; i < sets; i++)
            {
                RepsList.Add(int.Parse(repsArray[i]));
                WeightList.Add(int.Parse(weightArray[i]));
            }
            Id = exercsie.Id;
            Name = exercsie.Name;
            Type = exercsie.Type;
            Muscle = exercsie.Muscle;
            Equipment = exercsie.Equipment;
            Difficulty = exercsie.Difficulty;
            Instructions = exercsie.Instructions;
            Sets = sets;
        }
        public string SetsToString() {
            string setsString = "";
            for (int i = 0; i < Sets; i++)
            {
                setsString += $"{RepsList[i]} x {WeightList[i]} kg,";
            }
            setsString = setsString.Remove(setsString.Length - 1);
            return setsString;
        }
    }
}
