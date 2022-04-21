using System;
using System.IO;
using System.Text;
namespace Lab4_WebApp
{
    public static class InOutUtils
    {
        /// <summary>
        /// Reads all files in the "App_Data" folder
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public static LinkList<FileData> ReadFiles(string[] fileNames)
        {
            LinkList<FileData> files = new LinkList<FileData>();
            try
            {
                foreach (string file in fileNames)
                {
                    files.Add(ReadFile(file));
                }
            }
            catch (Exception)
            {
                throw new ParseException();
            }
            return files;
        }

        /// <summary>
        /// Reads one file individually
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>a FileData object to hold all the data from the file</returns>
        private static FileData ReadFile(string fileName)
        {
            LinkList<Location> LocationsList = new LinkList<Location>();
            string [] information = new string[2];
            using (StreamReader input = new StreamReader(fileName, Encoding.UTF8))
            {
                try
                {
                    information[0] = input.ReadLine();
                    information[1] = input.ReadLine();
                    string line;
                    while ((line = input.ReadLine()) != null)
                    {
                        string[] Parts = line.Split(';');
                        int amountOfParts = Parts.Length;
                        switch (amountOfParts)
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
                }
                catch (Exception)
                {
                    throw new ParseException();
                }
            }
            FileData newFile = new FileData(information[0], information[1], LocationsList, fileName);
            return newFile;
        }

        /// <summary>
        /// Outputs list into CSV file
        /// </summary>
        /// <param name="fileName">name of the file to write to</param>
        /// <param name="list">list to output</param>
        public static void WriteToCSV(string fileName, LinkList<Location> list)
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                try
                {
                    if (list.Count() == 0) throw new NullReferenceException();
                    foreach (Location location in list)
                    {
                        output.WriteLine(location.ToCSVString());
                    }
                }
                catch (Exception)
                {
                    output.WriteLine("Sąrašas yra tuščias.");
                }
            }
        }

        /// <summary>
        /// Prints  data into results file
        /// </summary>
        /// <param name="fileName">Filename to print into</param>
        /// <param name="files">List of files to print from</param>
        /// /// <param name="header">name to call this list</param>
        public static void PrintData(string fileName, LinkList<FileData> files, string header)
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                try
                {
                    output.WriteLine(header);
                    foreach (FileData file in files)
                    {
                        string[] fileNameParts = file.FileName.Split('\\');
                        output.WriteLine("Dokumento pavadinimas: " + fileNameParts[fileNameParts.Length - 1]);
                        output.WriteLine(file.FirstLine);
                        output.WriteLine(file.SecondLine);
                        LinkList<Location> museums = file.GetLocationsList().ExtractClassList<Museum>();
                        LinkList<Location> statues = file.GetLocationsList().ExtractClassList<Statue>();
                        LinkList<Location> pointer = museums;
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0 && pointer.Count() > 0)
                            {
                                string line = String.Format("|{0, -25}|{1, -20}|{2, 20}|{3, -10}|{4, 20}|{5, -10}|{6, -15}|", "Pavadinimas", "Adresas", "Įkūrimo metai", "Tipas", "Darbo dienos", "Turi gidą?", "Bilieto kaina");
                                output.WriteLine(new string('-', line.Length));
                                output.WriteLine(line);
                                output.WriteLine(new string('-', line.Length));
                            }

                            else if (i == 1 && pointer.Count() > 0)
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
                                    output.WriteLine(location.ToString());
                                }

                                else
                                {
                                    output.WriteLine(location.ToString());
                                }
                            }
                            pointer = statues;
                        }
                        output.WriteLine();
                    }
                }
                catch (NullReferenceException)
                {
                    output.WriteLine("Sąrašas yra tuščias.");
                }
            }
        }

        /// <summary>
        /// Prints data into results file
        /// </summary>
        /// <param name="fileName">Filename to print into</param>
        /// <param name="files">List of locations to print from</param>
        /// <param name="header">name to call this list</param>
        public static void PrintData(string fileName, LinkList<Location> locations, string header)
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                try
                {
                    if (locations.Count() == 0) throw new ParseException();
                    output.WriteLine(header);
                    LinkList<Location> museums = locations.ExtractClassList<Museum>();
                    LinkList<Location> statues = locations.ExtractClassList<Statue>();
                    LinkList<Location> pointer = museums;
                    for (int i = 0; i < 2; i++)
                    {
                        if (pointer.Count() == 0 && i == 0) pointer = statues;
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
                                output.WriteLine(location.ToString());
                            }

                            else
                            {
                                output.WriteLine(location.ToString());
                            }
                        }
                        pointer = statues;
                    }
                    output.WriteLine();
                }
                catch (Exception)
                {
                    output.WriteLine("Sąrašas yra tuščias.");
                }
            }
        }


        /// <summary>
        /// Appends text to results file
        /// </summary>
        /// <param name="fileName">name of the file to output to</param>
        /// <param name="lines">lines to output</param>
        public static void AppendText(string fileName, string[] lines)
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    output.WriteLine(lines[i]);
                }
            }
        }
    }
}
