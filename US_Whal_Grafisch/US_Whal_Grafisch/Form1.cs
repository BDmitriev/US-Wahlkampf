using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using US_Whal_Grafisch.model;

namespace US_Whal_Grafisch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.ZeigeWahlvolk();
        }

        public class Parameter
        {
            public Geschlecht Geschlecht { get; set; } 
            public PolitischeHeimat PolitischeHeimat { get; set; }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string geschlecht = comboBox1.Text;
            string ph = comboBox2.Text;

            Parameter p = new Parameter();

            switch (geschlecht)
            {
                case "Maenlich":
                    p.Geschlecht = Geschlecht.Maenlich;
                    break;

                case "Weiblich":
                    p.Geschlecht = Geschlecht.Weiblich;
                    break;
            }

            switch (ph)
            {
                case "Demokraten":
                    p.PolitischeHeimat = PolitischeHeimat.Demokraten;
                    break;

                case "Republikaner":
                    p.PolitischeHeimat = PolitischeHeimat.Republikaner;
                    break;
            }


            List<Wähler> wl_link = Program.Filtern(p);

            textBox1.Text = "";
            foreach (var item in wl_link)
            {
                textBox1.AppendText(
                                     "*********************************************************************" + Environment.NewLine +
                                     "ID: "                + item.ID                + Environment.NewLine +
                                     "Vorname: "           + item.Vorname           + Environment.NewLine +
                                     "Nachname: "          + item.Nachname          + Environment.NewLine +
                                     "PLZ: "               + item.PLZ               + Environment.NewLine +
                                     "Geschlecht: "        + item.Geschlecht        + Environment.NewLine + 
                                     "Alter: "             + item.Alter             + Environment.NewLine +
                                     "Schicht: "           + item.Schicht           + Environment.NewLine +
                                     "Politische Heimat: " + item.PolitischeHeimat  + Environment.NewLine +
                                     "Beeinflussbarkeit: " + item.Beeinflussbarkeit + Environment.NewLine
                                     );
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}















