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
using KCK_Project__Console_Pocket_trainer_.Controllers;
class Program
{
    public static User user;
    static async Task Main()
    {
        MainPanelController mainPanelController = new MainPanelController();
        await mainPanelController.Run();






    }
}

