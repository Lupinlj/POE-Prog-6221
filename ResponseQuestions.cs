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
        Console.WriteLine("===================================================");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        TypeText("\n=== CyberBot ===");
        Console.WriteLine("===================================================");
        Console.WriteLine();
        TypeText("Hello " + name + ", ask me anything! (Type exit to quit)");
        Console.WriteLine();
        

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "exit")
            {
                TypeText("Goodbye!");
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
            TypeText("You didn't type anything! Please ask a question.");
            Thread.Sleep(1000);
            Console.WriteLine();
        }
        else if (input.Contains("how are you"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("I'm good thanks, How about you?");
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
            TypeText("1. When you create an account somewhere, use a strong and separate password for your email");
            TypeText("2. Create unusual passwords like combining three random words for example (BroWhatDog)");
            TypeText("3. Never create a password that is just numbers or letters like 1234/abcd. If you do make sure they are random like alstfnalks, but be careful since you might forget it. ");
            Thread.Sleep(3000);
            Console.WriteLine();

        }

        else if (input.Contains("phishing"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("Phishing you say " + name + ": Don't click on any random link and don't trust people online!");
            TypeText("Phishing is a cyberattack where hackers will use fake websites or messages to trick their victims into giving them sensitive information.");
            TypeText("A user might receive a link thinking it's from a friend, but as soon as the user clicks on the link all sensitive information will be exposed.");
            Thread.Sleep(3000);
            Console.WriteLine();

        }

        else if (input.Contains("safe browsing"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("Here are some safe browsing tips," + name + ": ");
            TypeText("1. Keep your browser and devices up to date. If your system is outdated, it has a higher chance of being attacked.");
            TypeText("2. Make sure you use strong, unique passwords for every account you create");
            TypeText("3. Be cautious with links and any attachments on the internet. Phishing is one of the modern ways the hackers attack you");
            Thread.Sleep(3000);
            Console.WriteLine();
        }

        else if (input.Contains("2fa") || input.Contains("two factor"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText("Good question " + name + ": The following will tell you what you need to know about Two-Factor Authentication..." );
            TypeText("1. Two-Factor Authentication (2FA) requires two steps to log in. This is usually your password, as well as confirming a code that is sent to your email or phone number.");
            TypeText("2. Passwords alone won't keep your accounts secure. Hackers can steal your credentials through fake login pages or leaks from other sites. 2FA adds a second layer of protection, making it much harder for attackers to gain access");
            TypeText("3. 2FA makes it harder for attackers to access your account, even if they have your password. They will still need something that only you have access to. This could be a one-time code sent to your phone or email, a fingerprint scan, or facial recognition.");
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

    public string GetResponse(string input, string name)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "You didn't type anything! Please ask a question.";

        else if (input.Contains("how are you"))
            return "I'm good thanks, How about you?";

        else if (input.Contains("what's your purpose"))
            return "I'm here to help you stay safe online!";

        else if (input.Contains("what can i ask you about"))
            return "You can ask me anything related to cybersecurity";

        else if (input.Contains("password"))
            return "Great question, " + name + ": Here are some password tips..." +
                    "\n When you create an account somewhere, use a strong and separate password for your email" +
                    "\n Create unusual passwords like combining three random words for example (BroWhatDog)" +
                    "\n Never create a password that is just numbers or letters like 1234/abcd. If you do make sure they are random like alstfnalks, but be careful since you might forget it.";

        else if (input.Contains("phishing"))
        {
            string[] phishingResponse = {
                "Phishing you say " + name + ": Don't click on any random link and don't trust people online!",
                "\n Phishing is a cyberattack where hackers will use fake websites or messages to trick their victims into giving them sensitive information.",
                "\n A user might receive a link thinking it's from a friend, but as soon as the user clicks on the link all sensitive information will be exposed." };
            Random rand = new Random();
            return phishingResponse[rand.Next(phishingResponse.Length)];
        }

        else if (input.Contains("safe browsing"))
        {
            string[] safeBrowsingResponse = {
                "Here are some safe browsing tips, " + name + ": ",
                "\n Keep your browser and devices up to date. If your system is outdated, it has a higher chance of being attacked.",
                "\n Make sure you use strong, unique passwords for every account you create",
                "\n Be cautious with links and any attachments on the internet. Phishing is one of the modern ways the hackers attack you"};
            Random rand = new Random();
            return safeBrowsingResponse[rand.Next(safeBrowsingResponse.Length)];
        }

        else if (input.Contains("2fa") || input.Contains("two factor"))
        {
            string[] twoFactorResponse = {
                "Good question " + name + ": The following will tell you what you need to know about Two-Factor Authentication...",
                "\n Two-Factor Authentication (2FA) requires two steps to log in. This is usually your password, as well as confirming a code that is sent to your email or phone number.",
                "\n Passwords alone won't keep your accounts secure. Hackers can steal your credentials through fake login pages or leaks from other sites. 2FA adds a second layer of protection, making it much harder for attackers to gain access",
                "\n 2FA makes it harder for attackers to access your account, even if they have your password. They will still need something that only you have access to. This could be a one-time code sent to your phone or email, a fingerprint scan, or facial recognition."};
            Random rand = new Random();
            return twoFactorResponse[rand.Next(twoFactorResponse.Length)];
        }

        else if (input.Contains("scam"))
        {
            string[] scamResponses = {
                "Be aware of scams, " + name + "!\n1. When something sounds to good to be true, it probable is.",
                "\n Don't send strangers money or personal details online",
                "\n Verifiy the identity of anyone asking for senitive information." };
            Random rand = new Random();
            return scamResponses[rand.Next(scamResponses.Length)];
        }

        else if (input.Contains("privacy"))
        {
            string[] privacyReponses = {
                "Here are some privacy tips, " + name + ":\n1 Reviews privacy settings on all your social media accounts.",
                "\n Don't share personal information like your ID number or address online",
                "\n When you are using public WiFi, protect your data by using a VPN." };
            Random rand = new Random();
            return privacyReponses[rand.Next(privacyReponses.Length)];
        }


        else
            return "I didn't understand that, try again.";
    }
}