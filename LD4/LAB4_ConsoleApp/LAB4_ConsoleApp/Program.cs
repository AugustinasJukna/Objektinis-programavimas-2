using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;


namespace LAB4_ConsoleApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CFrAllCSV = "VisosVietos.csv";
            const string CFrCSV = "Nauji.csv";
            const string CFr = "Rezultatai.txt";

            if (File.Exists(CFr)) File.Delete(CFr);
            if (File.Exists(CFrCSV)) File.Delete(CFrCSV);
            if (File.Exists(CFrAllCSV)) File.Delete(CFrAllCSV);

            var files = Directory.GetFiles(@"..\\..\\bin\\Debug").Where(s => s.EndsWith(".txt"))
              .ToArray();


            LinkList<FileData> FilesList = new LinkList<FileData>();
            foreach (var file in files)
            {
                FilesList.Add(InOutUtils.ReadFile(file));
            }

            LinkList<Location> newLocations = TaskUtils.FilterNewLocations(FilesList);
            newLocations.CustomSort();

            foreach (Location location in newLocations)
            {
                if (location is Museum)
                {
                    Museum museum = location as Museum;
                    Console.WriteLine( museum.Name + " " + museum.TicketPrice);
                }
                else
                {
                    Statue statue = location as Statue;
                    Console.WriteLine(statue.Name + " " + statue.Author);
                }
            }

            InOutUtils.PrintAllLocationsCSV(CFrAllCSV, FilesList);
            InOutUtils.PrintData<FileData>(CFr, "Pradiniai duomenys", FilesList);

        }

    }
}
