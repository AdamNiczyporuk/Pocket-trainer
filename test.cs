using Spectre.Console;
using System;

class Franek
{
    static void Main()
    {
        bool exit = false;
        string[] options = { "Opcja 1", "Opcja 2", "Opcja 3", "Wyjœcie" };
        int selectedIndex = 0;

        while (!exit)
        {
            Console.Clear();  // Czyœci ekran za ka¿dym razem

            int consoleWidth = Console.WindowWidth;

            // Renderowanie menu z podœwietlon¹ ca³¹ lini¹ dla wybranej opcji
            for (int i = 0; i < options.Length; i++)
            {
                string optionText = options[i];
                int padding = (consoleWidth - optionText.Length) / 2;

                if (i == selectedIndex)
                {
                    // U¿ywamy metody Markup, aby ustawiæ t³o na bia³o i tekst na czarno dla wybranej linii
                    AnsiConsole.MarkupLine($"{new string(' ', padding)}[white on black]{optionText}[/]");
                }
                else
                {
                    // Opcje bez podœwietlenia
                    AnsiConsole.MarkupLine($"{new string(' ', padding)}{optionText}");
                }
            }

            // Odczyt klawiszy od u¿ytkownika (strza³ki góra/dó³)
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    Console.WriteLine($"Wybra³eœ: {options[selectedIndex]}");

                    // Sprawdzenie, czy wybrano opcjê wyjœcia
                    if (options[selectedIndex] == "Wyjœcie")
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Naciœnij dowolny klawisz, aby wróciæ do menu...");
                        Console.ReadKey();
                    }
                    break;
            }
        }
    }
}
