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
using System.Net.Http;
using System.Threading.Tasks;
using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;
using System.Security.Cryptography.X509Certificates;

namespace Проект_Нежурин_Дакуко__Бибилотека_
{
   

    public partial class MainPage : Form
    {
        //||||||||||||||||||||||||||| ОБЩИЕ ПЕРЕМЕННЫЕ |||||||||||||||||||||||||||\\


        //Создаем переменную для работы с классом БД

        DataBase database = new DataBase();
        //Создаем переменную для работы с формой CollectionPage
        public static CollectionPage CollectionPage = new CollectionPage();
        //Создаем переменную для работы с формой CustomLibrary
        public static customLibr customLib = new customLibr();
        public static string syrURl = "";
        //||||||||||||||||||||||||||| ИНИЦИАЛИЗАЦИЯ |||||||||||||||||||||||||||\\

        public MainPage()
        {
            InitializeComponent();
        }
        public void counter()
        {
           // label5.Text = Convert.ToString(database.LastBDNum());
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            string str = "spider";
            URLGiphy uRLGiphy = new URLGiphy();
            uRLGiphy.SearchGifsWithWrapperAsync(str);
            
            //Проверка на подключение к БД
            /*if (database.openConn() != true) { panelError.Visible = true; /*Делаем панель ошибки снова видимой };
            database.closeConn();*/

            counter();

            //Задаем цвет основному фону
            groupBox1.BackColor = Color.FromArgb(57, 100, 91);
            // Задаем цвета кнопкам
            buttonCust.BackColor = Color.FromArgb(143, 117, 172);
            buttonSee.BackColor = Color.FromArgb(143, 117, 172);
            buttonExitErr.BackColor = Color.FromArgb(143, 117, 172);
            buttonReconnect.BackColor = Color.FromArgb(143, 117, 172);
            // Задаем цвет label
            label1.ForeColor = Color.FromArgb(143, 117, 172);
            label2.ForeColor = Color.FromArgb(143, 117, 172);
            label3.ForeColor = Color.FromArgb(143, 117, 172);
            label10.ForeColor = Color.FromArgb(143, 117, 172);



            

            
        //https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExZGlndXJmNnF4dDI5bzM3anl6ejBqaW44MzRzYnphbDQ4Mmg4bjF3eiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/yd1THd3nDnWM8vhZWg/giphy.gif
        //https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExNmw1bTVzbHh2OHRpbjM3ZW5xb3ZwbTR6OHVqMzQ1aXJub3ZoaDllNSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/jPedd81XsIoF5LT3EV/giphy.gif
    }

        //||||||||||||||||||||||||||| НАВИГАЦИЯ |||||||||||||||||||||||||||\\

        //Функции для кнопкок из панели ошибки
        private void buttonReconnect_Click(object sender, EventArgs e)
        {
            database.openConn();
        }
        private void buttonExitErr_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Функция для перехода на форму просмотра
        private void buttonSee_Click(object sender, EventArgs e)
        {
            CollectionPage.Show();
            customLib.Hide();
        }
        //Функция для перехода на редактирования
        private void buttonDel_Click(object sender, EventArgs e)
        {
            customLib.Show();
            CollectionPage.Hide();
            MessageBox.Show(syrURl);
            pictureBox2.Load(syrURl);
        }

        private void panelError_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}


        

