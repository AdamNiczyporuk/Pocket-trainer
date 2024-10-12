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
        while (true) // Umożliwia wielokrotne próby logowania
        {
            // Wyświetlenie opcji logowania
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Wybierz opcję logowania:[/]")
                    .AddChoices(new[] { "Zaloguj się", "Exit" })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

            if (selection == "Exit")
            {
                AnsiConsole.MarkupLine("[red]Koniec programu.[/]");
                return; // Zakończenie programu
            }

            // Wprowadzenie nazwy użytkownika
            var username = AnsiConsole.Ask<string>("Wprowadź [yellow]nazwa użytkownika[/]:");
            if (username == "exit") // Sprawdzenie, czy użytkownik chce wyjść
            {
                AnsiConsole.MarkupLine("[red]Wyjście z logowania...[/]");
                return; // Zakończ proces logowania
            }

            // Wprowadzenie hasła
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("Wprowadź [yellow]hasło[/]:")
                    .PromptStyle("red")
                    .Secret()); // Maskowanie hasła

            // Walidacja logowania
            if (ValidateLogin(username, password))
            {
                AnsiConsole.MarkupLine("[green]Logowanie zakończone sukcesem![/]");
                // Tutaj możesz przejść do innej części programu
                View();
                return; // Możesz zwrócić do głównego menu lub zakończyć logowanie
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Niepoprawna nazwa użytkownika lub hasło! Spróbuj ponownie.[/]");
            }
        }
    }

    static bool ValidateLogin(string username, string password)
    {
        // Przykładowa walidacja logowania (możesz dostosować)
        return username == "admin" && password == "password123";
    }

    static void View()
    {
        // Logika panelu po zalogowaniu
        AnsiConsole.MarkupLine("[green]Witamy w panelu użytkownika![/]");
        // Dodaj dodatkową logikę dla użytkownika tutaj
    }

    static void Main()
    {
        StartMenu();
       
    }
}

