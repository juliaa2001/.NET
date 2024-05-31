namespace Zadanie5
{
    public partial class Sinus : Form
    {
        public Sinus()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            //pobranie obieku graphics na ktorym mozemy rysowac
            Graphics g = e.Graphics;
            //pobranie obszaru klienta formularza
            Size size = ClientSize;
            //wyczyszczenie formularza białym tłem
            g.Clear(Color.White);
            //utworzenie zielonego pędzla o szerokosci 2px
            Pen pen = new Pen(Color.Green, 2);
            //obliczenie amplitudy sinusa (1/4 wysokosci obaszaru klienta)
            int amplitude = size.Height / 4;
            //obliczenie pionowego srodka obszaru klienta 
            int midY = size.Height / 2;
            //ilosc cykli sinusa na obszarze klienta 
            int frequency = 2;
            Point[] points = new Point[size.Width];
            for (int x = 0; x < size.Width; x++)
            {
                // Normalizazcja x przez podzielenie przez szerokość, pomnożenie przez
                // częstotliwość i 2pi, aby uzyskać kat w radianach
                double y = amplitude * Math.Sin((double)x / size.Width * frequency * 2 * Math.PI);
                //zapisanie punktu przesunietego o pionowy srodek, żeby wysrodkowac falę
                points[x] = new Point(x, midY - (int)y);
            }

            //polacznie punktow 
            g.DrawLines(pen, points);
        }

        private void Sinus_Resize(object sender, EventArgs e)
        {
            //odswiez grafike podczas resizu
            Invalidate();
        }
    }
}
