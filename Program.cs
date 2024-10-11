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
                        "Opcja 1", "Opcja 2", "Opcja 3", "Wyjście"
                    })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

            // Obsługa wsybranej opcji
            switch (option)
            {
                case "Opcja 1":
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 1![/]");
                    break;
                case "Opcja 2":
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 2![/]");
                    break;
                case "Opcja 3":
                    AnsiConsole.MarkupLine("[green]Wybrałeś Opcję 3![/]");
                    break;
                case "Wyjście":
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
    static void LogIN()
    {
       
        // Display the login view
        var username = AnsiConsole.Ask<string>("Enter your [yellow]Username[/]:");

        // Hiding the password input
        var password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your [yellow]Password[/]:")
                .PromptStyle("red")
                .Secret());  // Mask the input for password

        // Simulating login validation (you can replace this with your own logic)
        if (ValidateLogin(username, password))
        {
            
            Panel();
            AnsiConsole.MarkupLine("[green]Login successful![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Invalid username or password![/]");
        }
    }
    static bool ValidateLogin(string username, string password)
    {
        // Replace with real login logic
        return username == "admin" && password == "admin";
    }

    static void Main()
    {
        StartMenu();
       
    }
}

