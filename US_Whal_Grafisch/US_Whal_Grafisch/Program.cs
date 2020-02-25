using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using US_Whal_Grafisch.model;

namespace US_Whal_Grafisch
{

    public enum Geschlecht { Weiblich, Maenlich, Default }
    public enum Alter { Erstwaehler, Bis30, Bis40, Bis50, Restliche, Default }
    public enum Schicht { Unterschicht, Unteremittelschicht, Oberemittelschicht, Oberschicht, Default }
    public enum PolitischeHeimat { Republikaner, Demokraten, Default }
    public enum Beeinflussbarkeit { Leicht, Mittel, Schwer, Default }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            Console.ReadLine();
        }


        public static List<Wähler> Filtern(Form1.Parameter p)
        {
            List<Wähler> wl_link = new List<Wähler>();

            FileStream fs9   = File.Open("us_wahl_liste.txt", FileMode.Open);
            StreamReader sr9 = new StreamReader(fs9);
            string line;

            Geschlecht geschlecht = Geschlecht.Default;
            Alter alter           = Alter.Default;
            Schicht schicht       = Schicht.Default; 
            PolitischeHeimat ph   = PolitischeHeimat.Default;
            Beeinflussbarkeit be  = Beeinflussbarkeit.Default;

            while ((line = sr9.ReadLine()) != null)
            {
                switch (line.Split(' ')[4])
                {
                    case "Maenlich":
                        geschlecht = Geschlecht.Maenlich;
                        break;
                    case "Weiblich":
                        geschlecht = Geschlecht.Weiblich;
                        break;
                }

                switch (line.Split(' ')[5])
                {
                    case "Erstwaehler":
                        alter = Alter.Erstwaehler;
                        break;
                    case "Bis30":
                        alter = Alter.Bis30;
                        break;
                    case "Bis40":
                        alter = Alter.Bis40;
                        break;
                    case "Bis50":
                        alter = Alter.Bis50;
                        break;
                    case "Restliche":
                        alter = Alter.Restliche;
                        break;
                }

                switch (line.Split(' ')[6])
                {
                    case "Unterschicht":
                        schicht = Schicht.Unterschicht;
                        break;
                    case "Unteremittelschicht":
                        schicht = Schicht.Unteremittelschicht;
                        break;
                    case "Oberemittelschicht":
                        schicht = Schicht.Oberemittelschicht;
                        break;
                    case "Oberschicht":
                        schicht = Schicht.Oberschicht;
                        break;
                }

                switch (line.Split(' ')[7])
                {
                    case "Demokraten":
                        ph = PolitischeHeimat.Demokraten;
                        break;
                    case "Republikaner":
                        ph = PolitischeHeimat.Republikaner;
                        break;
                }

                switch (line.Split(' ')[8])
                {
                    case "Leicht":
                        be = Beeinflussbarkeit.Leicht;
                        break;
                    case "Mittel":
                        be = Beeinflussbarkeit.Mittel;
                        break;
                    case "Schwer":
                        be = Beeinflussbarkeit.Schwer;
                        break;
            }


                wl_link.Add( new Wähler() { ID                = line.Split(' ')[0], 
                                            Vorname           = line.Split(' ')[1],
                                            Nachname          = line.Split(' ')[2],
                                            PLZ               = line.Split(' ')[3],
                                            Geschlecht        = geschlecht,
                                            Alter             = alter,
                                            Schicht           = schicht,
                                            PolitischeHeimat  = ph,
                                            Beeinflussbarkeit = be
                });
            }
            fs9.Close();

            var wl_link2 = from wähler in wl_link
                      where

                        wähler.PolitischeHeimat == p.PolitischeHeimat &&
                        wähler.Geschlecht == p.Geschlecht

                        //wähler.Alter == Alter.Erstwaehler &&
                        //wähler.Schicht == Schicht.OBERSCHICHT &&
                        //wähler.PLZ > 47111 &&
                        //wähler.PLZ < 80000 &&
                        //wähler.Beeinflussbarkeit == Beeinflussbarkeit.Leicht
                        select wähler;

            List<Wähler> ww = wl_link2.ToList();
            return wl_link2.ToList();
        }
    }
}
