using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
    
VocabManager vocabManager = new VocabManager();
ToastCreator toastCreator = new ToastCreator();
TimerService timerService = null;
VocabStorage vocabStorage = new VocabStorage();

        while (true)
        {
            Console.WriteLine("Vocabulary Manager Menu:");
            Console.WriteLine("1. Add Word");
            Console.WriteLine("2. List All Words");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. Random Word");
            Console.WriteLine("5. Remove Word");
            Console.WriteLine("6. Start Timer");
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

                // Block which displays a random word as a toast notification
                case "4":
                    Vocab word = vocabManager.GetRandomVocab();
                    var toast = new ToastContentBuilder()
                    .AddArgument("conversationId", 9813)
                    .AddText(word.Term)
                    .AddText(word.Definition);
                    toast.Show();
                    break;

                case "5":
                    Console.Write("Enter a word: ");
                    string wordToRemove = Console.ReadLine();
                    bool removed = vocabManager.RemoveVocab(new Vocab(wordToRemove, wordToRemove));
                    if (removed)
                    {
                        Console.WriteLine("Word removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Word not found!");
                    }
                    break;

                case "6":
                    if (timerService == null)
                    {
                        timerService = new TimerService(vocabManager);
                        Console.WriteLine("Timer started!");
                    }
                    else
                    {
                        Console.WriteLine("Timer is already running!");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

                
            }

            Console.WriteLine(); // Add a newline for readability
        }
    