using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new journal
        Journal journal = new Journal();
        
        // Create a prompt generator
        PromptGenerator promptGenerator = new PromptGenerator();
        
        bool running = true;
        while (running)
        {
            // Display menu
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            // Get user input
            string choice = Console.ReadLine();
            
            // Process user choice
            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Entry: ");
                    string entryText = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    
                    Entry newEntry = new Entry(date, prompt, entryText);
                    journal.AddEntry(newEntry);
                    break;
                    
                case "2":
                    // Display the journal
                    journal.DisplayAllEntries();
                    break;
                    
                case "3":
                    // Save the journal
                    Console.Write("Enter filename: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                    
                case "4":
                    // Load the journal
                    Console.Write("Enter filename: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                    
                case "5":
                    // Quit
                    running = false;
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine();
        }
        
        Console.WriteLine("Thank you for using the journal program!");
    }
}