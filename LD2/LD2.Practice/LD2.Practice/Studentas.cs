using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Practice
{
    public sealed class Studentas
    {
        public string pv { get; set; }
        Mazgas pr;
        Mazgas d;

        public Studentas()
        {
            this.pr = null;
            this.d = null;
        }

        public void Pradžia()
        {
            d = pr;
        }

        public void Kitas()
        {
            d = d.Kitas;
        }

        public bool Yra()
        {
            return d != null;
        }

        public Mobilus ImtiDuomenis()
        {
            return d.Duomenys;
        }

        public void DėtiDuomenisA(Mobilus inf)
        {
            var d = new Mazgas(inf, null);
            d.Kitas = pr;
            pr = d;
        }

        public void Naikinti()
        {
            while (pr != null)
            {
                d = pr;
                pr.Duomenys = null;
                pr = pr.Kitas;
                d = null;
            }

            d = pr;
        }

        public void Rikiuoti()
        {
            for (Mazgas d1 = pr; d1.Kitas != null; d1 = d1.Kitas)
            {
                Mazgas maxv = d1;
                for (Mazgas d2 = d1; d2 != null; d2 = d2.Kitas)
                    if (d2.Duomenys <= maxv.Duomenys)
                        maxv = d2;
                Mobilus St = d1.Duomenys;
                d1.Duomenys = maxv.Duomenys;
                maxv.Duomenys = St;
            }
        }

        public Mobilus MaxTrukmė()
        {
            Mobilus max;
            max = pr.Duomenys;
            for (Mazgas d1 = pr; d1 != null; d1 = d1.Kitas)
            {
                if (d1.Duomenys > max)
                {
                    max = d1.Duomenys;
                }
            }
            return max;
        }

        public void Papildyti(Mobilus duom)
        {
            Mazgas d1 = new Mazgas();
            d1.Duomenys = duom;
            d1.Kitas = pr;
            pr = d1;
        }

        private Mazgas Vieta(Mobilus duom)
        {
            Mazgas dd = pr;
            while (dd != null && dd.Kitas != null && duom >= dd.Kitas.Duomenys)
            {
                dd = dd.Kitas;
            }

            return dd;
        }

        public void Įterpti(Mobilus duom)
        {
            Mazgas d = new Mazgas();
            d.Duomenys = duom;
            d.Kitas = null;
            if (pr == null) pr = d;
            else
            {
                if (pr.Duomenys >= duom)
                {
                    d.Kitas = pr;
                    pr = d;
                }

                else
                {
                    Mazgas dd = Vieta(duom);
                    d.Kitas = dd.Kitas;
                    dd.Kitas = d;
                }
            }
        }
    }
}
