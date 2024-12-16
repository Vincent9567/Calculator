using CalculatorLibrary;
using System.Text.RegularExpressions;
class Program
{
    private static void Main(string[] args)
    {
        bool runCalculator = true;

        while (runCalculator)
        {
            double[] numbersToCalculate = Calculator.UserInputNumber();

            CalculatorMainMenu();
            string userInput = HandleMainMenuSelection();

            if (userInput == "Q")
            {
                runCalculator = false;
            }
            else if (userInput == "P")
            {
                ProfileMenu();
            }
            else
            {
                Calculator.CalculateNumbers(numbersToCalculate, userInput);

                string continuePlaying = HandleContinue();

                if (continuePlaying == "Y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    runCalculator = false;
                }
            }
        }
    }

    public static void CalculatorMainMenu()
    {

        /*
         Create simple user interface using console write lines
        */

        Console.WriteLine(new string('*', 30));
        Console.WriteLine("WELCOME TO MY SHITTY CACULATOR");
        Console.WriteLine(new string('*', 30));

        Console.WriteLine("\nOptions");
        Console.WriteLine(new string('*', 40));
        Console.WriteLine("\nA - Addition");
        Console.WriteLine("S - Subtraction");
        Console.WriteLine("M - Multiplication");
        Console.WriteLine("D - Division");
        Console.WriteLine("P - Profile");
        Console.WriteLine(new string('*', 40));

        Console.WriteLine("\nQ - Quit Program (Fuck you too)");
    }


    public static void ProfileMenu()
    {
        Console.WriteLine(new string('*', 30));
        Console.WriteLine("Profile Menu");
        Console.WriteLine(new string('*', 30));
        Console.WriteLine("\nT - Times used");
        Console.WriteLine("L - Latest Calculations");

    }


    public static string HandleMainMenuSelection()
    {
        // Read and return user input 

        while (true)
        {
            Console.WriteLine("Please enter your selection:");
            string userSelection = Console.ReadLine();

            if (string.IsNullOrEmpty(userSelection) || !Regex.IsMatch(userSelection, @"^[ASDMQP]+$", RegexOptions.IgnoreCase))
            {
                // if input invalid display to use, wait for continue, clear console and redisplay Calculator main menu

                Console.WriteLine("Invalid Input. Please enter one of the menu options: A, S, M, D, Q");
                Console.WriteLine("Press any button to continue...");
                Console.ReadKey(true);
                (int left, int top) = Console.GetCursorPosition();
                ClearConsoleLines((top - 4), 8);
            }
            else
            {
                return userSelection.ToUpper();
            }
        }
    }

    public static string HandleContinue()
    {

        while (true)
        {
            Console.WriteLine("Continue? (y for yes n for no)");
            string userInput = Console.ReadLine();

            if (userInput.ToUpper() != "Y" && userInput.ToUpper() != "N")
            {
                Console.WriteLine("Only enter y for yes or n for no!");

            }
            else
            {
                return userInput.ToUpper();
            }

        }

    }

    public static void ClearConsoleLines(int startLine, int numberOfLines)
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            Console.SetCursorPosition(0, startLine + i);         // Move cursor to the line
            Console.Write(new string(' ', Console.WindowWidth)); // overwrite entire line with empty string
        }

        Console.SetCursorPosition(0, startLine);                 // place cursor back
    }



}

