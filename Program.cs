 VocabManager vocabManager = new VocabManager();

        while (true)
        {
            Console.WriteLine("Vocabulary Manager Menu:");
            Console.WriteLine("1. Add Word");
            Console.WriteLine("2. List All Words");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter a word: ");
                    string term = Console.ReadLine();
                    Console.Write("Enter its definition: ");
                    string definition = Console.ReadLine();
                    vocabManager.AddVocab(term, definition);
                    Console.WriteLine("Word added to vocabulary!");
                    break;

                case "2":
                    List<Vocab> vocabs = vocabManager.GetAllVocab();
                    Console.WriteLine("Vocabulary:");
                    foreach (Vocab vocab in vocabs)
                    {
                        Console.WriteLine($"{vocab.Term}: {vocab.Definition}");
                    }
                    break;

                case "3":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine(); // Add a newline for readability
        }
    