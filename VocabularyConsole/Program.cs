using Vocabulary;

if (args.Length > 0)
{
    string function = args[0].ToLower();

    switch (function)
    {
        case "-lists": FunctionLists(); break;
        case "-new": FunctionNew(args[1..^0]); break;
        case "-add": FunctionAdd(args[1..^0]); break;
        case "-remove": FunctionRemove(args[1..^0]); break;
        case "-words": FunctionWords(args[1..^0]); break;
        case "-count": FunctionCount(args[1..^0]); break;
        case "-practice": FunctionPractice(args[1..^0]); break;
        default: PrintArgsHelp(); break;
    }
}
else PrintArgsHelp();


void FunctionLists()
{
    Console.WriteLine(string.Join("\n", WordList.GetLists()));
}

void FunctionNew(string[] args)
{
    try
    {
        if (args.Length >= 3)
        {
            string name = args[0].ToLower();

            WordList wordList = new(name, args[1..^0]);
            wordList.Save();

            FunctionAdd(new string[] { name });
        }
        else Console.WriteLine("-new <listname> <language 1> <language 2> .. {langauge n}");
    }
    catch(Exception ex)
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
            string name = args[0].ToLower();

            WordList wordList = WordList.LoadList(name);

            bool done = false;
            string? input;
            do
            {
                List<string> translations = new();

                foreach (string lang in wordList.Languages)
                {
                    Console.Write($"Enter word in {lang}: ");
                    input = Console.ReadLine();

                    if(string.IsNullOrEmpty(input))
                    {
                        done = true;
                        break;
                    }
                    else translations.Add(input);                    
                }

                if(translations.Count == wordList.Languages.Length) wordList.Add(translations.ToArray());

            } while (!done);

            wordList.Save();
        }
        else Console.WriteLine("-add <listname>");
    }
    catch(Exception ex)
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
            string name = args[0].ToLower();

            WordList wordList = WordList.LoadList(name);

            string language = args[1].ToLower();
            int languageId = Array.IndexOf(wordList.Languages, language);

            foreach (string word in args[2..^0])
            {                
                if (wordList.Remove(languageId, word.ToLower())) Console.WriteLine($"Word {word} deleted succeeccfully.");
                else Console.WriteLine($"Word \"{word}\" did not exist for language {language}.");
            }
        }
        else Console.WriteLine("-remove <listname> <language> <word 1>..{word n}");
    }
    catch(Exception ex)
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
            string name = args[0].ToLower();

            WordList wordList = WordList.LoadList(name);

            int sort;
            if (args.Length == 2)
            {
                string language = args[1].ToLower();
                sort = Array.IndexOf(wordList.Languages, language);
            }
            else sort = 0;

            wordList.List(sort, x => Console.WriteLine(string.Join(":",x)));
        }
        else Console.WriteLine("-words <listname> {sortByLanguage}");
    }
    catch(Exception ex)
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
            string name = args[0].ToLower();
            WordList wordList = WordList.LoadList(name);

            Console.WriteLine($"{wordList.Count} words in the list {name}.");
        }
        else Console.WriteLine("-count <listname>");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void FunctionPractice(string[] args)
{
    Console.WriteLine("-practice <listname>");
}

static void PrintArgsHelp()
{
    Console.WriteLine("Application supports the following arguments:");
    Console.WriteLine("-lists");
    Console.WriteLine("-new <listname> <language 1> <language 2> .. {langauge n}");
    Console.WriteLine("-add <listname>");
    Console.WriteLine("-remove <listname> <language> <word>");
    Console.WriteLine("-words <listname> {sortByLanguage}");
    Console.WriteLine("-count <listname>");
    Console.WriteLine("-practice <listname>");
}

