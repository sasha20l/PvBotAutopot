namespace PWForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            comboBox3 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            panel2 = new Panel();
            label8 = new Label();
            label7 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button4 = new Button();
            button3 = new Button();
            mpAddr = new TextBox();
            maxMpAddr = new TextBox();
            xpAddr = new TextBox();
            maxXpAddr = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(203, 22);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(288, 319);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(497, 22);
            button1.Name = "button1";
            button1.Size = new Size(140, 39);
            button1.TabIndex = 1;
            button1.Text = "Добавить макрос";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(225, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(41, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Если ";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 52);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" });
            comboBox3.Location = new Point(391, 16);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 7;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(272, 19);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 6;
            label2.Text = " % то нажать кнопку  ";
            label2.Click += label2_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { ">", "<", ">=", "<=", "<>" });
            comboBox2.Location = new Point(163, 16);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(56, 23);
            comboBox2.TabIndex = 5;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ЖС", "МЭ" });
            comboBox1.Location = new Point(45, 16);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 23);
            comboBox1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(497, 67);
            button2.Name = "button2";
            button2.Size = new Size(140, 39);
            button2.TabIndex = 5;
            button2.Text = "Удалить макрос";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(mpAddr);
            panel2.Controls.Add(maxMpAddr);
            panel2.Controls.Add(xpAddr);
            panel2.Controls.Add(maxXpAddr);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(listBox1);
            panel2.Location = new Point(12, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(693, 358);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 100);
            label8.Name = "label8";
            label8.Size = new Size(174, 15);
            label8.TabIndex = 19;
            label8.Text = "Название окна (ComebackPW)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 34);
            label7.Name = "label7";
            label7.Size = new Size(199, 15);
            label7.TabIndex = 18;
            label7.Text = "Название процесса (ElementClient)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 127);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(194, 23);
            textBox3.TabIndex = 17;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 57);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(194, 23);
            textBox2.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(496, 241);
            label6.Name = "label6";
            label6.Size = new Size(160, 15);
            label6.TabIndex = 15;
            label6.Text = "Фактическое МП (16E055F8)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(497, 197);
            label5.Name = "label5";
            label5.Size = new Size(173, 15);
            label5.TabIndex = 14;
            label5.Text = "Максимальное МП (16E055F8)";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(497, 153);
            label4.Name = "label4";
            label4.Size = new Size(159, 15);
            label4.TabIndex = 13;
            label4.Text = "Фактическое ЖС (16E055F8)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(497, 109);
            label3.Name = "label3";
            label3.Size = new Size(172, 15);
            label3.TabIndex = 12;
            label3.Text = "Максимальное ЖС (16E055F8)";
            // 
            // button4
            // 
            button4.Location = new Point(613, 302);
            button4.Name = "button4";
            button4.Size = new Size(67, 39);
            button4.TabIndex = 11;
            button4.Text = "Стоп";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(540, 302);
            button3.Name = "button3";
            button3.Size = new Size(67, 39);
            button3.TabIndex = 10;
            button3.Text = "Старт";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // mpAddr
            // 
            mpAddr.Location = new Point(496, 259);
            mpAddr.Name = "mpAddr";
            mpAddr.Size = new Size(140, 23);
            mpAddr.TabIndex = 9;
            // 
            // maxMpAddr
            // 
            maxMpAddr.Location = new Point(497, 215);
            maxMpAddr.Name = "maxMpAddr";
            maxMpAddr.Size = new Size(140, 23);
            maxMpAddr.TabIndex = 8;
            maxMpAddr.TextChanged += textBox4_TextChanged;
            // 
            // xpAddr
            // 
            xpAddr.Location = new Point(497, 171);
            xpAddr.Name = "xpAddr";
            xpAddr.Size = new Size(140, 23);
            xpAddr.TabIndex = 7;
            // 
            // maxXpAddr
            // 
            maxXpAddr.Location = new Point(497, 127);
            maxXpAddr.Name = "maxXpAddr";
            maxXpAddr.Size = new Size(140, 23);
            maxXpAddr.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "ХакПВ v.1.0 by sasha21l";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Panel panel1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label2;
        private ComboBox comboBox3;
        private Button button2;
        private Panel panel2;
        private TextBox mpAddr;
        private TextBox maxMpAddr;
        private TextBox xpAddr;
        private TextBox maxXpAddr;
        private Button button4;
        private Button button3;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label7;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label8;
    }
}
