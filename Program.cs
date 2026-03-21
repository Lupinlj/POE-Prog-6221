using System;
using System.Media;
class ProgramMain 
{
    static void Main(string[] args)
    {

        // Text change
        Console.Title = "CyberSecurity";
        Console.ForegroundColor = ConsoleColor.Green;


        SoundPlayer welcomeSound = new SoundPlayer("Welcome sound.wav");
        welcomeSound.PlaySync();
        welcomeSound.Load();
        welcomeSound.Play();

        string asciiArt = @"

                         __    _
                    _wr""""        ""-q__
                 _dP                 9m_
               _#P                     9#_
              d#@                       9#m
             d##                         ###
            J###                         ###L
            {###K                       J###K
            ]####K      ___aaa___      J####F
        __gmM######_  w#P""""   """"9#m  _d#####Mmw__
     _g##############mZ_         __g##############m_
   _d####M@PPPP@@M#######Mmp gm#########@@PPP9@M####m_
  a###""""          ,Z""#####@"" '######""\g          """"M##m
 J#@""             0L  ""*##     ##@""  J#              *#K
 #""               `#    ""_gmwgm_~    dF               `#_
7F                 ""#_   ]#####F   _dK                 JE
]                    *m__ ##### __g@""                   F
                       ""PJ#####LP""
 `                       0######_                      '
                       _0########_
     .               _d#####^#####m__              ,
      ""*w_________am#####P""   ~9#####mw_________w*""
          """"9@#####@M""""           """"P@#####@M""""

";

        Console.WriteLine(asciiArt);
        Console.WriteLine("===================================================");

        UserName user = new UserName();
        user.GetUsername();

        ResponseQuestions bot = new ResponseQuestions();
        bot.Questions();


        

    }
}

class UserName
{
    public void GetUsername()
    {
        Console.WriteLine("What is your name?");
        Console.WriteLine();
        String name = Console.ReadLine();
        Console.WriteLine("Welcome, " + name + ": ");
    }
}

class ResponseQuestions
{
    public void Questions()
    {
        while (true)
        {
            Console.WriteLine("Ask me anything! ");
            Console.WriteLine();
            string input = Console.ReadLine().ToLower();
            ValidateInput(input);
        }
    }

    public void ValidateInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("You didn't type anything! Please ask a question.");
            Console.WriteLine();
        }
        else if (input == "how are you")
        {
            Console.WriteLine("Im good thanks, How about you?");
            Console.WriteLine();
        }
        else if (input == "what's your purpose?")
        {
            Console.WriteLine("I'm here to help you stay safe online!");
            Console.WriteLine();
        }
        else if (input == "what can i ask you about? ")
        {
            Console.WriteLine("You can ask me anything related to cybersecurity");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("I didn't understand that, try again.");
            Console.WriteLine();
        }
    }

    
}
