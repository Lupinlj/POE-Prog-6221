using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using POE_PROG_YEAR_2.Models;

namespace POE_PROG_YEAR_2
{
    public partial class QuizForm : Form
    {
        // Controls
        private Label lblTitle = new Label();
        private Label lblQuestionNumber = new Label();
        private Label lblQuestion = new Label();
        private RadioButton rdb1 = new RadioButton();
        private RadioButton rdb2 = new RadioButton();
        private RadioButton rdb3 = new RadioButton();
        private RadioButton rdb4 = new RadioButton();
        private Button btnSubmit = new Button();
        private Button btnNext = new Button();
        private Label lblFeedback = new Label();
        private Label lblScore = new Label();

        // Quiz state
        private List<QuizQuestion> questions = new List<QuizQuestion>();
        private int currentIndex = 0;
        private int score = 0;
        private bool answered = false;

        public QuizForm()
        {
            BuildQuestions();
            BuildUI();
            LoadQuestion();
        }

        private void BuildQuestions()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    QuestionText = "What should you do if you receive an email asking for your password?",
                    Options = new List<string> { "A) Reply with your password", "B) Delete the email", "C) Report the email as phishing", "D) Ignore it" },
                    CorrectAnswer = "C) Report the email as phishing",
                    Explanation = "Reporting phishing emails helps prevent scams and protects others.",
                    IsTrueFalse = false
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Using the same password for multiple accounts is safe.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswer = "False",
                    Explanation = "Using the same password means one breach exposes all your accounts.",
                    IsTrueFalse = true
                },
                new QuizQuestion
                {
                    QuestionText = "What does HTTPS in a website URL indicate?",
                    Options = new List<string> { "A) The site is fast", "B) The site is encrypted and more secure", "C) The site is government-owned", "D) The site has no ads" },
                    CorrectAnswer = "B) The site is encrypted and more secure",
                    Explanation = "HTTPS uses SSL/TLS encryption to protect data between your browser and the server.",
                    IsTrueFalse = false
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Two-factor authentication adds an extra layer of security.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswer = "True",
                    Explanation = "2FA requires a second verification step, making unauthorized access much harder.",
                    IsTrueFalse = true
                },
                new QuizQuestion
                {
                    QuestionText = "Which of the following is the strongest password?",
                    Options = new List<string> { "A) password123", "B) MyDog2010", "C) Tr0ub4dor&3", "D) abc123" },
                    CorrectAnswer = "C) Tr0ub4dor&3",
                    Explanation = "Strong passwords mix uppercase, lowercase, numbers, and special characters.",
                    IsTrueFalse = false
                },
                new QuizQuestion
                {
                    QuestionText = "What is social engineering in cybersecurity?",
                    Options = new List<string> { "A) Building secure software", "B) Manipulating people into revealing confidential information", "C) Designing social media platforms", "D) Engineering better firewalls" },
                    CorrectAnswer = "B) Manipulating people into revealing confidential information",
                    Explanation = "Social engineering exploits human psychology rather than technical vulnerabilities.",
                    IsTrueFalse = false
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Public Wi-Fi is always safe to use for banking.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswer = "False",
                    Explanation = "Public Wi-Fi can be monitored by attackers. Use a VPN or avoid sensitive transactions.",
                    IsTrueFalse = true
                },
                new QuizQuestion
                {
                    QuestionText = "What should you do before clicking a link in an email?",
                    Options = new List<string> { "A) Click it immediately", "B) Forward it to friends", "C) Hover over it to verify the URL", "D) Reply to the sender" },
                    CorrectAnswer = "C) Hover over it to verify the URL",
                    Explanation = "Hovering reveals the actual destination URL, helping you spot phishing attempts.",
                    IsTrueFalse = false
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Antivirus software alone is enough to protect your computer.",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswer = "False",
                    Explanation = "Antivirus is one layer. You also need updates, strong passwords, and safe browsing habits.",
                    IsTrueFalse = true
                },
                new QuizQuestion
                {
                    QuestionText = "What is ransomware?",
                    Options = new List<string> { "A) Software that speeds up your PC", "B) Malware that encrypts files and demands payment", "C) A type of antivirus", "D) A secure backup tool" },
                    CorrectAnswer = "B) Malware that encrypts files and demands payment",
                    Explanation = "Ransomware locks your files and demands payment. Regular backups are your best protection.",
                    IsTrueFalse = false
                },
                new QuizQuestion
                {
                    QuestionText = "Which is a sign of a phishing email?",
                    Options = new List<string> { "A) Personalised greeting with your full name", "B) Urgent language and suspicious links", "C) Sent from a known contact", "D) Contains no attachments" },
                    CorrectAnswer = "B) Urgent language and suspicious links",
                    Explanation = "Phishing emails create urgency and link to fake sites designed to steal your credentials.",
                    IsTrueFalse = false
                }
            };
        }

        private void BuildUI()
        {
            this.Text = "Cybersecurity Quiz";
            this.Size = new Size(620, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 45);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblTitle.Text = "Cybersecurity Knowledge Quiz";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.Cyan;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(565, 35);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            lblQuestionNumber.Font = new Font("Segoe UI", 10);
            lblQuestionNumber.ForeColor = Color.LightGray;
            lblQuestionNumber.Location = new Point(20, 58);
            lblQuestionNumber.Size = new Size(565, 20);
            lblQuestionNumber.TextAlign = ContentAlignment.MiddleRight;

            lblQuestion.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblQuestion.ForeColor = Color.White;
            lblQuestion.Location = new Point(20, 85);
            lblQuestion.Size = new Size(565, 70);

            RadioButton[] rdbs = { rdb1, rdb2, rdb3, rdb4 };
            int y = 165;
            foreach (var rdb in rdbs)
            {
                rdb.Font = new Font("Segoe UI", 10);
                rdb.ForeColor = Color.White;
                rdb.BackColor = Color.Transparent;
                rdb.Location = new Point(30, y);
                rdb.Size = new Size(540, 28);
                y += 35;
            }

            btnSubmit.Text = "Submit Answer";
            btnSubmit.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSubmit.BackColor = Color.FromArgb(0, 120, 215);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Location = new Point(30, 310);
            btnSubmit.Size = new Size(150, 35);
            btnSubmit.Click += BtnSubmit_Click;

            btnNext.Text = "Next Question >";
            btnNext.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnNext.BackColor = Color.FromArgb(0, 160, 80);
            btnNext.ForeColor = Color.White;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(425, 310);
            btnNext.Size = new Size(150, 35);
            btnNext.Visible = false;
            btnNext.Click += BtnNext_Click;

            lblFeedback.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblFeedback.ForeColor = Color.LightGreen;
            lblFeedback.Location = new Point(20, 358);
            lblFeedback.Size = new Size(565, 90);

            lblScore.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblScore.ForeColor = Color.Gold;
            lblScore.Location = new Point(20, 460);
            lblScore.Size = new Size(565, 30);
            lblScore.Text = "Score: 0 / 0";

            this.Controls.AddRange(new Control[]
            {
                lblTitle, lblQuestionNumber, lblQuestion,
                rdb1, rdb2, rdb3, rdb4,
                btnSubmit, btnNext, lblFeedback, lblScore
            });
        }

        private void LoadQuestion()
        {
            if (currentIndex >= questions.Count)
            {
                ShowFinalScore();
                return;
            }

            answered = false;
            QuizQuestion q = questions[currentIndex];

            lblQuestionNumber.Text = $"Question {currentIndex + 1} of {questions.Count}";
            lblQuestion.Text = q.QuestionText;
            lblFeedback.Text = string.Empty;
            btnNext.Visible = false;
            btnSubmit.Visible = true;

            RadioButton[] rdbs = { rdb1, rdb2, rdb3, rdb4 };
            for (int i = 0; i < rdbs.Length; i++)
            {
                if (i < q.Options.Count)
                {
                    rdbs[i].Text = q.Options[i];
                    rdbs[i].Visible = true;
                    rdbs[i].Checked = false;
                    rdbs[i].ForeColor = Color.White;
                }
                else
                {
                    rdbs[i].Visible = false;
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (answered) return;

            RadioButton[] rdbs = { rdb1, rdb2, rdb3, rdb4 };
            string selected = string.Empty;

            foreach (var rdb in rdbs)
                if (rdb.Checked) { selected = rdb.Text; break; }

            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("Please select an answer before submitting.",
                    "No Answer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            answered = true;
            QuizQuestion q = questions[currentIndex];

            if (selected == q.CorrectAnswer)
            {
                score++;
                lblFeedback.ForeColor = Color.LightGreen;
                lblFeedback.Text = $"Correct!\n{q.Explanation}";
            }
            else
            {
                lblFeedback.ForeColor = Color.Salmon;
                lblFeedback.Text = $"Incorrect. Correct answer: {q.CorrectAnswer}\n{q.Explanation}";
            }

            lblScore.Text = $"Score: {score} / {currentIndex + 1}";

            foreach (var rdb in rdbs)
            {
                if (rdb.Text == q.CorrectAnswer) rdb.ForeColor = Color.LightGreen;
                else if (rdb.Checked) rdb.ForeColor = Color.Salmon;
            }

            btnSubmit.Visible = false;
            btnNext.Visible = true;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            LoadQuestion();
        }

        private void ShowFinalScore()
        {
            lblQuestion.Visible = false;
            rdb1.Visible = false; rdb2.Visible = false;
            rdb3.Visible = false; rdb4.Visible = false;
            btnSubmit.Visible = false;
            btnNext.Visible = false;
            lblQuestionNumber.Visible = false;

            double pct = (double)score / questions.Count * 100;
            string message = pct == 100 ? "Perfect score! You're a cybersecurity expert!"
                : pct >= 70 ? "Great job! You're a cybersecurity pro!"
                : pct >= 50 ? "Good effort! Keep learning to stay safe online!"
                : "Keep learning — every step counts!";

            lblFeedback.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblFeedback.ForeColor = Color.Gold;
            lblFeedback.Location = new Point(20, 130);
            lblFeedback.Size = new Size(565, 180);
            lblFeedback.TextAlign = ContentAlignment.MiddleCenter;
            lblFeedback.Text = $"Quiz Complete!\n\nYour Score: {score} / {questions.Count}\n\n{message}";

            Button btnRestart = new Button();
            btnRestart.Text = "Play Again";
            btnRestart.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRestart.BackColor = Color.FromArgb(0, 120, 215);
            btnRestart.ForeColor = Color.White;
            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.Location = new Point(230, 350);
            btnRestart.Size = new Size(150, 40);
            btnRestart.Click += (s, ev) =>
            {
                currentIndex = 0; score = 0; answered = false;
                lblQuestion.Visible = true;
                rdb1.Visible = true; rdb2.Visible = true;
                rdb3.Visible = true; rdb4.Visible = true;
                lblQuestionNumber.Visible = true;
                lblFeedback.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                lblFeedback.Location = new Point(20, 358);
                lblFeedback.Size = new Size(565, 90);
                lblFeedback.TextAlign = ContentAlignment.TopLeft;
                this.Controls.Remove(btnRestart);
                LoadQuestion();
            };
            this.Controls.Add(btnRestart);
        }
    }
}