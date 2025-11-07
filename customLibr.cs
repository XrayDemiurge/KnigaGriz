using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Проект_Нежурин_Дакуко__Бибилотека_
{
    public partial class customLibr : Form
    {
        //||||||||||||||||||||||||||| ОБЩИЕ ПЕРЕМЕННЫЕ |||||||||||||||||||||||||||\\
        DataBase database = new DataBase();
        string buttonClicked = "";
        bool radBtn = false;
        bool modeChecked = false;
        MainPage mainPage = new MainPage();
        //||||||||||||||||||||||||||| ИНИЦИАЛИЗАЦИЯ |||||||||||||||||||||||||||\\

        public customLibr()
        {
            InitializeComponent();
        }
        //Задаем цвета элементам формы
        private void customLibr_Load(object sender, EventArgs e)
        {
            MainPage.customLib.BackColor = Color.FromArgb(57, 100, 91);
            textBoxAuthorName.BackColor = Color.FromArgb(73, 67, 120);
            textBoxBookName.BackColor = Color.FromArgb(73, 67, 120);
            textBoxSearch.BackColor = Color.FromArgb(73, 67, 120);
            buttonChangeMode.BackColor = Color.FromArgb(143, 117, 172);
            buttonReturn.BackColor = Color.FromArgb(143, 117, 172); 
            buttonAction.BackColor = Color.FromArgb(143, 117, 172);
            buttonToSeePage.BackColor = Color.FromArgb(143, 117, 172);
            buttonFind.BackColor = Color.FromArgb(143, 117, 172);
            panelBoocks.BackColor = Color.FromArgb(132, 187, 165);
                //panelZero.Visible = false;
                addBooks();
        }
        //Функция выводит в Panel обьекты несущие данные из БД
        private void addBooks()
        {
            int pointY = 11;
            int pointX = 22;
            List<bookFromBD> books = database.CreateLitOFBD();
            database.openConn();
            for (int i = 0; i < books.Count; i++)
            {
                if (i > 0)
                {
                    pointY += 61;
                }
                else
                {
                    pointY = 11;
                }
                Button button = new Button();
                button.Name = "" + Convert.ToString(books[i].idbooks);
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
                button.Width = 347;
                button.Height = 50;
                button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                button.ForeColor = Color.White;
                button.Location = new Point(pointX, pointY);
                button.Click += new System.EventHandler(this.delButton);
                panelBoocks.Controls.Add(button);
            }

            database.closeConn();
        }

        //||||||||||||||||||||||||||| ОСНОВЙНОЙ ФУНКЦИОНАЛ |||||||||||||||||||||||||||\\

        //Функция выбора обьетка
        private void delButton(object sender, EventArgs e) 
        {

            if(modeChecked == true)
            {
                if (buttonClicked != "")
                {
                    panelBoocks.Controls[buttonClicked].Enabled = true;
                }
                Button button = sender as Button;
                buttonClicked = button.Name;
                button.Enabled = false;
            }
        }

        //Полная функция для работы с основной кнопкой. Имеет ветвление, в режиме удаления кнопка удаляет выбранный обьект,
        //в режиме добавления, кнопка добавляет обьект по созданным характеристикам
        private void buttonAction_Click(object sender, EventArgs e)
        {
            if (modeChecked == false) 
            {
                bool NoInf = true;
                if (textBoxBookName.Text == "")
                {
                    label6.Visible = true;
                }
                else { label6.Visible = false; }
                if (textBoxAuthorName.Text == "")
                {
                    label10.Visible = true;
                }
                else { label10.Visible = false;}
                if (radBtn == false)
                {
                    label3.Visible = true;
                }
                else { label3.Visible = false;}

                if (textBoxBookName.Text != "" && textBoxAuthorName.Text != "" && radBtn != false)
                {
                    NoInf = false;
                }
                if (NoInf == false)
                {
                    string nameB = textBoxBookName.Text;
                    string nameAu = textBoxAuthorName.Text;
                    string genre = "";
                    if (radioButtonG1.Checked == true) { genre = "Psychology"; }
                    if (radioButtonG2.Checked == true) { genre = "Fantasy"; }
                    if (radioButtonG3.Checked == true) { genre = "Horror"; }
                    if (radioButtonG4.Checked == true) { genre = "Detective"; }
                    if (radioButtonG5.Checked == true) { genre = "Classic"; }
                    if (radioButtonG6.Checked == true) { genre = "Science"; }
                    if (radioButtonG7.Checked == true) { genre = "Another"; }
                    string age = "";
                    if (radioButtonA1.Checked == true) { age = "Baby"; }
                    if (radioButtonA2.Checked == true) { age = "Teenager"; }
                    if (radioButtonA3.Checked == true) { age = "Any"; }
                    if (radioButtonA4.Checked == true) { age = "adult"; }
                    if (age == "") { age = "Any"; }
                    string status = "";
                    if (radioButtonS1.Checked == true) { status = "InProgress"; }
                    if (radioButtonS2.Checked == true) { status = "Finished"; }
                    if (radioButtonS3.Checked == true) { status = "DoNotStarted"; }
                    if (status == "") { status = "DoNotStarted"; }
                    database.openConn();
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("INSERT INTO Nezhurin_Dakuko_Proect_340 (nameBook, nameAuthor, genre, ageOfBook, bookStatus) VALUES ('" + nameB + "', '" + nameAu + "', '" + genre + "', '" + age + "', '" + status + "');", database.getConn());
                    int reader = command.ExecuteNonQuery();
                    database.closeConn();
                    panelBoocks.Controls.Clear();
                    addBooks();
                    textBoxBookName.Text = string.Empty;
                    textBoxAuthorName.Text = string.Empty;
                    radioButtonG1.Checked = false; radioButtonG2.Checked = false; radioButtonG3.Checked = false; radioButtonG4.Checked = false; radioButtonG5.Checked = false; radioButtonG6.Checked = false; radioButtonG7.Checked = false;    
                    radioButtonA1.Checked = false; radioButtonA2.Checked = false; radioButtonA3.Checked = false; radioButtonA4.Checked = false;
                    radioButtonS1.Checked = false; radioButtonS2.Checked = false; radioButtonS3.Checked = false;
                    radBtn = false;
                    MainPage.CollectionPage.addBooks();
                    MainPage.CollectionPage.Refresh();
                    mainPage.counter();
                    mainPage.Refresh();
                }
            }
            if (modeChecked == true)
            {
                string buttonClicked2 = buttonClicked;
                buttonClicked = "";
                int idDel = Convert.ToInt32(buttonClicked2);
                database.openConn();
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("DELETE FROM s410037_NKEiVT3.Nezhurin_Dakuko_Proect_340 WHERE idbooks IN (" + buttonClicked2 + ");", database.getConn());
                int reader = command.ExecuteNonQuery();
                database.closeConn();
                panelBoocks.Controls.Clear();
                addBooks();
                MainPage.CollectionPage.addBooks();
                MainPage.CollectionPage.Refresh();
                mainPage.counter();
                mainPage.Refresh();
            }


        }
        //Проверка, включен ли хотябы один RadioBtn
        private void radioButtonG1_CheckedChanged(object sender, EventArgs e)
        {
            radBtn = true;
        }
        //Функция смены режима
        private void buttonChangeMode_Click(object sender, EventArgs e)
        {
            if (modeChecked == false) 
            {
                buttonAction.Text = "Удалить!";
                label13.Text = "Удаления";
                label13.ForeColor = Color.FromArgb(192, 0, 0);
                buttonChangeMode.Text = "Режим редактирования";
                modeChecked = true;
                label14.Visible = true;
                label15.Visible = true;
                panelAddBook.Visible = false;
                pictureBoxdel.Visible = true;
                pictureBoxNew.Visible = false;
            }
            else
            {
                buttonAction.Text = "Добавить!";
                label13.Text = "Добавления";
                label13.ForeColor = Color.FromArgb(0, 192, 0);
                buttonChangeMode.Text = "Режим удаления";
                modeChecked = false;
                label14.Visible = false;
                label15.Visible = false;
                panelAddBook.Visible = true;
                pictureBoxdel.Visible = false;
                pictureBoxNew.Visible = true;

            }
        }
        //Функция поиска
        private void buttonFind_Click(object sender, EventArgs e)
        {
            panelBoocks.Controls.Clear();
            bool FirstEt = true;
            string findWord = textBoxSearch.Text;
            if (textBoxSearch.Text == "") { addBooks(); return; }
            else
            {
                int pointY = 11;
                int pointX = 22;
                database.openConn();
                List<bookFromBD> books = database.CreateLitOFBD();
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].nameBook.Substring(0, findWord.Length) == findWord)
                    {
                        if (FirstEt == false)
                        {
                            pointY += 61;
                        }
                        else
                        {
                            pointY = 11;
                            FirstEt = false;
                        }
                        Button button = new Button();
                        button.Name = "" + Convert.ToString(books[i].idbooks);
                        button.Text = "   " + "Название книги:" + books[i].nameBook.ToString() + "   " + "Имя автора:" + books[i].nameAuthor.ToString() + "   ";
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
                        button.Width = 347;
                        button.Height = 50;
                        button.Font = new Font("Bahnschrift Condensed", 10, FontStyle.Regular, GraphicsUnit.Point);
                        button.ForeColor = Color.White;
                        button.Location = new Point(pointX, pointY);
                        button.Click += new System.EventHandler(this.delButton);
                        panelBoocks.Controls.Add(button);
                    }
                }
                database.closeConn();
            }
        }

        //||||||||||||||||||||||||||| НАВИГАЦИЯ |||||||||||||||||||||||||||\\

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void buttonToSeePage_Click(object sender, EventArgs e)
        {
            MainPage.CollectionPage.Show();
            this.Hide();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panelBoocks.VerticalScroll.Value = vScrollBar1.Value;
        }

        private void panelBoocks_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
