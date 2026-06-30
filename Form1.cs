using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using POE_PROG_YEAR_2.Data;

namespace POE_PROG_YEAR_2
{
    public partial class Form1 : Form
    {

        private string userName = "";
        private string saveTopic = "";
        private string favTopic = "";

        private bool waitingForReminder = false;
        private string pendingTitle = "";
        private string pendingDescription = "";
        
        public Form1()
        {
            InitializeComponent();
        }


        // Load the form. plays welcome sound and displays ASCII art
        private void Form1_Load(object sender, EventArgs e)
        {


            chatDisplay.Font = new Font("Courier New", 9);
            // Play welcome sound
            SoundPlayer welcomeSound = new SoundPlayer("Welcome sound.wav");
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




            chatDisplay.AppendText(asciiArt + "\n");
            chatDisplay.AppendText("===========================================================\n");
            chatDisplay.Font = new Font("Courier new", 9);

            userName = Microsoft.VisualBasic.Interaction.InputBox("What is your name?", "Welcome");
            chatDisplay.AppendText("Welcome, " + userName + "!\n");
            chatDisplay.AppendText("Ask me anything about cybersecurity. Type 'exit' to quit.\n");
            chatDisplay.AppendText("=================================================\n");

        }
      
        // Handles user input and reponse
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string input = userInput.Text.Trim().ToLower();

                // Check if bot is waiting for reminder
                if (waitingForReminder)
                {
                    string reminder = userInput.Text.Trim();
                    TaskRepository repo = new TaskRepository();
                    repo.AddTask(pendingTitle, pendingDescription, reminder);
                    chatDisplay.AppendText("CyberBot: Got it! I'll remind you - " + reminder + "\n\n");
                    waitingForReminder = false;
                    pendingTitle = "";
                    pendingDescription = "";
                    userInput.Clear();
                    return;
                }

                // Check if user wants to add a task
                if (input.Contains("add task"))
                {
                    pendingTitle = userInput.Text.Trim().Substring(9).Trim();
                    pendingDescription = "Cybersecurity task: " + pendingTitle;
                    waitingForReminder = true;
                    chatDisplay.AppendText("CyberBot: Task added with the description \"" + pendingDescription + "\". Would you like a reminder?\n\n");
                    userInput.Clear();
                    return;
                }

                // Check if user wants to view tasks
                if (input.Contains("view tasks") || input.Contains("show tasks"))
                {
                    TaskForm taskForm = new TaskForm();
                    taskForm.Show();
                    chatDisplay.AppendText("CyberBot: Opening your task list!\n\n");
                    userInput.Clear();
                    return;
                }

                // Check if user wants to start the quiz
                if (input.Contains("quiz") || input.Contains("start quiz") || input.Contains("test my knowledge"))
                {
                    QuizForm quizForm = new QuizForm();
                    quizForm.Show();
                    chatDisplay.AppendText("Cyber: Opening the Cybersecurity Quiz");
                    userInput.Clear();
                    return;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    chatDisplay.AppendText("CyberBot: Please type some before sending! \n\n");
                    return;
                }
                if (input.Length > 500)
                {
                    chatDisplay.AppendText("CyberBot: That's a very long message!");
                    userInput.Clear();
                    return;
                }

                if (input == "exit")
                {
                    chatDisplay.AppendText("CyberBot: Goodbye, " + userName + ": Stay safe online! \n");
                    Application.Exit();
                    return;
                }

                // Check if a user is sharing their favourite topic
                if (input.Contains("interested in"))
                {
                    if (input.Contains("phishing")) favTopic = "phishing";
                    else if (input.Contains("password")) favTopic = "password";
                    else if (input.Contains("safe browsing")) favTopic = "safe browsing";
                    else if (input.Contains("2fa") || input.Contains("two factor")) favTopic = "2fa";
                    else if (input.Contains("scam")) favTopic = "scam";
                    else if (input.Contains("privacy")) favTopic = "privacy";

                    chatDisplay.AppendText("You: " + userInput.Text + "\n");
                    chatDisplay.AppendText("CyberBot: Got it " + userName + "! I'll remember that you're interested in " + favTopic + ".\n\n");
                    userInput.Clear();
                    return;
                }

                // Check if user is asking for more info on the last topic
                if ((input.Contains("tell me more") || input.Contains("explain more") || input.Contains("give me another tip")) && saveTopic != "")
                {

                    ResponseQuestions bot2 = new ResponseQuestions();
                    string followUp = bot2.GetResponse(saveTopic, userName);
                    chatDisplay.AppendText("CyberBot: " + followUp + "\n\n");
                    userInput.Clear();
                    return;
                }
                string sentiment = GetSentiment(input);

                ResponseQuestions bot = new ResponseQuestions();
                string response = bot.GetResponse(input, userName);

                chatDisplay.AppendText("You: " + userInput.Text + "\n");
                chatDisplay.AppendText("CyberBot: " + sentiment + response + "\n\n");

                // Save the topic for follow-up questions
                if (input.Contains("phishing")) saveTopic = "phishing";
                else if (input.Contains("password")) saveTopic = "password";
                else if (input.Contains("safe browsing")) saveTopic = "safe browsing";
                else if (input.Contains("2fa") || input.Contains("two factor")) saveTopic = "2fa";
                else if (input.Contains("scam")) saveTopic = "scam";
                else if (input.Contains("privacy")) saveTopic = "privacy";

                userInput.Clear();
            }
            catch (Exception ex)
            {
                chatDisplay.AppendText("CyberBot: Something went wrong. Please try again\n\n");
            }
        }

        // Detects user sentiment
        private string GetSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
                return "I understand that you're feeling worried. ";

            else if (input.Contains("curious"))
                return "Great that you're curious about this! ";

            else if (input.Contains("frustrated") || input.Contains("confused"))
                return "I can see this is frustrating. Let me help you. ";

            else
                return "";
        }
    }
}
