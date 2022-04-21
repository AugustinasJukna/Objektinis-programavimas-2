using System;
using System.IO;
using System.Text;
namespace LAB4_ConsoleApp
{
    public static class InOutUtils
    {
        public static FileData ReadFile(string fileName)
        {
            LinkList<Location> LocationsList = new LinkList<Location>();
            string [] information = new string[2];
            using (StreamReader input = new StreamReader(fileName, Encoding.UTF8))
            {
                information[0] = input.ReadLine();
                information[1] = input.ReadLine();
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    try
                    {
                        string[] Parts = line.Split(';');
                        int amountOfParts = Parts.Length;
                        switch(amountOfParts)
                        {
                            case 7:
                                var obj1 = new Museum();
                                obj1.ParseLine(Parts);
                                LocationsList.Add(obj1);
                                break;
                            case 5:
                                var obj2 = new Statue();
                                obj2.ParseLine(Parts);
                                LocationsList.Add(obj2);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            FileData newFile = new FileData(information[0], information[1], LocationsList, fileName);
            return newFile;
        }

        public static void WriteToCSV(string fileName, LinkList<Location> list)
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
               foreach (Location location in list)
                {
                   output.WriteLine(location.ToString());
                } 
            }
        }

        public static void PrintAllLocationsCSV(string fileName, LinkList<FileData> filesList)
        {
            foreach (FileData file in filesList)
            {
                WriteToCSV(fileName, file.Locations);
            }
        }

        private static void PrintStartingData(StreamWriter output, LinkList<FileData> files)
        {
            using (output)
            {
                foreach (FileData file in files)
                {
                    output.WriteLine("Dokumento pavadinimas: " + file.FileName);
                    output.WriteLine(file.FirstLine); 
                    output.WriteLine(file.SecondLine);
                    //output.WriteLine("|{0, -25}|{1, -20}|{2, -20}|", "Pavadinimas", "Adresas", "Įkūrimo metai");
                    LinkList<Location> museums = file.Locations.ExtractClassList<Museum>();
                    LinkList<Location> statues = file.Locations.ExtractClassList<Statue>();
                    LinkList<Location> pointer = museums;
                    for (int i = 0;  i < 2; i++)
                    {
                        if (i == 0)
                        {
                            string line = String.Format("|{0, -25}|{1, -20}|{2, 20}|{3, -10}|{4, 20}|{5, -10}|{6, -15}|", "Pavadinimas", "Adresas", "Įkūrimo metai", "Tipas", "Darbo dienos", "Turi gidą?", "Bilieto kaina");
                            output.WriteLine(new string('-', line.Length));
                            output.WriteLine(line);
                            output.WriteLine(new string('-', line.Length));
                        }

                        else if (i == 1 && pointer.Count() != 0)
                        {
                            string line = String.Format("|{0, -25}|{1, -20}|{2, 20}|{3, -25}|{4, -25}|", "Pavadinimas", "Adresas", "Įkūrimo metai", "Autorius", "Skirta");
                            output.WriteLine();
                            output.WriteLine(new string('-', line.Length));
                            output.WriteLine(line);
                            output.WriteLine(new string('-', line.Length));
                        }
                        foreach (Location location in pointer)
                        {
                            if (i == 0)
                            {
                                output.WriteLine((location as Museum).ToString());
                            }

                            else
                            {
                                output.WriteLine((location as Statue).ToString());
                            }
                        }
                        pointer = statues;
                    }
                    //foreach (Location location in file.Locations)
                    //{
                    //    switch (location)
                    //    {
                    //        case Museum museum:
                    //            output.WriteLine(museum.ToString());
                    //            break;
                    //        case Statue statue:
                    //            output.WriteLine(statue.ToString());
                    //            break;
                    //    }
                    //}
                    output.WriteLine();
                }
            }
        }

        public static void PrintData<T>(string fileName, string header, LinkList<T> list) where T : IEquatable<T>, IComparable<T>
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                output.WriteLine(header);
                switch (list)
                {
                    case LinkList<FileData> files:
                        PrintStartingData(output, files);
                        break;
                    case LinkList<Location> locations:
                        output.WriteLine("|{ 0, -20}|{ 1, -15}|{ 2, 10}|", "Pavadinimas", "Adresas", "Įkūrimo metai");
                        foreach (Location location in locations)
                        {
                            output.WriteLine(location.ToString());
                        }
                        output.WriteLine();
                        break;
                }
            }
        }
    }
}
