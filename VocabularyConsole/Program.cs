using Vocabulary;

if (args.Length > 0)
{
    string function = args[0].ToLower();

    switch (function)
    {
        case "-lists": FunctionLists(args[1..]); break;
        case "-new": FunctionNew(args[1..]); break;
        case "-add": FunctionAdd(args[1..]); break;
        case "-remove": FunctionRemove(args[1..]); break;
        case "-words": FunctionWords(args[1..]); break;
        case "-count": FunctionCount(args[1..]); break;
        case "-practice": FunctionPractice(args[1..]); break;
        default: PrintArgsHelp(); break;
    }
}
else PrintArgsHelp();

void FunctionLists(string[] args)
{
    if (args.Length == 0)
    {
        string[] lists = WordList.GetLists();
        if (lists.Length > 0)
        {
            Console.WriteLine("Available lists:");
            Console.WriteLine(string.Join("\n", lists));
        }
        else Console.WriteLine("No available lists.");

        Console.WriteLine();
    }
    else Console.WriteLine("Usage:\n-lists\n");
}

void FunctionNew(string[] args)
{
    try
    {
        if (args.Length >= 3)
        {
            string name = args[0];
            string[] languages = args[1..];

            WordList wordList = new(name, languages);
            wordList.Save();

            FunctionAdd(new string[] { name });
        }
        else Console.WriteLine("Usage:\n-new <listname> <language 1> <language 2> .. {langauge n}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FunctionAdd(string[] args)
{
    try
    {
        if (args.Length == 1)
        {
            string name = args[0];

            WordList wordList = WordList.LoadList(name);

            bool done = false;

            do
            {
                List<string> translations = new();

                foreach (string lang in wordList.Languages)
                {
                    Console.Write($"Enter word in ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(lang);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(": ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        done = true;
                        break;
                    }
                    else translations.Add(input);
                    
                    Console.WriteLine();
                }

                if (translations.Count == wordList.Languages.Length)
                {
                    wordList.Add(translations.ToArray());
                }

            } while (!done);

            wordList.Save();
        }
        else Console.WriteLine("Usage:\n-add <listname>\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FunctionRemove(string[] args)
{
    try
    {
        if (args.Length >= 3)
        {
            string name = args[0];

            WordList wordList = WordList.LoadList(name);

            string language = args[1].ToLower();
            int languageId = Array.IndexOf(wordList.Languages, language);

            string[] wordsToRemove = args[2..];

            foreach (string word in wordsToRemove)
            {
                if (wordList.Remove(languageId, word))
                {
                    Console.WriteLine($"Word \"{word}\" deleted succeeccfully.");
                }
                else
                {
                    Console.WriteLine($"Word \"{word}\" did not exist for language {language}.");
                }
            }
        }
        else Console.WriteLine("Usage:\n-remove <listname> <language> <word 1>..{word n}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FunctionWords(string[] args)
{
    try
    {
        if (args.Length > 0)
        {
            string name = args[0];

            WordList wordList = WordList.LoadList(name);

            int sort;
            if (args.Length == 2)
            {
                string language = args[1].ToLower();
                sort = Array.IndexOf(wordList.Languages, language);
            }
            else sort = 0;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(string.Join("\t", wordList.Languages));
            Console.ForegroundColor = ConsoleColor.Gray;
            wordList.List(sort, x => Console.WriteLine(string.Join("\t", x)));
            Console.WriteLine();
        }
        else Console.WriteLine("Usage:\n-words <listname> {sortByLanguage}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FunctionCount(string[] args)
{
    try
    {
        if (args.Length == 1)
        {
            string name = args[0];
            WordList wordList = WordList.LoadList(name);

            Console.WriteLine($"{wordList.Count} words in the list {name}.");
            Console.WriteLine();
        }
        else Console.WriteLine("Usage:\n-count <listname>\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FunctionPractice(string[] args)
{
    try
    {
        if (args.Length == 1)
        {
            string name = args[0];
            WordList wordList = WordList.LoadList(name);

            int totalWords = 0;
            int correctWords = 0;

            Console.WriteLine("Practice Words");
            Console.WriteLine();

            bool done = false;
            do
            {
                Word practiceWord = wordList.GetWordToPractice();

                string guessLang = wordList.Languages[practiceWord.FromLanguage];
                string guessWord = practiceWord.Translations[practiceWord.FromLanguage];

                string answerLang = wordList.Languages[practiceWord.ToLanguage];
                string answerWord = practiceWord.Translations[practiceWord.ToLanguage];

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"Translate the ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(guessLang);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($" word ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(guessWord);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" into ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(answerLang);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(": ");

                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    totalWords++;

                    if (input.ToLower() == answerWord)
                    {
                        correctWords++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("That's correct!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Incorrect, the word is {answerWord}");
                    }
                }
                else done = true;
            } while (!done);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"Given the {totalWords} words you tried,");
            Console.WriteLine($"you answered {correctWords} correctly,");
            Console.WriteLine($"that's a success rate of {(float)correctWords / totalWords * 100:f0}%.");
            Console.WriteLine();
        }
        else Console.WriteLine("Usage:\n-practice <listname>\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void PrintArgsHelp()
{
    Console.WriteLine("Application supports the following arguments:");
    Console.WriteLine("-lists");
    Console.WriteLine("-new <listname> <language 1> <language 2> .. {langauge n}");
    Console.WriteLine("-add <listname>");
    Console.WriteLine("-remove <listname> <language> <word 1> .. {word n}");
    Console.WriteLine("-words <listname> {sortByLanguage}");
    Console.WriteLine("-count <listname>");
    Console.WriteLine("-practice <listname>");
    Console.WriteLine();
}
