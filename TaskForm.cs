using POE_PROG_YEAR_2.Data;
using POE_PROG_YEAR_2.Models;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace POE_PROG_YEAR_2
{
    public class TaskForm : Form
    {
        // Controls for input
        private Label lblTitle;
        private Label lblDesc;
        private Label lblReminder;
        private TextBox txtTitle;
        private TextBox txtDesc;
        private TextBox txtReminder;

        // Buttons
        private Button btnAdd;
        private Button btnDelete;
        private Button btnComplete;
        private Button btnClose;

        // List to display tasks
        private ListView listTasks;

        public TaskForm()
        {
            this.Text = "Task Assistant";
            this.Size = new System.Drawing.Size(600, 500);
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            lblTitle = new Label();
            lblTitle.Text = "Task Title:";
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.ForeColor = System.Drawing.Color.Cyan;

            lblDesc = new Label();
            lblDesc.Text = "Description:";
            lblDesc.Location = new System.Drawing.Point(20, 60);
            lblDesc.ForeColor = System.Drawing.Color.Cyan;

            lblReminder = new Label();
            lblReminder.Text = "Reminder:";
            lblReminder.Location = new System.Drawing.Point(20, 100);
            lblReminder.ForeColor = System.Drawing.Color.Cyan;

            txtTitle = new TextBox();
            txtTitle.Location = new System.Drawing.Point(130, 20);
            txtTitle.Width = 400;

            txtDesc = new TextBox();
            txtDesc.Location = new System.Drawing.Point(130, 60);
            txtDesc.Width = 400;

            txtReminder = new TextBox();
            txtReminder.Location = new System.Drawing.Point(130, 100);
            txtReminder.Width = 400;

            btnAdd = new Button();
            btnAdd.Text = "Add Task";
            btnAdd.Location = new System.Drawing.Point(20, 140);
            btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnAdd.ForeColor = System.Drawing.Color.White;

            btnDelete = new Button();
            btnDelete.Text = "Delete Task";
            btnDelete.Location = new System.Drawing.Point(130, 140);
            btnDelete.BackColor = System.Drawing.Color.Red;
            btnDelete.ForeColor = System.Drawing.Color.White;

            btnComplete = new Button();
            btnComplete.Text = "Mark Complete";
            btnComplete.Location = new System.Drawing.Point(240, 140);
            btnComplete.Width = 120;
            btnComplete.BackColor = System.Drawing.Color.Green;
            btnComplete.ForeColor = System.Drawing.Color.White;

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new System.Drawing.Point(450, 140);
            btnClose.BackColor = System.Drawing.Color.Gray;
            btnClose.ForeColor = System.Drawing.Color.White;

            listTasks = new ListView();
            listTasks.Location = new System.Drawing.Point(20, 180);
            listTasks.Size = new System.Drawing.Size(550, 270);
            listTasks.View = View.Details;
            listTasks.FullRowSelect = true;
            listTasks.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            listTasks.ForeColor = System.Drawing.Color.White;
            listTasks.Columns.Add("ID", 40);
            listTasks.Columns.Add("Title", 150);
            listTasks.Columns.Add("Description", 200);
            listTasks.Columns.Add("Reminder", 100);
            listTasks.Columns.Add("Done", 50);

            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnComplete.Click += BtnComplete_Click;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblDesc);
            this.Controls.Add(lblReminder);
            this.Controls.Add(txtTitle);
            this.Controls.Add(txtDesc);
            this.Controls.Add(txtReminder);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnComplete);
            this.Controls.Add(btnClose);
            this.Controls.Add(listTasks);

            LoadTasks();
        }

        // Loads all tasks from the MySQL database into the list
        private void LoadTasks()
        {
            listTasks.Items.Clear();
            TaskRepository repo = new TaskRepository();
            List<TaskItem> tasks = repo.GetTaskItems();

            foreach (TaskItem task in tasks)
            {
                ListViewItem item = new ListViewItem(task.Id.ToString());
                item.SubItems.Add(task.Title);
                item.SubItems.Add(task.Description);
                item.SubItems.Add(task.Reminder);
                item.SubItems.Add(task.IsCompleted ? "Yes" : "No");
                listTasks.Items.Add(item);
            }
        }

        // Adds a new task using the values typed in the textboxes
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("Please enter a title and description.");
                return;
            }

            TaskRepository repo = new TaskRepository();
            repo.AddTask(txtTitle.Text, txtDesc.Text, txtReminder.Text);

            txtTitle.Clear();
            txtDesc.Clear();
            txtReminder.Clear();
            LoadTasks();
        }

        // Deletes the selected task
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a task first.");
                return;
            }

            int id = int.Parse(listTasks.SelectedItems[0].Text);
            TaskRepository repo = new TaskRepository();
            repo.DeleteTask(id);
            LoadTasks();
        }

        // Marks the selected task as completed
        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a task first.");
                return;
            }

            int id = int.Parse(listTasks.SelectedItems[0].Text);
            TaskRepository repo = new TaskRepository();
            repo.MarkComplete(id);
            LoadTasks();
        }
        
    }
}