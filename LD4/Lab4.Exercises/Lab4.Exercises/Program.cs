using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4.Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "Prekes.txt";
            const string CFr = "Rezultatai.txt";

            if (File.Exists(CFr)) File.Delete(CFr);
            List<Prekes> PrekiuList = new List<Prekes>();

            Skaityti(CFd1, PrekiuList);
            Spausdinti(CFr, PrekiuList, "Pradinis sąršas");

            List<Prekes> NaujasPrekiuList = new List<Prekes>();
            Perrašyti(PrekiuList, NaujasPrekiuList);
            Console.WriteLine("Įveskite prekės tipą");
            string prekėsTipas = Console.ReadLine();
            NaujasPrekiuList.RemoveAll(item => item.tipas == prekėsTipas);

            if (NaujasPrekiuList.Count > 0)
            {
                Spausdinti(CFr, NaujasPrekiuList, "Suformuotas sąrašas");
                NaujasPrekiuList.Sort();
                Spausdinti(CFr, NaujasPrekiuList, "Rikiuotas suformuotas sąrašas");
                using (var fr = File.AppendText(CFr))
                {
                    double vid = NaujasPrekiuList.Average(item => item.kiek);
                    fr.WriteLine("Kiekio vidurkis = {0,5:f}", vid);
                    double prekiuSuma = Sum(NaujasPrekiuList);
                    fr.WriteLine("Naujo sąrašo prekių visa suma = {0,5:f}", prekiuSuma);
                }
            }

            else 
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Naujas sąrašas tuščias");
                }
        }

        static void Skaityti(string fv, List<Prekes> PrekiuList)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pav = parts[0].Trim();
                    string tema = parts[1].Trim();
                    double kaina = double.Parse(parts[2]);
                    int kiek = int.Parse(parts[3]);
                    Prekes pr = new Prekes(pav, tema, kaina, kiek);
                    PrekiuList.Add(pr);
                }
            }
        }

        static void Spausdinti(string fv, List<Prekes> PrekiuList, string info)
        {
            const string virsus = "----------------------------------------------------------\r\n"
 + " Pavadinimas Tipas Kaina Kiekis \r\n"
 + "----------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(info);
                fr.WriteLine(virsus);
                for (int i = 0; i < PrekiuList.Count; i++)
                {
                    Prekes pr = PrekiuList[i];
                    fr.WriteLine("{0}", pr);
                }

                fr.WriteLine("--------------------------------------------------" +
 "--------\r\n");
            }
        }

        static void Perrašyti(List<Prekes> PrekiuList, List<Prekes> NaujasPrekiuList)
        {
            for (int i = 0; i < PrekiuList.Count; i++)
            {
                Prekes p = new Prekes(PrekiuList[i].pavadinimas, PrekiuList[i].tipas, PrekiuList[i].kaina, PrekiuList[i].kiek);
                NaujasPrekiuList.Add(p);
            }
        }

        static double Sum(List<Prekes> PrekiuList)
        {
            double su = 0;
            for (int i = 0; i < PrekiuList.Count; i++)
            {
                su += PrekiuList[i].Suma();
            }
            return su;
        }
    }
}
