using KCK_Project__Console_Pocket_trainer_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Controllers
{
    public class SettingsController
{
        public SettingsController()
        {

        }
        public async Task Run()
        {
            Console.Clear();
            SettingsView.ShowUserSettings(Program.user);
            Console.ReadKey();
        }
    }
}
