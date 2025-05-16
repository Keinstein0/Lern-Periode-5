using Microsoft.Data.Sqlite;

namespace vocabWithDB
{
    public partial class Form1 : Form
    {
        public SqliteConnection connection;

        
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=..\\..\\..\\words.db";
            connection = new SqliteConnection(connectionString);
            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string selectQuery = "SELECT * FROM words";
            SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection);
            SqliteDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                string german = reader["German"].ToString();
                string japanese = reader["Japanese"].ToString();
                int id = int.Parse(reader["id"].ToString());

                Question myQuestion = new Question(german, japanese, this, id);
                myQuestion.ShowDialog();
            }
        }
    }
}
