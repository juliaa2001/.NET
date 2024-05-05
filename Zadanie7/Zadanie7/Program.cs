using System.Diagnostics;

namespace Zadanie7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"pliku_300MB.txt";  
            long fileSize = 300 * 1024 * 1024; 
            string textData = new string('a', 1024); 

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    long bytesWritten = 0;
                    while (bytesWritten < fileSize)
                    {
                        writer.Write(textData);
                        bytesWritten += textData.Length; 
                    }
                }

                Console.WriteLine("Plik tekstowy o wielkości 300 MB został utworzony.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }

            //KOD Z ZADANIA 6
            string sourcePath = filePath;
            string destinationPath = @"destination.txt";
            try
            {
                Stopwatch s = Stopwatch.StartNew();
                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
                {
                    byte[] buffer = new byte[sourceStream.Length];
                    int bytesRead = sourceStream.Read(buffer, 0, buffer.Length);

                    using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create))
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                    }
                }
                s.Stop();
                Console.WriteLine("Kopiowanie zakończone sukcesem.");
                Console.WriteLine("Czas kopiowania danych to: " + s.ElapsedMilliseconds  + "[ms]");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            }
        }
    }
}
