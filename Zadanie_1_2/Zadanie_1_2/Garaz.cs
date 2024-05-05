namespace Zadanie_1_2
{
    internal class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        public int Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }
        public Garaz()
        {
            adres = "nieznany";
            pojemnosc = 0;
            samochody = null;
        }
        public Garaz(string adres_, int pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;
            samochody = new Samochod[pojemnosc];
        }

        public void WprowadzSamochod(Samochod s)
        {
            if (liczbaSamochodow < pojemnosc)
            {
                samochody[liczbaSamochodow] = s;
                liczbaSamochodow++;
            }
            else
            {
                Console.WriteLine("Garaż jest zapełniony");
            }
        }
        public Samochod WyprowadzSamochod()
        {
            if (liczbaSamochodow == 0)
            {
                Console.WriteLine("Garaż jest pusty");
                return null;
            }
            else
            {
                liczbaSamochodow--;
                Samochod tymczasowy = samochody[liczbaSamochodow];
                samochody[liczbaSamochodow] = null;
                return tymczasowy;
            }
        }
        public void WypiszInfo()
        {
            for (int i = 0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
            }
        }
    }
}
