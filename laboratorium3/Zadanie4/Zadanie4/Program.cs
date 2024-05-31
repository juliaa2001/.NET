using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Podaj sciezke do pliku: ");
        string originalFile = Console.ReadLine(); 
        string encryptedFile = "encrypted.txt"; 
        string decryptedFile = "decrypted.txt"; 

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
        {
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            try
            {
                EncryptFile(originalFile, encryptedFile, publicKey);

                DecryptFile(encryptedFile, decryptedFile, privateKey);

                Console.WriteLine("Sukces, program kończy działanie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void EncryptFile(string inputFile, string outputFile, string publicKey)
    {
        using (AesManaged aes = new AesManaged())
        {
            byte[] aesKey = aes.Key;
            byte[] aesIV = aes.IV;

            byte[] encryptedAesKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                encryptedAesKey = rsa.Encrypt(aesKey, false);
            }

            using (FileStream fs = new FileStream(outputFile, FileMode.Create))
            {
                fs.Write(encryptedAesKey, 0, encryptedAesKey.Length);
                fs.Write(aesIV, 0, aesIV.Length);

                using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (FileStream inputFs = new FileStream(inputFile, FileMode.Open))
                    {
                        inputFs.CopyTo(cryptoStream);
                    }
                }
            }
        }
    }

    static void DecryptFile(string inputFile, string outputFile, string privateKey)
    {
        using (FileStream fs = new FileStream(inputFile, FileMode.Open))
        {
            byte[] encryptedAesKey = new byte[256]; 
            fs.Read(encryptedAesKey, 0, encryptedAesKey.Length);

            byte[] aesIV = new byte[16]; 
            fs.Read(aesIV, 0, aesIV.Length);

            byte[] aesKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                aesKey = rsa.Decrypt(encryptedAesKey, false);
            }

            using (AesManaged aes = new AesManaged { Key = aesKey, IV = aesIV })
            {
                using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (FileStream outputFs = new FileStream(outputFile, FileMode.Create))
                    {
                        cryptoStream.CopyTo(outputFs);
                    }
                }
            }
        }
    }
}
