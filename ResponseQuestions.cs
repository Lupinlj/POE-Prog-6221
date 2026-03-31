class ResponseQuestions
{
    public void Questions(string name)
    {

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=== CyberBot ===");
        Thread.Sleep(3000);
        Console.WriteLine("Ask me anything! (Type exit to quit)");
        Console.WriteLine();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine().ToLower();

            if (input == "exit")
            {
                Console.WriteLine("Goodbye!");
                Console.WriteLine("===================================================");
                break;
            }

            ValidateInput(input, name);
        }
    }

    public void ValidateInput(string input, string name)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You didn't type anything! Please ask a question.");
            Thread.Sleep(1000);
            Console.WriteLine();
        }
        else if (input.Contains("how are you"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Im good thanks, How about you?");
            Thread.Sleep(3000);
            Console.WriteLine();
        }
        else if (input.Contains("what's your purpose"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("I'm here to help you stay safe online!");
            Thread.Sleep(3000);
            Console.WriteLine();
        }
        else if (input.Contains("what can i ask you about"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You can ask me anything related to cybersecurity");
            Thread.Sleep(3000);
            Console.WriteLine();
        }

        else if (input.Contains("password"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Great question, " + name + ": Here are some password tips...");
            Console.WriteLine("When you create an account somewhere, Use a strong and separate password for your email");
            Console.WriteLine("Create unusual passwords like combining three random words for example (BroWhatDog)");
            Console.WriteLine("Never create a password that are just numbers or letters like 1234/abcd. If you do make sure they are random like alstfnalks, but be careful since you might forget it. ");
            Thread.Sleep(3000);
            Console.WriteLine();

        }

        else if (input.Contains("phishing"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Phishing you say " + name + ": Dont click on any random link and dont trust people online!");
            Thread.Sleep(3000);
            Console.WriteLine();

        }

        else if (input.Contains("safe browsing"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Here are some safe browsing tips," + name + ": ");
            Console.WriteLine("1. Keep your browser and devices up to date. If your system is outdated is has a higher chance of being attacked.");
            Console.WriteLine("2. Make sure you use strong, unique passwords for every account you create");
            Console.WriteLine("3. Be cautious with links any any attachments on the internet. Phishing is one of the modern ways the hackers attack you");
            Thread.Sleep(3000);
            Console.WriteLine();
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I didn't understand that, try again.");
            Thread.Sleep(3000);
            Console.WriteLine();
        }

    }
}