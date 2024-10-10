﻿using Spectre.Console;
using System;

class Program
{
    static void Main()
    {
        int consoleWidth = Console.WindowWidth;
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
                        "Opcja 1", "Opcja 2", "Opcja 3", "Wyjście"
                    })
                    .HighlightStyle(new Style(foreground: Color.DarkMagenta_1)));

            // Obsługa wybranej opcji
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
}

