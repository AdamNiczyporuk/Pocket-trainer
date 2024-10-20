using KCK_Project__Console_Pocket_trainer_.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class SettingsView
    {
        
        public static void AddData()
        {

        }
        public static void ShowUserSettings(User user)
        {

            var table = new Table();
            table.AddColumn("[green]Property[/]");
            table.AddColumn("[blue]Value[/]");
            table.AddRow("Username", user.UserName);
            string password = "";
            for(int i = 0; i < user.Password.Length; i++)
            {
                password += "*";
            }
            table.AddRow("Password", $"[red]{password}[/]");
            table.AddRow("Weight", user.Weight.HasValue ? user.Weight.ToString() : "unprovided");
            table.AddRow("Height", user.Height.HasValue ? user.Height.ToString() : "unprovided");
            table.AddRow("Weekly trainings", user.TrainingsPerWeek.HasValue ? user.TrainingsPerWeek.ToString() : "unprovided");
            table.Border = TableBorder.Rounded;
            table.Collapse();
            table.Centered();
            table.Columns[0].LeftAligned().Width(30);
            table.Columns[1].Centered();
            AnsiConsole.Render(table);
        }
    }
}
