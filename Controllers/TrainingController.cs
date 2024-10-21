using KCK_Project__Console_Pocket_trainer_.Views;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class TrainingController
{
        public TrainingController()
        {
        }
        public async Task Run()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                
                var option = TrainingView.GetOption();
                switch(option)
                {
                    case "Do training":
                        //Do training
                        break;
                    case "See training plans":
                        //See training plans
                        break;
                    case "Track your progress":
                        //Track your progress
                        break;
                    case "See exercises":
                        new ExerciseController().ShowExercises();
                        break;
                    case "Back":
                        exit = true;
                        break;
                }
            }
        }
    }
}
