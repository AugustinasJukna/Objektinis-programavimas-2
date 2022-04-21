using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2.Practice
{
    public sealed class Mazgas
    {
        public Mobilus Duomenys { get; set; }
        public Mazgas Kitas { get; set; }
        public Mazgas() { }

        public Mazgas(Mobilus duomenys, Mazgas adresas)
        {
            this.Duomenys = duomenys;
            this.Kitas = adresas;
        }
    }
}
