using System.Xml;

namespace Zadanie_projektowe
{
    internal class ManagerZadan
    {
        private readonly List<Zadanie> zadania;
        public ManagerZadan()
        {
            zadania = new List<Zadanie>();
        }
        public void DodajZadanie(Zadanie z)
        {
            zadania.Add(z);
            Console.WriteLine("Zadanie dodane pomyślnie");
            Console.WriteLine();
        }
        public void UsunZadanie(int idZadania)
        {
            Zadanie znalezioneZadanie = ZnajdzZadanie(idZadania);
            if(znalezioneZadanie != null)
            {
                zadania.Remove(znalezioneZadanie);
                Console.WriteLine("Zadanie zostało usunięte");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nie znaleziono zadania o id: " + idZadania);
                Console.WriteLine();
            }
        }
        public void WyswietlZadania()
        {
            for(int i = 0; i < zadania.Count; i++)
            {
                Console.WriteLine("Id: " + zadania[i].Id);
                Console.WriteLine("Nazwa: " + zadania[i].Nazwa);
                Console.WriteLine("Opis: " + zadania[i].Opis);
                Console.WriteLine("Data zakończenia: " + zadania[i].DataZakonczenia);
                if (zadania[i].CzyWykonane)
                {
                    Console.WriteLine("Czy wykonane: Wykonane");
                }
                else
                {
                    Console.WriteLine("Czy wykonane: Nie wykonane");
                }
                Console.WriteLine();
            }
        }

        public void WczytajZadania (string filePath)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(filePath + ".xml");
                XmlNodeList nodeList = doc.SelectNodes("/Zadania/Zadanie");
                zadania.Clear();

                foreach (XmlNode node in nodeList)
                {
                    Zadanie zadanie = new Zadanie();
                    zadanie.Id = int.Parse(node["Id"].InnerText);
                    zadanie.Nazwa = node["Nazwa"].InnerText;
                    zadanie.Opis = node["Opis"].InnerText;
                    zadanie.DataZakonczenia = DateOnly.Parse(node["DataZakonczenia"].InnerText);
                    zadanie.CzyWykonane = bool.Parse(node["CzyWykonane"].InnerText);

                    zadania.Add(zadanie);
                }
                Console.WriteLine("Zadania zostały wczytane z pliku.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas wczytywania zadań: " + ex.Message);
                Console.WriteLine();
            }
        }

        public void ZapiszZadania(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Zadania");
            doc.AppendChild(rootNode);

            foreach (Zadanie z in zadania)
            {
                XmlNode zadanieNode = doc.CreateElement("Zadanie");

                XmlNode idNode = doc.CreateElement("Id");
                idNode.InnerText = z.Id.ToString();
                zadanieNode.AppendChild(idNode);

                XmlNode nazwaNode = doc.CreateElement("Nazwa");
                nazwaNode.InnerText = z.Nazwa;
                zadanieNode.AppendChild(nazwaNode);

                XmlNode opisNode = doc.CreateElement("Opis");
                opisNode.InnerText = z.Opis;
                zadanieNode.AppendChild(opisNode);

                XmlNode dataNode = doc.CreateElement("DataZakonczenia");
                dataNode.InnerText = z.DataZakonczenia.ToString();
                zadanieNode.AppendChild(dataNode);

                XmlNode wykonaneNode = doc.CreateElement("CzyWykonane");
                wykonaneNode.InnerText = z.CzyWykonane.ToString();
                zadanieNode.AppendChild(wykonaneNode);

                rootNode.AppendChild(zadanieNode);
            }

            doc.Save(filePath + ".xml");
            Console.WriteLine("Zadania zostały zapisane do pliku.");
            Console.WriteLine();
        }

        public void ZakonczZadanieZListy(int idZadania)
        {
            Zadanie znalezioneZadanie = ZnajdzZadanie(idZadania);
           
            if (znalezioneZadanie != null)
            {
                znalezioneZadanie.CzyWykonane = true;
                Console.WriteLine("Status zadnaia został zmieniony");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nie znaleziono zadania o id: " + idZadania);
                Console.WriteLine();
            }
        }

        private Zadanie ZnajdzZadanie(int idZadania)
        {
            for (int i = 0; i < zadania.Count; i++)
            {
                if (zadania[i].Id == idZadania)
                {
                    return zadania[i];
                    
                }
            }
            return null;
        }

        public void EdytujZadanie(int idZadania, string nazwa, string opis, DateOnly dataZakonczenia)
        {
            Zadanie znalezioneZadanie = ZnajdzZadanie(idZadania);

            if (znalezioneZadanie != null)
            {
                znalezioneZadanie.Nazwa = nazwa;
               znalezioneZadanie.Opis = opis;
                znalezioneZadanie.DataZakonczenia = dataZakonczenia;
                Console.WriteLine("Pomyślnie edytowano zadanie");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nie znaleziono zadania o id: " + idZadania);
                Console.WriteLine();
            }
        }
    }
}
