using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Zadanie1
{
    public partial class Form1 : Form
    {
        private Stopwatch encryptTime;
        private Stopwatch decryptTime;
        private SymmetricAlgorithm currentAlgorithm;


        public Form1()
        {
            InitializeComponent();
            ComboBox.SelectedIndex = 0;
            encryptTime = new Stopwatch();
            decryptTime = new Stopwatch();
        }

        private string StringToHex(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append(((int)c).ToString("x2"));
            }
            return sb.ToString();
        }

        private byte[] Encryption(byte[] data)
        {
            var encryptor = currentAlgorithm.CreateEncryptor();

            using (var ms = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                }
                return ms.ToArray();
            }
        }

        private string Decryption(byte[] data)
        {
            var decryptor = currentAlgorithm.CreateDecryptor();
            using (var ms = new MemoryStream(data))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs, Encoding.UTF8))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
        private void button_encrypt_Click(object sender, EventArgs e)
        {
            try
            {
            
                if (string.IsNullOrEmpty(textBox_ASCII_Plain.Text))
                    return;
                textBox_Time_Encryption.Text = "";
                var choosenAlgorithm = ComboBox.SelectedItem.ToString();
                var plainText = textBox_ASCII_Plain.Text;
                textBox_HEX_Plain.Text = StringToHex(plainText);

                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = null;
                encryptTime.Restart();
                encrypted = Encryption(plainBytes);
                encryptTime.Stop();
                string encryptedText = Convert.ToBase64String(encrypted);
                textBox_ASCII_Plain.Text = encryptedText;
                textBox_HEX_Plain.Text = StringToHex(encryptedText);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            
            }


        }

        private void button_Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_ASCII_Cipher.Text))
                    return;

                    textBox_Time_Decryption.Text = "";
                    var choosenAlgorithm = ComboBox.SelectedItem.ToString();
                    var bytesToDecrypt = Convert.FromBase64String(textBox_ASCII_Cipher.Text);
                    decryptTime.Restart();
                    string decrypted = Decryption(bytesToDecrypt);
                    decryptTime.Stop();
                    textBox_ASCII_Cipher.Text = decrypted;
                    textBox_HEX_Cipher.Text = StringToHex(decrypted);
                
            }
            catch (Exception ex){ 
            
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Get_Encrypt_Click(object sender, EventArgs e)
        {
            textBox_Time_Encryption.Text = encryptTime.ElapsedMilliseconds.ToString() + " ms";
        }

        private void button_Get_Decrypt_Click(object sender, EventArgs e)
        {
            textBox_Time_Decryption.Text = decryptTime.ElapsedMilliseconds.ToString() + " ms";
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = ComboBox.SelectedItem.ToString();
            if (selectedItem == "DES")
            {
                currentAlgorithm = new DESCryptoServiceProvider();
            }
            else if(selectedItem == "3DES 168 bit")
            {
                currentAlgorithm = new TripleDESCryptoServiceProvider();
            }
            else if(selectedItem == "AES (CSP) 128 bit")
            {
                currentAlgorithm = new AesCryptoServiceProvider { KeySize = 128 };
            }
            else if(selectedItem == "AES (CSP) 256 bit")
            {
                currentAlgorithm = new AesCryptoServiceProvider { KeySize = 256 };
            }
            textBox_Key.Text = Convert.ToBase64String(currentAlgorithm.Key);
            textBox_IV.Text = Convert.ToBase64String(currentAlgorithm.IV);
        }
    }
}
