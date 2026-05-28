using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace POE_PROG_YEAR_2
{
    public partial class Form1 : Form
    {

        private string userName = "";

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = userInput.Text.ToLower();

            if (string.IsNullOrWhiteSpace(input)) 
                return;

            chatDisplay.AppendText("You: " + userInput.Text + "\n");

            ResponseQuestions bot = new ResponseQuestions();
            string response = bot.GetResponse(input, userName);

            chatDisplay.AppendText("CyberBot: " + response + "\n");

            userInput.Clear();
            

        }


    }
}
