namespace Проект_Нежурин_Дакуко__Бибилотека_
{
    partial class MainPage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelError = new System.Windows.Forms.Panel();
            this.buttonExitErr = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonReconnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSee = new System.Windows.Forms.Button();
            this.buttonCust = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panelError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.panelError);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.buttonSee);
            this.groupBox1.Controls.Add(this.buttonCust);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(-10, -15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1474, 784);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.buttonExitErr);
            this.panelError.Controls.Add(this.label10);
            this.panelError.Controls.Add(this.buttonReconnect);
            this.panelError.Location = new System.Drawing.Point(23, 621);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(1445, 762);
            this.panelError.TabIndex = 15;
            this.panelError.Visible = false;
            this.panelError.Paint += new System.Windows.Forms.PaintEventHandler(this.panelError_Paint);
            // 
            // buttonExitErr
            // 
            this.buttonExitErr.BackColor = System.Drawing.Color.Black;
            this.buttonExitErr.FlatAppearance.BorderSize = 0;
            this.buttonExitErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitErr.Font = new System.Drawing.Font("Bahnschrift", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitErr.ForeColor = System.Drawing.Color.White;
            this.buttonExitErr.Location = new System.Drawing.Point(753, 487);
            this.buttonExitErr.Name = "buttonExitErr";
            this.buttonExitErr.Size = new System.Drawing.Size(585, 241);
            this.buttonExitErr.TabIndex = 2;
            this.buttonExitErr.Text = "Выйти";
            this.buttonExitErr.UseVisualStyleBackColor = false;
            this.buttonExitErr.Click += new System.EventHandler(this.buttonExitErr_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(315, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(823, 77);
            this.label10.TabIndex = 1;
            this.label10.Text = "Ошибка подключения к БД";
            // 
            // buttonReconnect
            // 
            this.buttonReconnect.BackColor = System.Drawing.Color.Black;
            this.buttonReconnect.FlatAppearance.BorderSize = 0;
            this.buttonReconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReconnect.Font = new System.Drawing.Font("Bahnschrift", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReconnect.ForeColor = System.Drawing.Color.White;
            this.buttonReconnect.Location = new System.Drawing.Point(142, 487);
            this.buttonReconnect.Name = "buttonReconnect";
            this.buttonReconnect.Size = new System.Drawing.Size(585, 241);
            this.buttonReconnect.TabIndex = 0;
            this.buttonReconnect.Text = "Попробовать снова";
            this.buttonReconnect.UseVisualStyleBackColor = false;
            this.buttonReconnect.Click += new System.EventHandler(this.buttonReconnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(749, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 45);
            this.label3.TabIndex = 14;
            this.label3.Text = "учета книг в домашней библиотеке";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.ImageLocation = "C:\\Users\\user\\Desktop\\Проект Нежурин Дакуко (Бибилотека) v1.0\\Проект Нежурин Даку" +
    "ко (Бибилотека)\\Resources\\cherv22.png";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(800, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(549, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSee
            // 
            this.buttonSee.BackColor = System.Drawing.Color.Black;
            this.buttonSee.FlatAppearance.BorderSize = 0;
            this.buttonSee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSee.Font = new System.Drawing.Font("Bahnschrift Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSee.ForeColor = System.Drawing.Color.White;
            this.buttonSee.Location = new System.Drawing.Point(757, 561);
            this.buttonSee.Name = "buttonSee";
            this.buttonSee.Size = new System.Drawing.Size(659, 157);
            this.buttonSee.TabIndex = 2;
            this.buttonSee.Text = "Просмотреть коллекцию";
            this.buttonSee.UseVisualStyleBackColor = false;
            this.buttonSee.Click += new System.EventHandler(this.buttonSee_Click);
            // 
            // buttonCust
            // 
            this.buttonCust.BackColor = System.Drawing.Color.Black;
            this.buttonCust.FlatAppearance.BorderSize = 0;
            this.buttonCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCust.Font = new System.Drawing.Font("Bahnschrift Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCust.ForeColor = System.Drawing.Color.White;
            this.buttonCust.Location = new System.Drawing.Point(78, 561);
            this.buttonCust.Name = "buttonCust";
            this.buttonCust.Size = new System.Drawing.Size(659, 157);
            this.buttonCust.TabIndex = 1;
            this.buttonCust.Text = "Редактировать коллекцию";
            this.buttonCust.UseVisualStyleBackColor = false;
            this.buttonCust.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(139, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(655, 119);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(390, 58);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ваша коллекция книг  =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(420, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 58);
            this.label5.TabIndex = 7;
            this.label5.Text = "0 книг.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(362, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Программа для автоматизации ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(131, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 115);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добро пожаловать в";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(78, 291);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1338, 242);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1456, 758);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainPage";
            this.Text = "Книга-Грыз v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonSee;
        private System.Windows.Forms.Button buttonCust;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Button buttonExitErr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonReconnect;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

