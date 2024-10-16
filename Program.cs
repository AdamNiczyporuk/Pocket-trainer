using Spectre.Console;
using System;
using System.Data;
using System.Threading.Tasks;
using CHATAPI;
using Microsoft.Identity.Client;
using System.Threading;
using KCK_Project__Console_Pocket_trainer_.Interfaces;

using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Data;
using System.Collections.Generic;
using KCK_Project__Console_Pocket_trainer_.Views;
class Program
{
    static async Task Main()
    {

        // API Donloader
        //API api = new API();

        //string[] muscles = new string[]
        //{
        //    "abdominals",
        //    "abductors",
        //    "adductors",
        //    "biceps",
        //    "calves",
        //    "chest",
        //    "forearms",
        //    "glutes",
        //    "hamstrings",
        //    "lats",
        //    "lower_back",
        //    "middle_back",
        //    "neck",
        //    "quadriceps",
        //    "traps",
        //    "triceps"
        //};

        //foreach (String muscle in muscles)
        //{
        //    // Wywołanie metody pobierającej dane z API
        //    await api.GetExerciseData(muscle);
        //}

        await StartMenu.Execute();






    }
}





