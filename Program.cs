namespace ConsoleApp2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random rand = new Random();

            
            string[] questions = new string[10]
            {
                "Azərbaycanın paytaxtı hansı şəhərdir?",
                "C#-da tam ədədləri saxlamaq üçün hansı tip istifadə olunur?",
                "2^5 neçəyə bərabərdir?",
                "Günəş sistemində ən böyük planet hansıdır?",
                "HTML nə üçün istifadə olunur?",
                "15 + 27 cəmi neçədir?",
                "C#-da ekrana mətn çıxarmaq üçün hansı metod işlədilir?",
                "Azərbaycanın dövlət dili hansıdır?",
                "Bir dəqiqədə neçə saniyə var?",
                "Xəzər dənizi hansı tip su hövzəsidir?"
            };

            
            string[,] options = new string[10, 3]
            {
                { "Bakı", "Gəncə", "Naxçıvan" },
                { "int", "string", "bool" },
                { "32", "25", "64" },
                { "Yupiter", "Mars", "Venera" },
                { "Veb səhifə strukturu", "Verilənlər bazası", "Əməliyyat sistemi" },
                { "42", "43", "32" },
                { "Console.WriteLine", "Console.Read", "Console.Clear" },
                { "Azərbaycan dili", "Türk dili", "İngilis dili" },
                { "60", "100", "30" },
                { "Qapalı su hövzəsi (göl)", "Açıq okean", "Boğaz" }
            };

            
            string[] correctAnswers = new string[10]
            {
                "Bakı",
                "int",
                "32",
                "Yupiter",
                "Veb səhifə strukturu",
                "42",
                "Console.WriteLine",
                "Azərbaycan dili",
                "60",
                "Qapalı su hövzəsi (göl)"
            };

            int score = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                
                string[] shuffledOptions = GetShuffledOptions(options, i, rand);

                Console.WriteLine($"\nSual {i + 1}: {questions[i]}");
                Console.WriteLine($"a) {shuffledOptions[0]}");
                Console.WriteLine($"b) {shuffledOptions[1]}");
                Console.WriteLine($"c) {shuffledOptions[2]}");

                string choice = GetValidChoice();
                int selectedIndex = ChoiceToIndex(choice);
                string chosenAnswer = shuffledOptions[selectedIndex];

                if (chosenAnswer == correctAnswers[i])
                {
                    score += 10;
                    PrintColoredMessage($"Doğrudur! Sizin seçiminiz: {choice}) {chosenAnswer} (+10 xal)", ConsoleColor.Green);
                }
                else
                {
                    score -= 10;
                    if (score < 0)
                    {
                        score = 0;
                    }
                    PrintColoredMessage($"Səhvdir! Düzgün cavab: {correctAnswers[i]} (-10 xal)", ConsoleColor.Red);
                }

                Console.WriteLine($"Cari xalınız: {score}");
            }

            Console.WriteLine("\n==========================================");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("==========================================");
        }

        
        static string[] GetShuffledOptions(string[,] allOptions, int questionIndex, Random rand)
        {
            string[] current = new string[3]
            {
                allOptions[questionIndex, 0],
                allOptions[questionIndex, 1],
                allOptions[questionIndex, 2]
            };

            
            for (int i = current.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                string temp = current[i];
                current[i] = current[j];
                current[j] = temp;
            }

            return current;
        }

        
        static string GetValidChoice()
        {
            while (true)
            {
                Console.Write("Variantı seçin (a, b, c): ");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    input = input.Trim().ToLower();
                    if (input == "a" || input == "b" || input == "c")
                    {
                        return input;
                    }
                }

                Console.WriteLine("Yalnız 'a', 'b' və ya 'c' daxil edin!");
            }
        }

        
        static int ChoiceToIndex(string choice)
        {
            if (choice == "a") return 0;
            if (choice == "b") return 1;
            return 2;
        }

        
        static void PrintColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}