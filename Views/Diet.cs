using CHATAPI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_Project__Console_Pocket_trainer_.Views
{
    public class Diet
    {
        public static async Task Execute()
        {

            ChatGPT_diet.SetUpSetting();
            String Prompt = "My weigh=87kg,Height=186cm,TrainingsPerWeek=6trainingPerWeek.Write me a diet plan for 7 seven days.";



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
