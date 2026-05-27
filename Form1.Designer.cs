namespace POE_PROG_YEAR_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chatDisplay = new RichTextBox();
            userInput = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // chatDisplay
            // 
            chatDisplay.BackColor = Color.Black;
            chatDisplay.ForeColor = Color.Lime;
            chatDisplay.Location = new Point(10, 10);
            chatDisplay.Name = "chatDisplay";
            chatDisplay.Size = new Size(750, 350);
            chatDisplay.TabIndex = 0;
            chatDisplay.Text = "";
            // 
            // userInput
            // 
            userInput.BackColor = Color.Black;
            userInput.ForeColor = Color.Lime;
            userInput.Location = new Point(10, 370);
            userInput.Name = "userInput";
            userInput.Size = new Size(630, 23);
            userInput.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Lime;
            btnSend.ForeColor = Color.Black;
            btnSend.Location = new Point(650, 365);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(110, 35);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSend);
            Controls.Add(userInput);
            Controls.Add(chatDisplay);
            Name = "Form1";
            Text = "CyberSecurity ChatBot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox chatDisplay;
        private TextBox userInput;
        private Button btnSend;
    }
}