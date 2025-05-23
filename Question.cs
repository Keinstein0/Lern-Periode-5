using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vocabWithDB
{
    public partial class Question : Form
    {
        // Defining word + translation
        string german;
        string foreign;

        // Utility info
        Form1 parent;
        int id;

        // Defining exit type
        public bool isAbort = false;
        public bool isControlledExit = false;

        // Defining current iteration (for progress bar)
        int length;
        int counter;

        public Question(string language,int length, Form1 parent)
        {
            InitializeComponent();

            this.parent = parent;

            // Progress bar info
            this.length = length;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = length;
            progressBar1.Value = 0;



        }
        public async void UpdateContent(string german, string foreign, string language)
        {
            // Set variables
            this.german = german;
            this.foreign = foreign;

            // Set components
            label1.Text = $"What's {german} in {language}?";
            progressBar1.Value = counter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;

            // Get answer
            string answer = textBox1.Text;

            if (answer == foreign)
            {
                MessageBox.Show($"Correct, it was {foreign}");
            }
            else
            {
                MessageBox.Show($"Wrong, right answer: {foreign}");
            }

            // Close window in controlled way
            isControlledExit = true;
            Close();

        }

        private void label1_Click(object sender, EventArgs e) { }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // If form preemptively closed abort all windows after and return to main menu
            if (!isControlledExit)
            {
                isAbort = true;
            }
            isControlledExit = false;

            base.OnFormClosing(e);
        }

        private void progressBar1_Click(object sender, EventArgs e) { }
    }
}
