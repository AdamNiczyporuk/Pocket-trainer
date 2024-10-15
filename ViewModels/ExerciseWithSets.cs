using KCK_Project__Console_Pocket_trainer_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.ViewModels
{
    public class ExerciseWithSets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Muscle { get; set; }
        public string Equipment { get; set; }
        public string Difficulty { get; set; }
        public string Instructions { get; set; }
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
    }
}
