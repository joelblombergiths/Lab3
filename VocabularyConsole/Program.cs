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

Console.WriteLine();

//--- Functions

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
}

void FunctionLists(string[] args)
{
    if (args.Length != 0)
    {
        Console.WriteLine("Usage:\n-lists");
        return;
    }

    string[] lists = WordList.GetLists();
    if (lists.Length == 0)
    {
        Console.WriteLine("No available lists.");
        return;
    }

    Console.WriteLine("Available lists:");
    Console.WriteLine(string.Join("\n", lists));    
}

void FunctionNew(string[] args)
{
    try
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage:\n-new <listname> <language 1> <language 2> .. {langauge n}");
            return;
        }

        string name = args[0];
        string[] languages = args[1..];

        WordList wordList = new(name, languages);
        wordList.Save();

        FunctionAdd(new string[] { name });
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
        if (args.Length != 1)
        {
            Console.WriteLine("Usage:\n-add <listname>");
            return;
        }

        string name = args[0];

        WordList wordList = WordList.LoadList(name);

        bool done = false;

        int addCount = 1;
        do
        {
            List<string> translations = new();

            foreach (string lang in wordList.Languages)
            {
                Console.Write($"Enter new word #{addCount} in ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(lang);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(": ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    done = true;
                    addCount--;
                    break;
                }
                
                translations.Add(input);
            }

            if (translations.Count == wordList.Languages.Length)
            {
                wordList.Add(translations.ToArray());
                addCount++;
            }

            Console.WriteLine();

        } while (!done);

        if (addCount <= 0) 
        { 
            Console.WriteLine("No words added.");
            return;
        }

        wordList.Save();
        Console.WriteLine($"Added {addCount} word{(addCount > 1 ? "s" : string.Empty)} to list {name}.");
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
        if (args.Length < 3)
        {
            Console.WriteLine("Usage:\n-remove <listname> <language> <word 1>..{word n}");
            return;
        }

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

        wordList.Save();
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
        if (args.Length != 1 && args.Length != 2)
        {
            Console.WriteLine("Usage:\n-words <listname> {sortByLanguage}");
            return;
        }

        string name = args[0];

        WordList wordList = WordList.LoadList(name);

        if (wordList.Count <= 0)
        {
            Console.WriteLine($"No words in list {name}");
            return;
        }

        int sort = 0;
        if (args.Length == 2)
        {
            string language = args[1].ToLower();
            sort = Array.IndexOf(wordList.Languages, language);
        }
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(string.Join("\t", wordList.Languages));

        Console.ForegroundColor = ConsoleColor.Gray;
        wordList.List(sort, word => Console.WriteLine(string.Join("\t", word)));
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
        if (args.Length != 1)
        {
            Console.WriteLine("Usage:\n-count <listname>");
            return;
        }
 
        string name = args[0];
        WordList wordList = WordList.LoadList(name);

        if (wordList.Count <= 0)
        {
            Console.WriteLine($"No words in list {name}.");
            return;
        }
        
        Console.WriteLine($"{wordList.Count} {(wordList.Count > 1 ? "words" : "word")} in the list {name}.");
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
        if (args.Length != 1)
        {
            Console.WriteLine("Usage:\n-practice <listname>");
            return;
        }

        string name = args[0];
        WordList wordList = WordList.LoadList(name);

        int totalWords = 0;
        int correctWords = 0;

        Console.WriteLine();
        Console.WriteLine($"Practice Words on list {name}");
        Console.WriteLine();

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

            if (string.IsNullOrWhiteSpace(input)) break;

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
        } while (true);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine($"Given the {totalWords} words you tried,");
        Console.WriteLine($"you answered {correctWords} correctly,");
        Console.WriteLine($"that's a success rate of {(float)correctWords / totalWords * 100:f0}%.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
