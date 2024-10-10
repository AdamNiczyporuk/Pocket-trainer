using Spectre.Console;
using System;

class Franek
{
    static void Main()
    {
        bool exit = false;
        string[] options = { "Opcja 1", "Opcja 2", "Opcja 3", "Wyj�cie" };
        int selectedIndex = 0;

        while (!exit)
        {
            Console.Clear();  // Czy�ci ekran za ka�dym razem

            int consoleWidth = Console.WindowWidth;

            // Renderowanie menu z pod�wietlon� ca�� lini� dla wybranej opcji
            for (int i = 0; i < options.Length; i++)
            {
                string optionText = options[i];
                int padding = (consoleWidth - optionText.Length) / 2;

                if (i == selectedIndex)
                {
                    // U�ywamy metody Markup, aby ustawi� t�o na bia�o i tekst na czarno dla wybranej linii
                    AnsiConsole.MarkupLine($"{new string(' ', padding)}[white on black]{optionText}[/]");
                }
                else
                {
                    // Opcje bez pod�wietlenia
                    AnsiConsole.MarkupLine($"{new string(' ', padding)}{optionText}");
                }
            }

            // Odczyt klawiszy od u�ytkownika (strza�ki g�ra/d�)
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
                    Console.WriteLine($"Wybra�e�: {options[selectedIndex]}");

                    // Sprawdzenie, czy wybrano opcj� wyj�cia
                    if (options[selectedIndex] == "Wyj�cie")
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Naci�nij dowolny klawisz, aby wr�ci� do menu...");
                        Console.ReadKey();
                    }
                    break;
            }
        }
    }
}
