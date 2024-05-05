namespace Zadanie_projektowe
{
    internal class Zadanie
    {
        private static int licznikZadan = 0;
        private int id;
        private string nazwa;
        private string opis;
        private DateOnly dataZakonczenia;
        private bool czyWykonane = false;

        public int Id 
        {
            get {return id; }
            set {id = value; } 
        }
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public DateOnly DataZakonczenia
        {
            get { return dataZakonczenia; }
            set { dataZakonczenia = value; }
        }

        public bool CzyWykonane
        {
            get { return czyWykonane; }
            set { czyWykonane = value; }
        }

        public Zadanie()
        {
            licznikZadan++;
            id = licznikZadan;
            nazwa = "nieznana";
            opis = "nieznany";
        }

        public Zadanie(string nazwa_, string opis_, DateOnly dataZakonczenia_)
        {
            licznikZadan++;
            id = licznikZadan;
            nazwa = nazwa_;
            opis = opis_;
            dataZakonczenia = dataZakonczenia_;
        }
     
    }
}
