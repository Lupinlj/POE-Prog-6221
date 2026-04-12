using System.Threading;
class ResponseQuestions
{

    public void TypeText(string message, int delay =30)
    {
       foreach(char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
    public void Questions(string name)
    {

        Console.ForegroundColor = ConsoleColor.Blue;
        TypeText("\n=== CyberBot ===");
        Thread.Sleep(3000);
        TypeText("Ask me anything! (Type exit to quit)");
        Console.WriteLine();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine().ToLower();

            if (input == "exit")
            {
                TypeText("Goodbye!");
                TypeText("===================================================");
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
            TypeText("You didn't type anything! Please ask a question.");
            Thread.Sleep(1000);
            Console.WriteLine();
        }
        else if (input.Contains("how are you"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("Im good thanks, How about you?");
            Thread.Sleep(3000);
            Console.WriteLine();
        }
        else if (input.Contains("what's your purpose"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("I'm here to help you stay safe online!");
            Thread.Sleep(3000);
            Console.WriteLine();
        }
        else if (input.Contains("what can i ask you about"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("You can ask me anything related to cybersecurity");
            Thread.Sleep(3000);
            Console.WriteLine();
        }

        else if (input.Contains("password"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("Great question, " + name + ": Here are some password tips...");
            TypeText("1. When you create an account somewhere, Use a strong and separate password for your email");
            TypeText("2. Create unusual passwords like combining three random words for example (BroWhatDog)");
            TypeText("3. Never create a password that are just numbers or letters like 1234/abcd. If you do make sure they are random like alstfnalks, but be careful since you might forget it. ");
            Thread.Sleep(3000);
            Console.WriteLine();

        }

        else if (input.Contains("phishing"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("Phishing you say " + name + ": Dont click on any random link and dont trust people online!");
            Thread.Sleep(3000);
            Console.WriteLine();

        }

        else if (input.Contains("safe browsing"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("Here are some safe browsing tips," + name + ": ");
            TypeText("1. Keep your browser and devices up to date. If your system is outdated is has a higher chance of being attacked.");
            TypeText("2. Make sure you use strong, unique passwords for every account you create");
            TypeText("3. Be cautious with links any any attachments on the internet. Phishing is one of the modern ways the hackers attack you");
            Thread.Sleep(3000);
            Console.WriteLine();
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TypeText("I didn't understand that, try again.");
            Thread.Sleep(3000);
            Console.WriteLine();
        }

    }
}