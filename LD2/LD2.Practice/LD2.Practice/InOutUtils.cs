using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD2.Practice
{
    class InOutUtils
    {
        public static void SkaitytiAtv(string fv, int indeksas, string[] Vardai, LinkedList<Mobilus> A) 
        {
            using (var failas = new StreamReader(fv))
            {
                string eilute;
                Vardai[indeksas] = eilute = failas.ReadLine();
                while ((eilute = failas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string modelis = eilDalis[0];
                    string tipas = eilDalis[1];
                    int baterija = int.Parse(eilDalis[2]);
                    Mobilus elem = new Mobilus(modelis, tipas, baterija);
                    A.AddFirst(elem);
                }
            }
        }

        public static void Spausdinti(string fv, LinkedList<Mobilus> A, string koment)
        {
            using (var failas = new StreamWriter(fv, true))
            {
                failas.WriteLine(koment);
                failas.WriteLine("+------------------------------+---------------" +
 "-------+--------------+");
                failas.WriteLine("| Modelis | Tipas " +
                " | Veik. trukmė |");
                failas.WriteLine("+------------------------------+---------------" +
                "-------+--------------+");
                foreach (Mobilus elem in A)
                {
                    failas.WriteLine("{0}", elem.ToString());
                }
                failas.WriteLine("+------------------------------+---------------" +
 "-------+--------------+");
                failas.WriteLine();
            }
        }
    }
}
