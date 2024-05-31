namespace Zadanie1
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
            ComboBox = new ComboBox();
            textBox_Key = new TextBox();
            label1 = new Label();
            textBox_IV = new TextBox();
            label2 = new Label();
            button_encrypt = new Button();
            label3 = new Label();
            textBox_HEX_Plain = new TextBox();
            label4 = new Label();
            textBox_ASCII_Plain = new TextBox();
            label5 = new Label();
            textBox_HEX_Cipher = new TextBox();
            label6 = new Label();
            textBox_ASCII_Cipher = new TextBox();
            button_Decrypt = new Button();
            label7 = new Label();
            label8 = new Label();
            button_Get_Encrypt = new Button();
            button_Get_Decrypt = new Button();
            label9 = new Label();
            label10 = new Label();
            textBox_Time_Encryption = new TextBox();
            textBox_Time_Decryption = new TextBox();
            SuspendLayout();
            // 
            // ComboBox
            // 
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.FormattingEnabled = true;
            ComboBox.Items.AddRange(new object[] { "DES", "3DES 168 bit", "AES (CSP) 128 bit", "AES (CSP) 256 bit" });
            ComboBox.Location = new Point(22, 22);
            ComboBox.Margin = new Padding(3, 2, 3, 2);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(133, 23);
            ComboBox.TabIndex = 0;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // textBox_Key
            // 
            textBox_Key.Location = new Point(239, 22);
            textBox_Key.Margin = new Padding(3, 2, 3, 2);
            textBox_Key.Name = "textBox_Key";
            textBox_Key.ReadOnly = true;
            textBox_Key.Size = new Size(227, 23);
            textBox_Key.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(239, 5);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 3;
            label1.Text = "Key";
            // 
            // textBox_IV
            // 
            textBox_IV.Location = new Point(239, 66);
            textBox_IV.Margin = new Padding(3, 2, 3, 2);
            textBox_IV.Name = "textBox_IV";
            textBox_IV.ReadOnly = true;
            textBox_IV.Size = new Size(227, 23);
            textBox_IV.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 49);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 5;
            label2.Text = "IV";
            // 
            // button_encrypt
            // 
            button_encrypt.Location = new Point(22, 126);
            button_encrypt.Margin = new Padding(3, 2, 3, 2);
            button_encrypt.Name = "button_encrypt";
            button_encrypt.Size = new Size(132, 22);
            button_encrypt.TabIndex = 6;
            button_encrypt.Text = "Encrypt";
            button_encrypt.UseVisualStyleBackColor = true;
            button_encrypt.Click += button_encrypt_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(201, 160);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 10;
            label3.Text = "HEX";
            // 
            // textBox_HEX_Plain
            // 
            textBox_HEX_Plain.Location = new Point(239, 160);
            textBox_HEX_Plain.Margin = new Padding(3, 2, 3, 2);
            textBox_HEX_Plain.Name = "textBox_HEX_Plain";
            textBox_HEX_Plain.ReadOnly = true;
            textBox_HEX_Plain.Size = new Size(227, 23);
            textBox_HEX_Plain.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(195, 128);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 8;
            label4.Text = "ASCII";
            // 
            // textBox_ASCII_Plain
            // 
            textBox_ASCII_Plain.Location = new Point(239, 126);
            textBox_ASCII_Plain.Margin = new Padding(3, 2, 3, 2);
            textBox_ASCII_Plain.Name = "textBox_ASCII_Plain";
            textBox_ASCII_Plain.Size = new Size(227, 23);
            textBox_ASCII_Plain.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(201, 254);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 15;
            label5.Text = "HEX";
            // 
            // textBox_HEX_Cipher
            // 
            textBox_HEX_Cipher.Location = new Point(239, 254);
            textBox_HEX_Cipher.Margin = new Padding(3, 2, 3, 2);
            textBox_HEX_Cipher.Name = "textBox_HEX_Cipher";
            textBox_HEX_Cipher.ReadOnly = true;
            textBox_HEX_Cipher.Size = new Size(227, 23);
            textBox_HEX_Cipher.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(195, 224);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 13;
            label6.Text = "ASCII";
            // 
            // textBox_ASCII_Cipher
            // 
            textBox_ASCII_Cipher.Location = new Point(239, 222);
            textBox_ASCII_Cipher.Margin = new Padding(3, 2, 3, 2);
            textBox_ASCII_Cipher.Name = "textBox_ASCII_Cipher";
            textBox_ASCII_Cipher.Size = new Size(227, 23);
            textBox_ASCII_Cipher.TabIndex = 12;
            // 
            // button_Decrypt
            // 
            button_Decrypt.Location = new Point(22, 222);
            button_Decrypt.Margin = new Padding(3, 2, 3, 2);
            button_Decrypt.Name = "button_Decrypt";
            button_Decrypt.Size = new Size(132, 22);
            button_Decrypt.TabIndex = 11;
            button_Decrypt.Text = "Decrypt";
            button_Decrypt.UseVisualStyleBackColor = true;
            button_Decrypt.Click += button_Decrypt_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(241, 106);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 16;
            label7.Text = "Plain Text";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(241, 205);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 17;
            label8.Text = "Cipher Text";
            // 
            // button_Get_Encrypt
            // 
            button_Get_Encrypt.Location = new Point(22, 302);
            button_Get_Encrypt.Margin = new Padding(3, 2, 3, 2);
            button_Get_Encrypt.Name = "button_Get_Encrypt";
            button_Get_Encrypt.Size = new Size(132, 22);
            button_Get_Encrypt.TabIndex = 18;
            button_Get_Encrypt.Text = "Get Encrypt Time";
            button_Get_Encrypt.UseVisualStyleBackColor = true;
            button_Get_Encrypt.Click += button_Get_Encrypt_Click;
            // 
            // button_Get_Decrypt
            // 
            button_Get_Decrypt.Location = new Point(22, 343);
            button_Get_Decrypt.Margin = new Padding(3, 2, 3, 2);
            button_Get_Decrypt.Name = "button_Get_Decrypt";
            button_Get_Decrypt.Size = new Size(132, 22);
            button_Get_Decrypt.TabIndex = 19;
            button_Get_Decrypt.Text = "Get Decrypt Time";
            button_Get_Decrypt.UseVisualStyleBackColor = true;
            button_Get_Decrypt.Click += button_Get_Decrypt_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(214, 305);
            label9.Name = "label9";
            label9.Size = new Size(166, 15);
            label9.TabIndex = 20;
            label9.Text = "Time/message at encryption:  ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(214, 346);
            label10.Name = "label10";
            label10.Size = new Size(166, 15);
            label10.TabIndex = 21;
            label10.Text = "Time/message at decryption:  ";
            // 
            // textBox_Time_Encryption
            // 
            textBox_Time_Encryption.Location = new Point(402, 305);
            textBox_Time_Encryption.Margin = new Padding(3, 2, 3, 2);
            textBox_Time_Encryption.Name = "textBox_Time_Encryption";
            textBox_Time_Encryption.ReadOnly = true;
            textBox_Time_Encryption.Size = new Size(80, 23);
            textBox_Time_Encryption.TabIndex = 22;
            // 
            // textBox_Time_Decryption
            // 
            textBox_Time_Decryption.Location = new Point(402, 346);
            textBox_Time_Decryption.Margin = new Padding(3, 2, 3, 2);
            textBox_Time_Decryption.Name = "textBox_Time_Decryption";
            textBox_Time_Decryption.ReadOnly = true;
            textBox_Time_Decryption.Size = new Size(80, 23);
            textBox_Time_Decryption.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 381);
            Controls.Add(textBox_Time_Decryption);
            Controls.Add(textBox_Time_Encryption);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(button_Get_Decrypt);
            Controls.Add(button_Get_Encrypt);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(textBox_HEX_Cipher);
            Controls.Add(label6);
            Controls.Add(textBox_ASCII_Cipher);
            Controls.Add(button_Decrypt);
            Controls.Add(label3);
            Controls.Add(textBox_HEX_Plain);
            Controls.Add(label4);
            Controls.Add(textBox_ASCII_Plain);
            Controls.Add(button_encrypt);
            Controls.Add(label2);
            Controls.Add(textBox_IV);
            Controls.Add(label1);
            Controls.Add(textBox_Key);
            Controls.Add(ComboBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Symetric Encription Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboBox;
        private TextBox textBox_Key;
        private Label label1;
        private TextBox textBox_IV;
        private Label label2;
        private Button button_encrypt;
        private Label label3;
        private TextBox textBox_HEX_Plain;
        private Label label4;
        private TextBox textBox_ASCII_Plain;
        private Label label5;
        private TextBox textBox_HEX_Cipher;
        private Label label6;
        private TextBox textBox_ASCII_Cipher;
        private Button button_Decrypt;
        private Label label7;
        private Label label8;
        private Button button_Get_Encrypt;
        private Button button_Get_Decrypt;
        private Label label9;
        private Label label10;
        private TextBox textBox_Time_Encryption;
        private TextBox textBox_Time_Decryption;
    }
}
