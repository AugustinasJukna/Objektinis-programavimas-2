using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD2.Practice
{
    class Program
    {
            static void Main(string[] args)
            {
                const string CFd1 = "Mikas.txt";
                const string CFd2 = "Darius.txt";
                const string CFd3 = "Rimas.txt";
                const string CFr = "Rezultatai.txt";

                string[] Vardai = new string[3];
                LinkedList<Mobilus> A = new LinkedList<Mobilus>();
                LinkedList<Mobilus> B = new LinkedList<Mobilus>();
                InOutUtils.SkaitytiAtv(CFd1, 0, Vardai, A);
                InOutUtils.SkaitytiAtv(CFd2, 1, Vardai, B);

            if (File.Exists(CFr))
                    File.Delete(CFr);
                InOutUtils.Spausdinti(CFr, A, Vardai[0]);
                InOutUtils.Spausdinti(CFr, B, Vardai[1]);
                using (var failas = new StreamWriter(CFr, true))
                {
                    Mobilus max;
                    max = MaxTrukmė(A);
                    failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\n" +
                    " modelis: {1}, tipas: {2}, trukmė: {3}.",
                    Vardai[0], max.modelis, max.tipas, max.baterija);
                    failas.WriteLine();
                    max = MaxTrukmė(B);
                    failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\n" +
                    " modelis: {1}, tipas: {2}, trukmė: {3}.",
                    Vardai[1], max.modelis, max.tipas, max.baterija);
                }
                LinkedList<Mobilus> Naujas = new LinkedList<Mobilus>(); 
                Console.WriteLine("Įveskite norimą įrenginio tipą:");
                string tipas = Console.ReadLine(); 
                Atrinkti(A, tipas, Naujas);
                Atrinkti(B, tipas, Naujas);
                if (Naujas.Count > 0)
                {
                    InOutUtils.Spausdinti(CFr, Naujas, "Atrinkti nerikiuoti");
                    Naujas = new LinkedList<Mobilus>
                    (Naujas.OrderBy(p => p.baterija).ThenBy(p => p.modelis));
                    InOutUtils.Spausdinti(CFr, Naujas, "Atrinkti surikiuoti");
                }
                else
                {
                    using (var failas = new StreamWriter(CFr, true))
                    {
                        failas.WriteLine("Naujas sąrašas nesudarytas.");
                    }
                }
                LinkedList<Mobilus> C = new LinkedList<Mobilus>();
                InOutUtils.SkaitytiAtv(CFd3, 2, Vardai, C);
                InOutUtils.Spausdinti(CFr, C, Vardai[2]);
                Atrinkti_Į_Rikiuotą(C, tipas, Naujas);
                if (Naujas.Count() > 0)
                    InOutUtils.Spausdinti(CFr, Naujas, "Rikiuotas po papildymo");
                else
                    using (var failas = new StreamWriter(CFr, true))
                    {
                        failas.WriteLine("Naujas sąrašas liko nesudarytas.");
                    }
            }

        static void Atrinkti(LinkedList<Mobilus> senas, string tipas, LinkedList<Mobilus> naujas)
        {
            foreach (Mobilus elem in senas)
            {
                if (elem.tipas == tipas)
                {
                    naujas.AddLast(elem);
                }
            }
        }

        static void Atrinkti_Į_Rikiuotą(LinkedList<Mobilus> senas, string tipas, LinkedList<Mobilus> naujas)
        {
            foreach (Mobilus elem in senas)
            {
                if (elem.tipas == tipas)
                {
                    Mobilus pagalb = Vieta(naujas, elem);
                    if (pagalb.baterija == -1) naujas.AddFirst(elem);
                    else
                    {
                        LinkedListNode<Mobilus> mazgas = naujas.Find(pagalb);
                        naujas.AddAfter(mazgas, elem);
                    }
                }
            }
        }

        static Mobilus Vieta(LinkedList<Mobilus> sar, Mobilus elementas)
        {
            Mobilus rastasElem = new Mobilus();
            rastasElem.baterija = -1;
            foreach (Mobilus elem in sar)
            {
                if (elem <= elementas)
                {
                    rastasElem = elem;
                }
            }
            return rastasElem;
        }

        static Mobilus MaxTrukmė(LinkedList<Mobilus> A)
        {
            Mobilus max;
            max = A.First();
            foreach (Mobilus elem in A)
            {
                if (elem > max)
                {
                    max = elem;
                }
            }
            return max;
        }
    }
}
