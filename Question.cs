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
        string japanese;
        Form1 parent;
        int id;
        public Question(string german, string japanese, Form1 parent, int id)
        {
            InitializeComponent();
            this.german = german;
            this.japanese = japanese;
            this.parent = parent;
            this.id = id;
            label1.Text = $"What's {german} in Japanese?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string answer = textBox1.Text;
            if (answer == japanese)
            {
                MessageBox.Show("Correct");
                string updateQuery = $"UPDATE words SET right = right + 1 WHERE id = {id}";
                SqliteCommand selectCmd = new SqliteCommand(updateQuery, parent.connection);
                selectCmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Wrong");
            }

            this.Close();
        }
    }
}
