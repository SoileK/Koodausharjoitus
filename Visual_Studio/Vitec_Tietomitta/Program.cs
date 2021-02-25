using System;
using System.IO;

namespace Vitec_Tietomitta
{
    class Program
    {
        static void Main(string[] args)
        {
            //alustetaan pääohjelmassa tavittavat muuttujat
            char valinta;
            int variksia;
            int harakoita;

            //pyydetään valitsemaan varis tai harakka, niin kauan kunnes syöte on joko v tai h
            //Kirjataan havainto lokiin
            do
            {
                Console.Write("Kirjaa havainto: (v)aris tai (h)arakka ");
                valinta = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();

                if (valinta == 'v')
                {
                    Console.WriteLine("Varis havaittu\n");
                    KirjaaHavainnot("Varis");
                }
                else if (valinta == 'h')
                {
                    Console.WriteLine("Harakka havaittu\n");
                    KirjaaHavainnot("Harakka");
                }
                else
                {
                    Console.WriteLine("Virheellinen syöte, yritä uudelleen\n");
                }
            } while (valinta != 'v' && valinta != 'h');

            //Lasketaan lokista varisten ja harakoiden havaintomäärä ja tulostetaan se
            Console.WriteLine();
            variksia = LaskeVarikset();
            harakoita = LaskeHarakat();
            Console.WriteLine("Havaintojen tilanne: Variksia " + variksia + " kpl. Harakoita " + harakoita + " kpl.");

            Console.ReadKey();
        }

        //Lisätään aikaleima ja havaittu lintu listan jatkeeksi
        private static void KirjaaHavainnot(string lintu)
        {
            string havainto = DateTime.Now + " - " + lintu;
            File.AppendAllText("havainnot.txt", havainto + "\n");      
        }

        //luetaan tiedoston sisältö string muotoon ja ajetaan eri luokasta aliohjelma varisten laskemiseksi
        private static int LaskeVarikset()
        {
            int variksia = 0;
            string tiedosto = File.ReadAllText("havainnot.txt");
            variksia = TextTool.CountStringOccurrences(tiedosto, "Varis");
            return variksia; 
        }

        //tehdään sama harakoille
        private static int LaskeHarakat()
        {
            int harakoita = 0;
            string tiedosto = File.ReadAllText("havainnot.txt");
            harakoita = TextTool.CountStringOccurrences(tiedosto, "Harakka");
            return harakoita;
        }
    }
    //lasketaan määritetyn linnun esiintymiskerrat tekstiksi luetusta tiedostosta
    public static class TextTool
    {
        public static int CountStringOccurrences(string tiedosto, string lintu)
        {
            int maara = 0;
            int i = 0;
            while ((i = tiedosto.IndexOf(lintu, i)) != -1)
            {
                i += lintu.Length;
                maara ++;
            }
            return maara;
        }
    }

}


