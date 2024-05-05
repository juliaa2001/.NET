namespace Zadanie6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"source.txt";
            string destinationPath = @"destination.txt";
            try
            {
                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
                {
                    byte[] buffer = new byte[sourceStream.Length];
                    int bytesRead = sourceStream.Read(buffer, 0, buffer.Length);

                    using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create))
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                    }
                }
                Console.WriteLine("Kopiowanie zakończone sukcesem.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            }
        }
    }
}
