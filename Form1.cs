using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {

                string language = comboBox1.SelectedItem.ToString();
                string selectQuery = $"SELECT id, German,{language} FROM words";
                SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection);
                SqliteDataReader reader = selectCmd.ExecuteReader();


                string countQuery = "SELECT COUNT(*) FROM words";
                SqliteCommand command = new SqliteCommand(countQuery, connection);
                SqliteDataReader lengthReader = command.ExecuteReader();

                int wordListLength = 0;
                if (lengthReader.Read())
                {
                    wordListLength = lengthReader.GetInt32(0);
                }
                lengthReader.Close();


                Question myQuestion = new Question(language, wordListLength, this);


                while (reader.Read())
                {
                    string german = reader["German"].ToString();
                    string foreign = reader[language].ToString();
                    int id = int.Parse(reader["id"].ToString());

                    if (foreign == null || myQuestion.isAbort)
                    {
                        continue;
                    }

                    myQuestion.UpdateContent(german, foreign, language);
                    myQuestion.ShowDialog();
                    
                }

                reader.Close();
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Japanese":
                    Bitmap image = new Bitmap(@"..\..\..\..\vocabWithDB\Assets\csm_japan_ad7c57a369.png");
                    this.BackgroundImage = image;
                    break;
                case "english":
                    this.BackgroundImage = new Bitmap(@"..\..\..\..\vocabWithDB\Assets\London_1200x600.jpg");
                    break;
                case "french":
                    this.BackgroundImage = new Bitmap(@"..\..\..\..\vocabWithDB\Assets\french.png");
                    break;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
