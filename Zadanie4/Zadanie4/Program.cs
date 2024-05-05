namespace Zadanie4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"text.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path)) { 
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        char[] chars = line.ToCharArray();
                        Array.Reverse(chars);
                        for(int i = 0; i < chars.Length; i++)
                        {
                            Console.Write(chars[i]);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            }
        }
    }
}
