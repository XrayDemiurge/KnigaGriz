using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Проект_Нежурин_Дакуко__Бибилотека_
{





    public partial class CollectionPage : Form
    {
        //||||||||||||||||||||||||||| ОБЩИЕ ПЕРЕМЕННЫЕ |||||||||||||||||||||||||||\\
        DataBase database = new DataBase();
        MainPage mainPage = new MainPage();
        int filterNum = 0;
        int delFiltNum = 0;
        bool filtEnable = false;
        bool filtWasDel = false;
        string[] filterStr = new string[8];


        int filterNumAge = 0;
        int delFiltNumAge = 0;
        bool filtEnableage = false;
        bool filtWasDelAge = false;
        string[] filterStrAge = new string[5];

        string btnChoose = "";

        //||||||||||||||||||||||||||| ИНИЦИАЛИЗАЦИЯ |||||||||||||||||||||||||||\\

        public CollectionPage()
        {
            InitializeComponent();
        }
        private void CollectionPage_Load(object sender, EventArgs e)
        {    
            //Задаем цвета элементам формы
            MainPage.CollectionPage.BackColor = Color.FromArgb(57, 100, 91);
            panelBoocks.BackColor = Color.FromArgb(132, 187, 165);
            panelInf.BackColor = Color.FromArgb(132, 187, 165);
            panelBookInf.BackColor = Color.FromArgb(132, 187, 165);
            textBoxFB.BackColor = Color.FromArgb(73, 67, 120);
            buttonMakeChange.BackColor = Color.FromArgb(143, 117, 172);
            buttonAdd.BackColor = Color.FromArgb(143, 117, 172);
            buttonReturn.BackColor = Color.FromArgb(143, 117, 172);
            buttonCustomPage.BackColor = Color.FromArgb(143, 117, 172);
            buttonFind.BackColor = Color.FromArgb(143, 117, 172);
            buttonfilt.BackColor = Color.FromArgb(143, 117, 172);

                addBooks();
        }


        //Функция добавляет обьекты несущие в себе информацию из БД
        public void addBooks()
        {
            panelBoocks.Controls.Clear();
            int pointY = 36;
            int pointX = 51;
            database.openConn();
            List<bookFromBD> books = database.CreateLitOFBD();
            for (int i = 0; i < books.Count; i++)
            {
                if (i > 0)
                {
                    pointY += 80;
                }
                else
                {
                    pointY = 36;
                }
                Button button = new Button();
                button.Name = "Book Nom-" + Convert.ToString(i+1);
                button.Text = "   " + "Название книги: " + books[i].nameBook.ToString() + "   " + "Имя автора: " + books[i].nameAuthor.ToString() + "   ";
                if (books[i].bookStatus.ToString() == "Finished")
                {
                    button.BackColor = Color.FromArgb(105, 169, 96);
                }
                if (books[i].bookStatus.ToString() == "DoNotStarted")
                {
                    button.BackColor = Color.FromArgb(130, 54, 66);
                }
                if (books[i].bookStatus.ToString() == "InProgress")
                {
                    button.BackColor = Color.FromArgb(199, 154, 95);
                }
                button.Width = 466;
                button.Height = 55;
                button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                button.ForeColor = Color.White;
                button.Location = new Point(pointX, pointY);
                button.Click += new System.EventHandler(this.newButtons);
                panelBoocks.Controls.Add(button);
            }
            database.closeConn();
        }
        //Функция для обработки клика по этим обьектам
        private void newButtons(object sender, EventArgs e)
        {
            Button butt = sender as Button;
            database.openConn();
            List<bookFromBD> books = database.CreateLitOFBD();
            for (int i = 0; i < books.Count; i++)
            {
                if (butt.Text == ("   " + "Название книги: " + books[i].nameBook.ToString() + "   " + "Имя автора: " + books[i].nameAuthor.ToString() + "   "))
                {
                    panelBookInf.Visible = true;

                    label5.Text = books[i].nameBook.ToString();
                    label6.Text = books[i].nameAuthor.ToString();
                    if (books[i].genre == "Horror")
                    {
                        label9.Text = "Хоррор";
                    }
                    if (books[i].genre == "Psychology")
                    {
                        label9.Text = "Психология";
                    }
                    if (books[i].genre == "Fantasy")
                    {
                        label9.Text = "Фантастика";
                    }
                    if (books[i].genre == "Detective")
                    {
                        label9.Text = "Детектив";
                    }
                    if (books[i].genre == "Classic")
                    {
                        label9.Text = "Классика";
                    }
                    if (books[i].genre == "Science")
                    {
                        label9.Text = "Научная";
                    }
                    if (books[i].genre == "Another")
                    {
                        label9.Text = "Другое";
                    }

                    if (books[i].ageOfBook == "adult")
                    {
                        label17.Text = "Взрослое";
                    }
                    if (books[i].ageOfBook == "Teenager")
                    {
                        label17.Text = "Подростковое";
                    }
                    if (books[i].ageOfBook == "Baby")
                    {
                        label17.Text = "Детское";
                    }
                    if (books[i].ageOfBook == "Any")
                    {
                        label17.Text = "Любой возраст";
                    }

                    if (books[i].bookStatus == "InProgress")
                    {
                        label12.Text = "В процессе";
                    }
                    if (books[i].bookStatus == "DoNotStarted")
                    {
                        label12.Text = "Не начата";
                    }
                    if (books[i].bookStatus == "Finished")
                    {
                        label12.Text = "Закончена";
                    }
                    btnChoose = Convert.ToString(books[i].idbooks);
                }
            }
            database.closeConn();
        }
       

        //NOT FINISHED
        private void buttonMakeChange_Click(object sender, EventArgs e)
        {
            
            if (InProgress.Checked == true) 
            {
                database.openConn();
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("UPDATE `s410037_NKEiVT3`.`Nezhurin_Dakuko_Proect_340` SET `bookStatus` = 'InProgress' WHERE (`idbooks` = '" + btnChoose + "');", database.getConn());
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();
            }
            if (DoNotStarted.Checked == true) 
            {
                database.openConn();
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("UPDATE `s410037_NKEiVT3`.`Nezhurin_Dakuko_Proect_340` SET `bookStatus` = 'DoNotStarted' WHERE (`idbooks` = '" + btnChoose + "');", database.getConn());
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();
            }
            if (Finished.Checked == true) 
            {
                database.openConn();
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("UPDATE `s410037_NKEiVT3`.`Nezhurin_Dakuko_Proect_340` SET `bookStatus` = 'Finished' WHERE (`idbooks` = '" +btnChoose+ "');", database.getConn());
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();
            }
            database.closeConn();
            panelBoocks.Controls.Clear();
            addBooks();
            DoNotStarted.Checked = false;
            InProgress.Checked = false;
            Finished.Checked = false;
            buttonMakeChange.Enabled = false;
            panelBookInf.Visible = false;
        }

        private void radioButtonStat_CheckedChanged(object sender, EventArgs e)
        {
            buttonMakeChange.Enabled = true;
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panelBoocks.VerticalScroll.Value = vScrollBar1.Value;
        }
        //||||||||||||||||||||||||||| ФИЛЬТРЫ И ПОИСК |||||||||||||||||||||||||||\\

        private void Horror_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = sender as System.Windows.Forms.CheckBox;
            if (checkBox.Checked == true)
            {
                if (filtWasDel == true) { filterStr[delFiltNum] = checkBox.Name; filtWasDel = false; }
                else
                {
                    filterStr[filterNum] = checkBox.Name;
                    filterNum++;
                }
            }
            else
            {
                for (int i = 0; i < filterStr.Length; i++)
                {
                    if (filterStr[i] == checkBox.Name)
                    {
                        filterStr[i] = "WasDel";
                        delFiltNum = i;
                        filtWasDel = true;
                    }
                }
            }
        }
        private void adult_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = sender as System.Windows.Forms.CheckBox;
            if (checkBox.Checked == true)
            {
                if (filtWasDelAge == true) { filterStrAge[delFiltNumAge] = checkBox.Name; filtWasDelAge = false; }
                else
                {
                    filterStrAge[filterNumAge] = checkBox.Name;
                    filterNumAge++;
                }
            }
            else
            {
                for (int i = 0; i < filterStrAge.Length; i++)
                {
                    if (filterStrAge[i] == checkBox.Name)
                    {
                        filterStrAge[i] = "WasDel";
                        delFiltNumAge = i;
                        filtWasDelAge = true;
                    }
                }
            }
        }
        private void buttonfilt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < filterStrAge.Length; i++)
            {
                if (filterStrAge[i] != null && filterStrAge[i] != "" && filterStrAge[i] != "WasDel")
                {
                    filtEnableage = true;
                }
            }
            for (int i = 0; i < filterStr.Length; i++)
            {
                if (filterStr[i] != null && filterStr[i] != "" && filterStr[i] != "WasDel")
                {
                    filtEnable = true;
                }
            }
            if (filtEnableage == true && filtEnable == true)
            {
                panelBoocks.Controls.Clear();
                bool FirstEt = true;
                int pointY = 36;
                int pointX = 51;
                database.openConn();
                List<bookFromBD> books = database.CreateLitOFBD();
                for (int i = 0; i < filterStrAge.Length; i++)
                {
                    for (int j = 0; j < books.Count; j++)
                    {
                        if (filterStrAge[i] == books[j].ageOfBook)
                        {
                            for (int k = 0; k < filterStr.Length; k++)
                            {
                                if (filterStr[k] == books[j].genre)
                                {
                                    if (FirstEt == false)
                                    {
                                        pointY += 80;
                                    }
                                    else
                                    {
                                        pointY = 36;
                                        FirstEt = false;
                                    }
                                    Button button = new Button();
                                    button.Name = "" + Convert.ToString(books[j].idbooks);
                                    button.Text = "   " + "Название книги: " + books[j].nameBook.ToString() + "   " + "Имя автора: " + books[j].nameAuthor.ToString() + "   ";
                                    if (books[j].bookStatus.ToString() == "Finished")
                                    {
                                        button.BackColor = Color.FromArgb(105, 169, 96);
                                    }
                                    if (books[j].bookStatus.ToString() == "DoNotStarted")
                                    {
                                        button.BackColor = Color.FromArgb(130, 54, 66);
                                    }
                                    if (books[j].bookStatus.ToString() == "InProgress")
                                    {
                                        button.BackColor = Color.FromArgb(199, 154, 95);
                                    }
                                    button.Width = 466;
                                    button.Height = 55;
                                    button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                                    button.ForeColor = Color.White;
                                    button.Location = new Point(pointX, pointY);
                                    button.Click += new System.EventHandler(this.newButtons);
                                    panelBoocks.Controls.Add(button);
                                }
                            }
                        }
                    } 
                }
                filtEnable = false;
                filtEnableage = false;
                database.closeConn();
                return;
            }
            if (filtEnableage == true && filtEnable == false)
            {
                panelBoocks.Controls.Clear();
                bool FirstEt = true;
                int pointY = 36;
                int pointX = 51;
                database.openConn();
                List<bookFromBD> books = database.CreateLitOFBD();
                for (int i = 0; i < filterStrAge.Length; i++)
                {
                    for (int j = 0; j < books.Count; j++)
                    {
                        if (filterStrAge[i] == books[j].ageOfBook)
                        {
                            if (FirstEt == false)
                            {
                                pointY += 80;
                            }
                            else
                            {
                                pointY = 36;
                                FirstEt = false;
                            }
                            Button button = new Button();
                            button.Name = "" + Convert.ToString(books[j].idbooks);
                            button.Text = "   " + "Название книги: " + books[j].nameBook.ToString() + "   " + "Имя автора: " + books[j].nameAuthor.ToString() + "   ";
                            if (books[j].bookStatus.ToString() == "Finished")
                            {
                                button.BackColor = Color.FromArgb(105, 169, 96);
                            }
                            if (books[j].bookStatus.ToString() == "DoNotStarted")
                            {
                                button.BackColor = Color.FromArgb(130, 54, 66);
                            }
                            if (books[j].bookStatus.ToString() == "InProgress")
                            {
                                button.BackColor = Color.FromArgb(199, 154, 95);
                            }
                            button.Width = 466;
                            button.Height = 55;
                            button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                            button.ForeColor = Color.White;
                            button.Location = new Point(pointX, pointY);
                            button.Click += new System.EventHandler(this.newButtons);
                            panelBoocks.Controls.Add(button);
                        }
                    }
                }
                filtEnable = false;
                filtEnableage = false;
                database.closeConn();
                return;
            }
            if (filtEnable == true && filtEnableage == false)
            {
                panelBoocks.Controls.Clear();
                bool FirstEt = true;
                int pointY = 36;
                int pointX = 51;
                database.openConn();
                List<bookFromBD> books = database.CreateLitOFBD();
                for (int i = 0; i < filterStr.Length; i++)
                {
                    for (int j = 0; j < books.Count; j++)
                    {
                        if (filterStr[i] == books[j].genre)
                        {
                            if (FirstEt == false)
                            {
                                pointY += 80;
                            }
                            else
                            {
                                pointY = 36;
                                FirstEt = false;
                            }
                            Button button = new Button();
                            button.Name = "" + Convert.ToString(books[j].idbooks);
                            button.Text = "   " + "Название книги:  " + books[j].nameBook.ToString() + "   " + "Имя автора:  " + books[j].nameAuthor.ToString() + "   ";
                            if (books[j].bookStatus.ToString() == "Finished")
                            {
                                button.BackColor = Color.FromArgb(105, 169, 96);
                            }
                            if (books[j].bookStatus.ToString() == "DoNotStarted")
                            {
                                button.BackColor = Color.FromArgb(130, 54, 66);
                            }
                            if (books[j].bookStatus.ToString() == "InProgress")
                            {
                                button.BackColor = Color.FromArgb(199, 154, 95);
                            }
                            button.Width = 466;
                            button.Height = 55;
                            button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                            button.ForeColor = Color.White;
                            button.Location = new Point(pointX, pointY);
                            button.Click += new System.EventHandler(this.newButtons);
                            panelBoocks.Controls.Add(button);
                        }
                    }
                }
                filtEnable = false;
                filtEnableage = false;
                database.closeConn();
                return;
            }
            if (filtEnable == false && filtEnableage == false)
            {
                addBooks();
                return;
            }

        }

         private void buttonFind_Click(object sender, EventArgs e)
         {
             panelBoocks.Controls.Clear();

             bool FirstEt = true;
             string findWord = textBoxFB.Text;
             database.openConn();
             List<bookFromBD> books = database.CreateLitOFBD();
             

            int pointY = 36;
            int pointX = 51;

            for (int i = 0; i < filterStrAge.Length; i++)
            {
                if (filterStrAge[i] != null && filterStrAge[i] != "" && filterStrAge[i] != "WasDel")
                {
                    filtEnableage = true;
                }
            }
            for (int i = 0; i < filterStr.Length; i++)
            {
                if (filterStr[i] != null && filterStr[i] != "" && filterStr[i] != "WasDel")
                {
                    filtEnable = true;
                }
            }

            for (int j = 0; j < books.Count; j++)
            {
                 if (books[j].nameBook.Substring(0, findWord.Length) == findWord)
                 {
                    if (filtEnableage == true && filtEnable == true)
                    {
                        for (int i = 0; i < filterStrAge.Length; i++)
                        {
                            if (filterStrAge[i] == books[j].ageOfBook)
                            {
                                for (int k = 0; k < filterStr.Length; k++)
                                {
                                    if (filterStr[k] == books[j].genre)
                                    {
                                        if (FirstEt == false)
                                        {
                                            pointY += 80;
                                        }
                                        else
                                        {
                                            pointY = 36;
                                            FirstEt = false;
                                        }
                                        Button button = new Button();
                                        button.Name = "" + Convert.ToString(books[j].idbooks);
                                        button.Text = "   " + "Название книги: " + books[j].nameBook.ToString() + "   " + "Имя автора: " + books[j].nameAuthor.ToString() + "   ";
                                        if (books[j].bookStatus.ToString() == "Finished")
                                        {
                                            button.BackColor = Color.FromArgb(105, 169, 96);
                                        }
                                        if (books[j].bookStatus.ToString() == "DoNotStarted")
                                        {
                                            button.BackColor = Color.FromArgb(130, 54, 66);
                                        }
                                        if (books[j].bookStatus.ToString() == "InProgress")
                                        {
                                            button.BackColor = Color.FromArgb(199, 154, 95);
                                        }
                                        button.Width = 466;
                                        button.Height = 55;
                                        button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                                        button.ForeColor = Color.White;
                                        button.Location = new Point(pointX, pointY);
                                        button.Click += new System.EventHandler(this.newButtons);
                                        panelBoocks.Controls.Add(button);
                                    }
                                }
                            }
                        }
                        database.closeConn();
                    }
                    if (filtEnableage == true && filtEnable == false)
                    {
                        for (int i = 0; i < filterStrAge.Length; i++)
                        {
                            if (filterStrAge[i] == books[j].ageOfBook)
                            {
                                if (FirstEt == false)
                                {
                                    pointY += 80;
                                }
                                else
                                {
                                    pointY = 36;
                                    FirstEt = false;
                                }
                                Button button = new Button();
                                button.Name = "" + Convert.ToString(books[j].idbooks);
                                button.Text = "   " + "Название книги: " + books[j].nameBook.ToString() + "   " + "Имя автора: " + books[j].nameAuthor.ToString() + "   ";
                                if (books[j].bookStatus.ToString() == "Finished")
                                {
                                    button.BackColor = Color.FromArgb(105, 169, 96);
                                }
                                if (books[j].bookStatus.ToString() == "DoNotStarted")
                                {
                                    button.BackColor = Color.FromArgb(130, 54, 66);
                                }
                                if (books[j].bookStatus.ToString() == "InProgress")
                                {
                                    button.BackColor = Color.FromArgb(199, 154, 95);
                                }
                                button.Width = 466;
                                button.Height = 55;
                                button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                                button.ForeColor = Color.White;
                                button.Location = new Point(pointX, pointY);
                                button.Click += new System.EventHandler(this.newButtons);
                                panelBoocks.Controls.Add(button);
                            }
                        }
                        database.closeConn();
                    }
                    if (filtEnableage == false && filtEnable == true)
                    {
                        for (int i = 0; i < filterStr.Length; i++)
                        {
                            if (filterStr[i] == books[j].genre)
                            {
                                if (FirstEt == false)
                                {
                                    pointY += 80;
                                }
                                else
                                {
                                    pointY = 36;
                                    FirstEt = false;
                                }
                                Button button = new Button();
                                button.Name = "" + Convert.ToString(books[j].idbooks);
                                button.Text = "   " + "Название книги: " + books[j].nameBook.ToString() + "   " + "Имя автора: " + books[j].nameAuthor.ToString() + "   ";
                                if (books[j].bookStatus.ToString() == "Finished")
                                {
                                    button.BackColor = Color.FromArgb(105, 169, 96);
                                }
                                if (books[j].bookStatus.ToString() == "DoNotStarted")
                                {
                                    button.BackColor = Color.FromArgb(130, 54, 66);
                                }
                                if (books[j].bookStatus.ToString() == "InProgress")
                                {
                                    button.BackColor = Color.FromArgb(199, 154, 95);
                                }
                                button.Width = 466;
                                button.Height = 55;
                                button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                                button.ForeColor = Color.White;
                                button.Location = new Point(pointX, pointY);
                                button.Click += new System.EventHandler(this.newButtons);
                                panelBoocks.Controls.Add(button);
                            }
                        }
                        database.closeConn();
                    }
                    if (filtEnableage == false && filtEnable == false)
                    {
                        if (FirstEt == false)
                        {
                            pointY += 80;
                        }
                        else
                        {
                            pointY = 36;
                            FirstEt = false;
                        }
                        Button button = new Button();
                        button.Name = "" + Convert.ToString(books[j].idbooks);
                        button.Text = "   " + "Название книги: " + books[j].nameBook.ToString() + "   " + "Имя автора: " + books[j].nameAuthor.ToString() + "   ";
                        if (books[j].bookStatus.ToString() == "Finished")
                        {
                            button.BackColor = Color.FromArgb(105, 169, 96);
                        }
                        if (books[j].bookStatus.ToString() == "DoNotStarted")
                        {
                            button.BackColor = Color.FromArgb(130, 54, 66);
                        }
                        if (books[j].bookStatus.ToString() == "InProgress")
                        {
                            button.BackColor = Color.FromArgb(199, 154, 95);
                        }
                        button.Width = 466;
                        button.Height = 55;
                        button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                        button.ForeColor = Color.White;
                        button.Location = new Point(pointX, pointY);
                        button.Click += new System.EventHandler(this.newButtons);
                        panelBoocks.Controls.Add(button);
                        filtEnable = false;
                        filtEnableage = false;
                        database.closeConn();
                    }


                }
            }            
        }

        //||||||||||||||||||||||||||| НАВИГАЦИЯ |||||||||||||||||||||||||||\\
        private void buttonCustomPage_Click(object sender, EventArgs e)
        {
            MainPage.customLib.Show();
            this.Hide();
        }
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBoxFB_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxFB.Text == "")
            {
                buttonfilt.Enabled = true;
                buttonFind.Enabled = false;
            }
            else
            {
                buttonfilt.Enabled = false;
                buttonFind.Enabled = true;
            }
        }
    }
}
