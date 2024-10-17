using CHATAPI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_Project__Console_Pocket_trainer_.Views;
using KCK_Project__Console_Pocket_trainer_.Models;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class Diet
    {
        public static async Task Execute()
        {

            ChatGPT_diet.SetUpSetting();
            String Prompt = ($"My weigh={Program.user.Weight},Height={Program.user.Height},TrainingsPerWeek={Program.user.TrainingsPerWeek}.Write me a diet plan for 7 seven days.");



            var responseTask = ChatGPT_diet.SendRequestToChatGPT(Prompt);

            Console.CursorVisible = false;
            AnsiConsole.MarkupLine("[bold green]Generating Diet....[/]");

            var response = await responseTask;

            Console.CursorVisible = true;
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]Diet Plan:[/]");
            AnsiConsole.MarkupLine(response);

        }
    }
}
