using Spectre.Console;
using System;
using System.Data;

class Program
{ 
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
                        "Add trening", "See Data", "Write Diet","Settings" ,"Exit"
                    })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

            // Obsługa wsybranej opcji
            switch (option)
            {
                case "Add trening":
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 1![/]");
                    break;
                case "See Data":
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 2![/]");
                    break;
                case "Settings":
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 3![/]");
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
        Console.Clear();
        var mail = AnsiConsole.Ask<string>("Enter your [yellow]E-mail[/]:");
        var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
        var password = AnsiConsole.Prompt(
                       new TextPrompt<string>("Enter your [yellow]Password[/]:")
                                      .PromptStyle("red")
                                                     .Secret());  // Mask the input for password
        Panel();

       
       
    }
    static void LogIN()
    {
        string username = string.Empty;
        string password = string.Empty;

        while (true)
        {
            // Kafelek dla nazwy użytkownika
            var usernamePanel = new Panel("[yellow]Enter your Username:[/]\n" + username)
            {
                Border = BoxBorder.Square,
                Header = new PanelHeader("Username"),
                Padding = new Padding(2)
            };
            AnsiConsole.Render(usernamePanel);

            // Kafelek dla hasła
            var passwordPanel = new Panel("[yellow]Enter your Password:[/]\n" + new string('*', password.Length))
            {
                Border = BoxBorder.Square,
                Header = new PanelHeader("Password"),
                Padding = new Padding(2)
            };
            AnsiConsole.Render(passwordPanel);

            // Kafelek dla opcji
            var exitPanel = new Panel("[yellow]Choose an option:[/]\n[green]1. Login[/]\n[red]2. Exit[/]")
            {
                Border = BoxBorder.Square,
                Header = new PanelHeader("Options"),
                Padding = new Padding(2)
            };
            AnsiConsole.Render(exitPanel);

            // Odczyt danych
            username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");
            password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter your [yellow]Password[/]:")
                    .PromptStyle("red")
                    .Secret());

            // Odczyt wyboru
            var choice = AnsiConsole.Ask<int>("Choose an option ([green]1[/] or [red]2[/]):");

            if (choice == 2) // Wyjście
            {
                AnsiConsole.MarkupLine("[red]Exiting the application...[/]");
                break; // Wyjście z pętli i zakończenie aplikacji
            }
            else if (choice == 1) // Logowanie
            {
                // Symulacja walidacji logowania
                if (ValidateLogin(username, password))
                {
                    AnsiConsole.MarkupLine("[green]Login successful![/]");
                    break; // Możesz tu dodać kod, który uruchamia aplikację po zalogowaniu
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Invalid option! Please choose 1 or 2.[/]");
            }

            // Czekaj na naciśnięcie klawisza przed powrotem do menu
            AnsiConsole.MarkupLine("[grey]Press any key to try again...[/]");
            Console.ReadKey(true);
            Console.Clear(); // Czyści konsolę przed kolejną próbą
        }
    }

 

    // Metoda symulująca walidację logowania
    static bool ValidateLogin(string username, string password)
    {
        // Przykładowa walidacja - zastąp to własną logiką
        return username == "admin" && password == "admin";
    }

   

    static void Main()
    {
        StartMenu();
       
    }
}

