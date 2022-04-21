using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises
{
    class Prekes : Preke
    {
        public int kiek { get; set; }

        public Prekes() { }
        public Prekes(string pav = "", string tipas = "", double kaina = 0.0, int kiek = 0) : base(pav, tipas, kaina)
        {
            this.kiek = kiek;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0} {1,6:d}", base.ToString(), kiek);
            return eilute;
        }

        public override double Suma()
        {
            return kiek * kaina;
        }
    }
}
