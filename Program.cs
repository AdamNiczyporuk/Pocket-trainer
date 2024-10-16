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
   

 
    

    //static async Task Diet()
    //{
    //    ChatGPT_diet.SetUpSetting();
    //    String Prompt = "My weigh=87kg,Height=186cm,TrainingsPerWeek=6trainingPerWeek.Write me a diet plan for 7 seven days.";

     

    //    var responseTask =  ChatGPT_diet.SendRequestToChatGPT(Prompt);

    //    Console.CursorVisible = false; 
    //    AnsiConsole.MarkupLine("[bold green]Generating Diet....[/]");

    //    var response = await responseTask;

    //    Console.CursorVisible = true;
    //    AnsiConsole.Clear();
    //    AnsiConsole.MarkupLine("[bold green]Diet Plan:[/]");
    //    AnsiConsole.MarkupLine(response);

       
  
    //}
    //public static async Task Panel()
    //{
    //    bool exit = false;
    //    Console.Clear();
    //    while (!exit)
    //    {
    //        // Tworzenie prompta z opcjami menu

    //        var option = AnsiConsole.Prompt(
    //            new SelectionPrompt<string>()
    //                .Title("[yellow]Wybierz opcję:[/]")
    //                .PageSize(10)
    //                .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
    //                .AddChoices(new[] {
    //                    "Add Training", "See Data", "Write Diet","Settings" ,"Exit"
    //                })
    //                .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

    //        // Obsługa wsybranej opcji
    //        switch (option)
    //        {
    //            case "Add Training":
    //                AnsiConsole.MarkupLine("[green]Add Training![/]");
    //                break;
    //            case "See Data":
    //                AnsiConsole.MarkupLine("[green]See Data![/]");
    //                break;
    //            case "Write Diet":
    //                await Diet();
    //                break;
    //            case "Settings":
    //                AnsiConsole.MarkupLine("[green]Settings![/]");
    //                break;
    //            case "Exit":
    //                AnsiConsole.MarkupLine("[red]Program End.[/]");
    //                exit = true;
    //                StartMenu();
    //                break;
    //        }

            
    //    }
    //}

    //static async Task  StartMenu()
    //{
    //    Console.Clear();
    //    bool exit = false;

    //    while (!exit)
    //    {
    //        // Tworzenie prompta z opcjami menu

    //        var option = AnsiConsole.Prompt(
    //            new SelectionPrompt<string>()
    //                .Title("[yellow]Wybierz opcję:[/]")
    //                .PageSize(10)
    //                .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
    //                .AddChoices(new[] {
    //                    "Log IN", "Sign IN", "Exit"
    //                })
    //                .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

    //        // Obsługa wsybranej opcji
    //        switch (option)
    //        {
    //            case "Log IN":
    //                exit= true;
    //                await  LogIN();
    //                break;
    //            case "Sign IN":
    //               await SignIN();
    //                AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 2![/]");
    //                break;
    //            case "Exit":
    //                AnsiConsole.MarkupLine("[red]Koniec programu.[/]");
    //                exit = true;
    //                break;
    //        }

           
    //    }
    //}
    //static async Task  SignIN()
    //{// Display the login view


    //    while (true)
    //    {
    //        var mail = AnsiConsole.Ask<string>("Enter your [yellow]E-mail[/]:");
    //        var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
    //        var password = AnsiConsole.Prompt(
    //                       new TextPrompt<string>("Enter your [yellow]Password[/]:")
    //                                      .PromptStyle("red")
    //                                                     .Secret());  // Mask the input for password

    //        // Wyświetlenie opcji wyboru
    //        var option = AnsiConsole.Prompt(
    //            new SelectionPrompt<string>()
    //                .Title("[yellow]Choose an option:[/]")
    //                .AddChoices(new[] { "SignIN", "Exit" })
    //                .HighlightStyle(new Style(foreground: Color.Aqua)));

    //        if (option == "Exit")
    //        {
    //            AnsiConsole.MarkupLine("[red]Exiting the application...[/]");
    //            break; // Wyjście z pętli i zakończenie aplikacji
    //        }
    //        if (option == "SignIN")
    //        {
    //            if (mail == "" || username == "" || password == "")
    //            {
    //                AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
    //                 SignIN();
    //            }
    //            else if (mail.Contains("@") == false)
    //            {
    //                AnsiConsole.MarkupLine("[red]Invalid email![/]");
    //                 SignIN();
    //            }
    //            else
    //            {
    //                // Check if the user already exists
    //                // Seraching user thorugh Mail a
    //                //Validate password and Username
    //                // Add the user to the database
    //                // AddUserToDatabase(mail, username, password);
    //                AnsiConsole.MarkupLine("[green]User added successfully![/]");
    //                await Panel();
    //            }
                
    //        }

    //    }


    //}
    //static async Task LogIN()
    //{
    //    while (true)
    //    {
    //        // Wyświetlenie opcji logowania
    //        var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
    //        var password = AnsiConsole.Prompt(
    //            new TextPrompt<string>("Enter your [yellow]Password[/]:")
    //                .PromptStyle("red")
    //                .Secret());

    //        // Wyświetlenie opcji wyboru
    //        var option = AnsiConsole.Prompt(
    //            new SelectionPrompt<string>()
    //                .Title("[yellow]Choose an option:[/]")
    //                .AddChoices(new[] { "Login", "Exit" })
    //                .HighlightStyle(new Style(foreground: Color.Aqua)));

    //        if (option == "Exit")
    //        {
    //            AnsiConsole.MarkupLine("[red]Exiting the application...[/]");
    //            break; // Wyjście z pętli i zakończenie aplikacji
    //        }

    //        // Symulacja walidacji logowania (możesz zastąpić to własną logiką)
    //        if (ValidateLogin(username, password))
    //        {
    //            await Panel();
    //            break;

    //        }
    //        else
    //        {
    //            AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
    //        }
    //    }
    //}

    //// Metoda symulująca walidację logowania
    //static bool ValidateLogin(string username, string password)
    //{
    //    // Przykładowa walidacja - zastąp to własną logiką
    //    return username == "admin" && password == "admin";
    //}




}

