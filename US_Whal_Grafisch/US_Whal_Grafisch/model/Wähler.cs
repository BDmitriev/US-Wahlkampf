using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace US_Whal_Grafisch.model
{
    class Wähler
    {
        public string ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string PLZ { get; set; }

        public Geschlecht Geschlecht { get; set; }
        public Alter Alter { get; set; }
        public Schicht Schicht { get; set; }
        public PolitischeHeimat PolitischeHeimat { get; set; }
        public Beeinflussbarkeit Beeinflussbarkeit { get; set; }
    }
}
