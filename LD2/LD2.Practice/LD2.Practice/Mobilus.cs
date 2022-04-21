using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Practice
{
    public class Mobilus
    {
        public string modelis { get; set; }
        public string tipas { get; set; }
        public int baterija { get; set; }

        public Mobilus(string modelis ="", string tipas = "", int baterija = 0)
        {
            this.modelis = modelis;
            this.tipas = tipas;
            this.baterija = baterija;
        }

        void Dėti(string a, string b, int c)
        {
            modelis = a;
            tipas = b;
            baterija = c;
        }

        public override string ToString()
        {
            string eilute;
            eilute = String.Format("|{0, -30}| {1, -20} |  {2, 8:f}   |", modelis, tipas, baterija);
            return eilute;
        }

        public override bool Equals(object obj)
        {
            Mobilus telefonas = obj as Mobilus;
            return telefonas.tipas == tipas && telefonas.modelis == modelis && telefonas.baterija == baterija;
        }

        public override int GetHashCode()
        {
            return this.tipas.GetHashCode() ^ this.modelis.GetHashCode() ^ this.baterija.GetHashCode();
        }

        public static bool operator >=(Mobilus pirmas, Mobilus antras)
        {
            int poz = String.Compare(pirmas.modelis, antras.modelis, StringComparison.CurrentCulture);
            return pirmas.baterija > antras.baterija || pirmas.baterija == antras.baterija && poz > 0;
        }

        public static bool operator <=(Mobilus pirmas, Mobilus antras)
        {
            int poz = String.Compare(pirmas.modelis, antras.modelis, StringComparison.CurrentCulture);
            return pirmas.baterija < antras.baterija || pirmas.baterija == antras.baterija && poz < 0;
        }

        public static bool operator ==(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.tipas == antras.tipas;
        }

        public static bool operator !=(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.tipas != antras.tipas;
        }

        public static bool operator >(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.baterija > antras.baterija;
        }

        public static bool operator < (Mobilus pirmas, Mobilus antras)
        {
            return pirmas.baterija < antras.baterija;
        }
    }
}
