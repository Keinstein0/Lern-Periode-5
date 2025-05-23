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
        string german;
        string foreign;
        Form1 parent;
        int id;
        public bool isAbort = false;
        public bool isControlledExit = false;

        bool answerQuestion = false;
        int length;
        int counter;

        public Question(string language,int length, Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.length = length;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = length;
            progressBar1.Value = 0;



        }
        public async void UpdateContent(string german, string foreign, string language)
        {
            this.german = german;
            this.foreign = foreign;
            label1.Text = $"What's {german} in {language}?";

            progressBar1.Value = counter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            answerQuestion = true;
            string answer = textBox1.Text;
            if (answer == foreign)
            {
                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show("Wrong");
            }
            isControlledExit = true;
            Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // your code here
            if (!isControlledExit)
            {
                isAbort = true;
            }
            isControlledExit = false;

            base.OnFormClosing(e);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
