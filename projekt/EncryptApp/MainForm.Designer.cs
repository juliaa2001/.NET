namespace EncryptApp
{
    partial class MainForm
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
            SelectFiles_BTN = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            SelectFolder_BTN = new Button();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            Encrypt_BTN = new Button();
            Decrypt = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // SelectFiles_BTN
            // 
            SelectFiles_BTN.Location = new Point(12, 12);
            SelectFiles_BTN.Name = "SelectFiles_BTN";
            SelectFiles_BTN.Size = new Size(129, 26);
            SelectFiles_BTN.TabIndex = 0;
            SelectFiles_BTN.Text = "wybierz plik / pliki";
            SelectFiles_BTN.UseVisualStyleBackColor = true;
            SelectFiles_BTN.Click += SelectFiles_BTN_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Location = new Point(273, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(255, 232);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Pliki";
            columnHeader1.Width = 255;
            // 
            // SelectFolder_BTN
            // 
            SelectFolder_BTN.Location = new Point(12, 44);
            SelectFolder_BTN.Name = "SelectFolder_BTN";
            SelectFolder_BTN.Size = new Size(129, 23);
            SelectFolder_BTN.TabIndex = 2;
            SelectFolder_BTN.Text = "wybierz folder";
            SelectFolder_BTN.UseVisualStyleBackColor = true;
            SelectFolder_BTN.Click += SelectFolder_BTN_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "DES", "AES" });
            comboBox1.Location = new Point(80, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(144, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(12, 89);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(244, 155);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Konfiguracja algorytmu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 109);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 8;
            label3.Text = "IV";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(80, 106);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(144, 23);
            textBox2.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 65);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 6;
            label2.Text = "Key";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 5;
            label1.Text = "algorytm";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 62);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(144, 23);
            textBox1.TabIndex = 4;
            // 
            // Encrypt_BTN
            // 
            Encrypt_BTN.Location = new Point(12, 261);
            Encrypt_BTN.Name = "Encrypt_BTN";
            Encrypt_BTN.Size = new Size(84, 23);
            Encrypt_BTN.TabIndex = 6;
            Encrypt_BTN.Text = "Szyfruj";
            Encrypt_BTN.UseVisualStyleBackColor = true;
            Encrypt_BTN.Click += Encrypt_BTN_Click;
            // 
            // Decrypt
            // 
            Decrypt.Location = new Point(102, 261);
            Decrypt.Name = "Decrypt";
            Decrypt.Size = new Size(75, 23);
            Decrypt.TabIndex = 7;
            Decrypt.Text = "Odszyfruj";
            Decrypt.UseVisualStyleBackColor = true;
            Decrypt.Click += Decrypt_BTN_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 299);
            Controls.Add(Decrypt);
            Controls.Add(Encrypt_BTN);
            Controls.Add(groupBox1);
            Controls.Add(SelectFolder_BTN);
            Controls.Add(listView1);
            Controls.Add(SelectFiles_BTN);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button SelectFiles_BTN;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Button SelectFolder_BTN;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Button Encrypt_BTN;
        private Button Decrypt;
    }
}
