using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Zadanie5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz co chcesz zrobić: ");
            Console.WriteLine("1. Zapisać dane do pliku");
            Console.WriteLine("2. Wczytać i wyświetlić dane");
            string operation = Console.ReadLine();

            string path = @"text.txt";
            if (operation == "1")
            {
                string imie;
                int wiek;
                string adres;
                Console.Write("Podaj imię: ");
                imie = Console.ReadLine();
                Console.Write("Podaj wiek: ");
                wiek = int.Parse(Console.ReadLine());
                Console.Write("Podaj adres: ");
                adres = Console.ReadLine();
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            bw.Write(imie);
                            bw.Write(wiek);
                            bw.Write(adres);
                            Console.WriteLine("Dane zostały zapisane do pliku.");
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
                }
            }
            else if (operation == "2")
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            string imie = br.ReadString();
                            int wiek = br.ReadInt32();
                            string adres = br.ReadString();
                            Console.WriteLine("Imie: " + imie);
                            Console.WriteLine("Wiek: " + wiek);
                            Console.WriteLine("Adres: " + adres);
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawna operacja");
            }
        }
    }
}
