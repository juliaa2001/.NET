using System.Threading.Channels;

namespace Zadanie_projektowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagerZadan m = new ManagerZadan();
            string wybor;
            string path;
            int idZadania;
            string nazwa;
            string opis;
            DateOnly dataZakonczenia;
            while (true)
            {
                Console.WriteLine("1. Wyswietl liste zadań");
                Console.WriteLine("2. Dodaj zadanie");
                Console.WriteLine("3. Usuń zadanie");
                Console.WriteLine("4. Wczytaj zadania");
                Console.WriteLine("5. Zapisz zadania");
                Console.WriteLine("6. Oznacz jako wykonane");
                Console.WriteLine("7. Edytuj zadanie");
                Console.WriteLine("8. Zakoncz");
                Console.Write("Wprowadz numer operacji do wykonania: ");
                wybor = Console.ReadLine();
                Console.WriteLine();
                switch (wybor)
                {
                    case "1":
                        m.WyswietlZadania();
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Podaj nazwę zadania: ");
                            nazwa = Console.ReadLine();
                            Console.Write("Podaj opis zadania: ");
                            opis = Console.ReadLine();
                            Console.Write("Podaj date zakończenia: ");
                            dataZakonczenia = DateOnly.Parse(Console.ReadLine());
                            Zadanie z = new Zadanie(nazwa, opis, dataZakonczenia);
                            m.DodajZadanie(z);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Podaj id zadania do usunięcia: ");
                            idZadania = int.Parse(Console.ReadLine());  
                            m.UsunZadanie(idZadania);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                        case "4":
                        Console.Write("Podaj ścieżkę do pliku bez rozszerzenia (.xml): ");
                        path = Console.ReadLine();
                        m.WczytajZadania(path);
                        break;
                    case "5":
                        Console.Write("Podaj ścieżkę do pliku bez rozszerzenia (.xml): ");
                        path = Console.ReadLine();
                        m.ZapiszZadania(path);
                        break;
                    case "6":
                        try
                        {
                            Console.Write("Podaj id zadania do zakończenia: ");
                            idZadania = int.Parse(Console.ReadLine());
                            m.ZakonczZadanieZListy(idZadania);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "7":
                        try
                        {
                            Console.Write("Podaj id zadania do zakończenia: ");
                            idZadania = int.Parse(Console.ReadLine());
                            Console.Write("Podaj nazwę zadania: ");
                            nazwa = Console.ReadLine();
                            Console.Write("Podaj opis zadania: ");
                            opis = Console.ReadLine();
                            Console.Write("Podaj date zakończenia: ");
                            dataZakonczenia = DateOnly.Parse(Console.ReadLine());
                            m.EdytujZadanie(idZadania,nazwa,opis,dataZakonczenia);
                           
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "8":
                        Console.WriteLine("Program kończy działanie");
                        return;
                    default:
                        Console.WriteLine("Niepoprawna operacja");
                        break;
                }
            }
        }
    }
}
