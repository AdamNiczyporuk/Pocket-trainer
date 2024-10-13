using KCK_Project__Console_Pocket_trainer_.Repositories;
using Spectre.Console;
using System;
using System.Data;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        API api = new API();
        string muscle = "biceps";

        // Wywołanie metody pobierającej dane z API
        string result = await api.GetExerciseData(muscle);

        // Wyświetlenie odpowiedzi z API na konsoli
        Console.WriteLine(result);
    }
    static void Panel()
    {
        bool exit = false;
        Console.Clear();
        while (!exit)
        {
            // Tworzenie prompta z opcjami menu

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Wybierz opcję:[/]")
                    .PageSize(10)
                    .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                    .AddChoices(new[] {
                        "Add Training", "See Data", "Write Diet","Settings" ,"Exit"
                    })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

            // Obsługa wsybranej opcji
            switch (option)
            {
                case "Add Training":
                    AnsiConsole.MarkupLine("[green]Add Training![/]");
                    break;
                case "See Data":
                    AnsiConsole.MarkupLine("[green]See Data![/]");
                    break;
                case "Settings":
                    AnsiConsole.MarkupLine("[green]Settings![/]");
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[red]Program End.[/]");
                    StartMenu();
                    break;
            }

            // Czekaj na naciśnięcie klawisza przed powrotem do menu, jeśli użytkownik nie wybrał wyjścia
            if (!exit)
            {
                AnsiConsole.MarkupLine("[grey]Naciśnij dowolny klawisz, aby wrócić do menu...[/]");
                Console.ReadKey();
            }
        }
    }

    static void StartMenu()
    {
        Console.Clear();
        bool exit = false;

        while (!exit)
        {
            // Tworzenie prompta z opcjami menu

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Wybierz opcję:[/]")
                    .PageSize(10)
                    .WrapAround(true)// Maksymalna ilość opcji na jednej stronie
                    .AddChoices(new[] {
                        "Log IN", "Sign IN", "Exit"
                    })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

            // Obsługa wsybranej opcji
            switch (option)
            {
                case "Log IN":
                    LogIN();
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 1![/]");
                    break;
                case "Sign IN":
                    SignIN();
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 2![/]");
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[red]Koniec programu.[/]");
                    exit = true;
                    break;
            }

            // Czekaj na naciśnięcie klawisza przed powrotem do menu, jeśli użytkownik nie wybrał wyjścia
            if (!exit)
            {
                AnsiConsole.MarkupLine("[grey]Naciśnij dowolny klawisz, aby wrócić do menu...[/]");
                Console.ReadKey();
            }
        }
    }
    static void SignIN()
    {// Display the login view

  
        while (true)
        {
            var mail = AnsiConsole.Ask<string>("Enter your [yellow]E-mail[/]:");
            var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
            var password = AnsiConsole.Prompt(
                           new TextPrompt<string>("Enter your [yellow]Password[/]:")
                                          .PromptStyle("red")
                                                         .Secret());  // Mask the input for password

            // Wyświetlenie opcji wyboru
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Choose an option:[/]")
                    .AddChoices(new[] { "SignIN", "Exit" })
                    .HighlightStyle(new Style(foreground: Color.Aqua)));

            if (option == "Exit")
            {
                AnsiConsole.MarkupLine("[red]Exiting the application...[/]");
                break; // Wyjście z pętli i zakończenie aplikacji
            }
            if (option == "SignIN")
            {
                if (mail == "" || username == "" || password == "")
                {
                    AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
                    SignIN();
                }
                else if (mail.Contains("@") == false)
                {
                    AnsiConsole.MarkupLine("[red]Invalid email![/]");
                    SignIN();
                }
                else
                {
                    // Check if the user already exists
                    // Seraching user thorugh Mail a
                    //Validate password and Username
                    // Add the user to the database
                    // AddUserToDatabase(mail, username, password);
                    AnsiConsole.MarkupLine("[green]User added successfully![/]");
                }
                Panel();
            }
            
        }
       
       
    }
    static void LogIN()
    {
        while (true)
        {
            // Wyświetlenie opcji logowania
            var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter your [yellow]Password[/]:")
                    .PromptStyle("red")
                    .Secret());

            // Wyświetlenie opcji wyboru
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Choose an option:[/]")
                    .AddChoices(new[] { "Login", "Exit" })
                    .HighlightStyle(new Style(foreground: Color.Aqua)));

            if (option == "Exit")
            {
                AnsiConsole.MarkupLine("[red]Exiting the application...[/]");
                break; // Wyjście z pętli i zakończenie aplikacji
            }

            // Symulacja walidacji logowania (możesz zastąpić to własną logiką)
            if (ValidateLogin(username, password))
            {
                Panel();
                break;

            }
            else
            {
                AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
            }
        }
    }

    // Metoda symulująca walidację logowania
    static bool ValidateLogin(string username, string password)
    {
        // Przykładowa walidacja - zastąp to własną logiką
        return username == "admin" && password == "admin";
    }



   
}

