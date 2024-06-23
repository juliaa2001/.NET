using System.Security.Cryptography;
using System.Xml.Serialization;

namespace EncryptApp
{
    public partial class MainForm : Form
    {
        private SymmetricAlgorithm currentAlgorithm;
        public List<FileInfo> SelectedFiles { get; set; } = new();
        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectFiles_BTN_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listView1.Items.Clear();
                    SelectedFiles.Clear();

                    foreach (string file in openFileDialog.FileNames)
                    {
                        var fileInfo = new FileInfo(file);
                        listView1.Items.Add(fileInfo.Name);
                        SelectedFiles.Add(fileInfo);
                    }
                }
            }
        }

        private void SelectFolder_BTN_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    listView1.Items.Clear();
                    SelectedFiles.Clear();

                    string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                    foreach (string file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        listView1.Items.Add(fileInfo.Name);
                        SelectedFiles.Add(fileInfo);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string configPath = "config.xml";
            if (File.Exists(configPath))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AlgorithmConfig));
                    using (FileStream fs = new FileStream(configPath, FileMode.Open))
                    {
                        AlgorithmConfig config = (AlgorithmConfig)serializer.Deserialize(fs);
                        SetAlgorithm(config.Name, config.Key, config.IV);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"B³¹d podczas ³adowania konfiguracji: {ex.Message}", "B³¹d",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetDefaultAlgorithm();
                }
            }
            else
            {
                MessageBox.Show("Plik config.xml nie zosta³ znaleziony. U¿ywana bêdzie domyœlna konfiguracja.", "Informacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetDefaultAlgorithm();
            }
        }

        private void SetAlgorithm(string name, string? key = null, string? iv = null)
        {

            switch (name)
            {
                case "AES":
                    currentAlgorithm = Aes.Create();
                    break;
                case "DES":
                    currentAlgorithm = DES.Create();
                    break;
                default:
                    MessageBox.Show("Niepoprawna nazwa algorytmu", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            comboBox1.SelectedItem = name;
            if (key == null && iv == null)
            {
                textBox1.Text = Convert.ToBase64String(currentAlgorithm.Key);
                textBox2.Text = Convert.ToBase64String(currentAlgorithm.IV);
            }
            else
            {
                textBox1.Text = key;
                textBox2.Text = iv;
                currentAlgorithm.Key = Convert.FromBase64String(key);
                currentAlgorithm.IV = Convert.FromBase64String(iv);
            }
        }

        private void SetDefaultAlgorithm()
        {
            comboBox1.SelectedIndex = 0;
            string defaultAlgorithmName = comboBox1.SelectedItem.ToString();

            SetAlgorithm(defaultAlgorithmName);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configPath = "config.xml";
            AlgorithmConfig config = new AlgorithmConfig
            {
                Name = comboBox1.SelectedItem.ToString(),
                Key = textBox1.Text,
                IV = textBox2.Text
            };

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AlgorithmConfig));
                using (FileStream fs = new FileStream(configPath, FileMode.Create))
                {
                    serializer.Serialize(fs, config);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d podczas zapisywania konfiguracji: {ex.Message}",
                    "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = comboBox1.SelectedItem.ToString();
            SetAlgorithm(name);
        }

        private async void Encrypt_BTN_Click(object sender, EventArgs e)
        {
            if (SelectedFiles.Count == 0)
            {
                MessageBox.Show("Najpierw wybierz pliki.",
                    "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tasks = new List<Task>();
            foreach (var fileInfo in SelectedFiles)
            {
                tasks.Add(Task.Run(() => EncryptFile(fileInfo.FullName)));
            }

            await Task.WhenAll(tasks);

            MessageBox.Show("Pliki zosta³y zaszyfrowane.",
                "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EncryptFile(string filePath)
        {
            try
            {
                byte[] fileContent = File.ReadAllBytes(filePath);
                byte[] encryptedContent;

                using (var encryptor = currentAlgorithm.CreateEncryptor(currentAlgorithm.Key, currentAlgorithm.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(fileContent, 0, fileContent.Length);
                        cs.FlushFinalBlock();
                    }
                    encryptedContent = ms.ToArray();
                }

                string encryptedFilePath = Path.Combine(Path.GetDirectoryName(filePath),
                    Path.GetFileNameWithoutExtension(filePath) + "_zaszyfrowany" + Path.GetExtension(filePath));
                File.WriteAllBytes(encryptedFilePath, encryptedContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d podczas szyfrowania pliku {filePath}: {ex.Message}",
                    "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Decrypt_BTN_Click(object sender, EventArgs e)
        {
            if (SelectedFiles.Count == 0)
            {
                MessageBox.Show("Najpierw wybierz pliki.",
                    "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tasks = new List<Task>();
            foreach (var fileInfo in SelectedFiles)
            {
                tasks.Add(Task.Run(() => DecryptFile(fileInfo.FullName)));
            }

            await Task.WhenAll(tasks);

            MessageBox.Show("Pliki zosta³y odszyfrowane.",
                "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DecryptFile(string filePath)
        {
            try
            {
                byte[] fileContent = File.ReadAllBytes(filePath);
                byte[] decryptedContent;

                using (var decryptor = currentAlgorithm.CreateDecryptor(currentAlgorithm.Key, currentAlgorithm.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(fileContent, 0, fileContent.Length);
                    }
                    decryptedContent = ms.ToArray();
                }

                string decryptedFilePath = Path.Combine(Path.GetDirectoryName(filePath),
                    Path.GetFileNameWithoutExtension(filePath)
                    .Replace("_zaszyfrowany","") + "_odszyfrowany" + Path.GetExtension(filePath));
                File.WriteAllBytes(decryptedFilePath, decryptedContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d podczas odszyfrowywania pliku {filePath}: {ex.Message}",
                    "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
