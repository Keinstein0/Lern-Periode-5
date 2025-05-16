using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        bool answerQuestion = false;

        public Question(string language, Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public void UpdateContent(string german, string foreign, string language)
        {
            this.german = german;
            this.foreign = foreign;
            label1.Text = $"What's {german} in {language}?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        async public void Answered()
        {
            while (true)
            {
                if (answerQuestion)
                {
                    return;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // your code here
            isAbort = true;

            base.OnFormClosing(e);
        }
    }
}
