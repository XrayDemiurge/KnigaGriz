using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using MySqlConnector;
using System.Windows.Forms;



namespace Проект_Нежурин_Дакуко__Бибилотека_
{

    public class bookFromBD
    {
        public int idbooks { get; set; }
        public string nameBook { get; set; }
        public string nameAuthor { get; set; }
        public string genre { get; set; }
        public string ageOfBook { get; set; }
        public string bookStatus { get; set; }

    }

    public class DataBase
    {
        // Переменная для подключения к БД
        MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection("server=mysql.joinserver.xyz;database=s410037_NKEiVT3;user=u410037_k64ns7mW31;password=gZxp@ULU.7.s+UGxvbA8M@4D;Pooling=true;");

        //Функция подключения БД (общая)
        public void openConn()
        {
            conn = new MySqlConnector.MySqlConnection("server=mysql.joinserver.xyz;database=s410037_NKEiVT3;user=u410037_k64ns7mW31;password=gZxp@ULU.7.s+UGxvbA8M@4D;Pooling=true;");
            while (true)
            {
                try { conn.Open(); break; }
                catch { }
            }
        }
        //Функция отключения от БД
        public void closeConn()
        {
            conn.Close();
        }
        //Функция возвращающая подключение
        public MySqlConnector.MySqlConnection getConn()
        {
            return conn;
        }
        //Функция проверяющая есть ли данные в БД
        public bool BDIsEmpty()
        {
            openConn();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("SELECT * FROM Nezhurin_Dakuko_Proect_340;", getConn());
            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["idbooks"] == null) { return true; }
            }
            closeConn();
            return false;
        }
        //Функция находящая колличество книг в БД
        public int LastBDNum()
        {
            int maxVal = 0;
            openConn();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("SELECT * FROM Nezhurin_Dakuko_Proect_340;", getConn());
            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["idbooks"] != null)
                    {
                        maxVal += 1;
                    }
                }
                closeConn();
                return maxVal;
        }
        //Функция находящая самое последнее название в БД
        public string LastBDName()
        {
            string lastNameBook = "";
            openConn();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("SELECT * FROM Nezhurin_Dakuko_Proect_340;", getConn());
            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader["nameBook"] != null)
                {
                    lastNameBook = (string)reader["nameBook"];
                }
            }
            closeConn();
            return lastNameBook;
            
        }
        //Функция создания list с классами которые несут в себе переменные из бд (ВАЖНО! - Сама функция не орткрываеть подключение и не закрывает его, обязательно требует комбинации с другими функц.)
        public List<bookFromBD> CreateLitOFBD()
        {
            openConn();
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("SELECT * FROM Nezhurin_Dakuko_Proect_340;", getConn());
            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();
            List<bookFromBD> books = new List<bookFromBD>();
            while (reader.Read())
            {
                bookFromBD bookFromBD = new bookFromBD();

                bookFromBD.idbooks = (int)reader["idbooks"];
                bookFromBD.nameBook = (string)reader["nameBook"];
                bookFromBD.nameAuthor = (string)reader["nameAuthor"];
                bookFromBD.genre = (string)reader["genre"];
                bookFromBD.ageOfBook = (string)reader["ageOfBook"];
                bookFromBD.bookStatus = (string)reader["bookStatus"];

                books.Add(bookFromBD);
            }
            closeConn();
            return books;
        }
    }
}

