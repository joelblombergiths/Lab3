using Vocabulary;

try
{
    if (args.Length > 0)
    {
        string function = args[0].ToLower();

        switch (function)
        {
            case "-lists":
                Lists(args[1..]);
                break;
            case "-new":
                New(args[1..]);
                break;
            case "-add":
                Add(args[1..]);
                break;
            case "-remove":
                Remove(args[1..]);
                break;
            case "-words":
                Words(args[1..]);
                break;
            case "-count":
                Count(args[1..]);
                break;
            case "-practice":
                Practice(args[1..]);
                break;
            default:
                PrintArgsHelp();
                break;
        }
    }
    else PrintArgsHelp();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();

//--- Functions

void PrintArgsHelp()
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

void Lists(string[] args)
{
    if (args.Length != 0) 
        throw new ArgumentException("Usage:\n-lists");

    string[] lists = WordList.GetLists();

    Console.WriteLine("Available lists:");

    string result = lists.Length > 0
        ? string.Join("\n", lists)
        : "<None>";

    Console.WriteLine(result);
}

void New(string[] args)
{
    if (args.Length < 3) 
        throw new ArgumentException("Usage:\n-new <listname> <language 1> <language 2> .. {langauge n}");

    string name = args[0];

    if (WordList.GetLists().Contains(name))
    {
        Console.Write($"List \"{name}\" already exists. Overwrite? [yes/NO]: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) input = "no";

        if (input.ToLower().StartsWith("n")) return;
    }

    string[] languages = args[1..];

    WordList wordList = new(name, languages);
    wordList.Save();

    Add(new[] { name });
}

void Add(string[] args)
{
    if (args.Length != 1) 
        throw new ArgumentException("Usage:\n-add <listname>");

    string name = args[0];

    WordList wordList = WordList.LoadList(name);

    bool done = false;
    int addCount = 1;
    do
    {
        List<string> translations = new();

        foreach (string language in wordList.Languages)
        {
            Console.Write($"Enter new word #{addCount} in ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(language);
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

void Remove(string[] args)
{
    if (args.Length < 3)
        throw new ArgumentException("Usage:\n-remove <listname> <language> <word 1>..{word n}");

    string name = args[0];

    WordList wordList = WordList.LoadList(name);

    string language = args[1].ToLower();
    int languageId = Array.IndexOf(wordList.Languages, language);

    if (languageId < 0) 
        throw new KeyNotFoundException($"Language \"{language}\" does not exist in this WordList.");

    string[] wordsToRemove = args[2..];

    foreach (string word in wordsToRemove)
    {
        Console.WriteLine(wordList.Remove(languageId, word)
            ? $"Word \"{word}\" deleted successfully."
            : $"Word \"{word}\" did not exist for language {language}.");
    }

    wordList.Save();
}

void Words(string[] args)
{
    if (args.Length != 1 && args.Length != 2)
        throw new ArgumentException("Usage:\n-words <listname> {sortByLanguage}");

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

        if (sort < 0) 
            throw new KeyNotFoundException($"Language \"{language}\" does not exist in this WordList.");
    }

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine(string.Join("\t", wordList.Languages));

    Console.ForegroundColor = ConsoleColor.Gray;
    wordList.List(sort, word => Console.WriteLine(string.Join("\t", word)));
}

void Count(string[] args)
{
    if (args.Length != 1) 
        throw new ArgumentException("Usage:\n-count <listname>");

    string name = args[0];
    WordList wordList = WordList.LoadList(name);

    string result = wordList.Count > 0
        ? $"{wordList.Count} word{(wordList.Count > 1 ? "s" : string.Empty)} in the list {name}."
        : $"No words in list {name}.";

    Console.WriteLine(result);
}

void Practice(string[] args)
{
    if (args.Length != 1)
        throw new ArgumentException("Usage:\n-practice <listname>");

    string name = args[0];
    WordList wordList = WordList.LoadList(name);

    PracticeSession practiceSession = new();

    Console.WriteLine();
    Console.WriteLine($"Practice Words on list {name}");
    Console.WriteLine();

    do
    {
        Word practiceWord = wordList.GetWordToPractice();

        PrintPractice(practiceWord, wordList);

        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) break;

        PrintResult(practiceSession, practiceWord, input);
    } while (true);

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    Console.WriteLine($"Given the {practiceSession.Total} word{(practiceSession.Total > 1 ? "s" : string.Empty)} you tried,");
    Console.WriteLine($"you answered {practiceSession.Correct} correctly,");
    Console.WriteLine($"that's a success rate of {practiceSession.SuccessRatePercentage:f0}%.");
}


void PrintPractice(Word practiceWord, WordList wordList)
{
    string guessLang = wordList.Languages[practiceWord.FromLanguage];
    string guessWord = practiceWord.Translations[practiceWord.FromLanguage];

    string answerLang = wordList.Languages[practiceWord.ToLanguage];

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write("Translate the ");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write(guessLang);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write(" word ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(guessWord);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write(" into ");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write(answerLang);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write(": ");
}

void PrintResult(PracticeSession practiceResult, Word word, string guess)
{
    practiceResult.CurrentWord = word.Translations[word.ToLanguage];
    bool correctGuess = practiceResult.GuessWord(guess);

    Console.ForegroundColor = correctGuess
        ? ConsoleColor.Green
        : ConsoleColor.Red;

    string result = correctGuess
        ? "That's correct!"
        : $"Incorrect, the word is \"{practiceResult.CurrentWord}\"";

    Console.WriteLine(result);
}
