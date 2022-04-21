using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Lab5_WebApp
{
     static class InOutUtils
    {
        /// <summary>
        /// Reads one file
        /// </summary>
        /// <typeparam name="T">type to search in a file</typeparam>
        /// <param name="fileName">name of the file</param>
        /// <returns>Generic type list</returns>
        private static List<T> ReadFile<T>(string fileName) where T : IParsable, new()
        {
            try
            {
                List<T> list = new List<T>();
                string[] AllLines = File.ReadAllLines(fileName, Encoding.UTF8);
                bool test = DateTime.TryParse(AllLines[0], out DateTime date);
                int i;
                if (!test) i = 0;
                else i = 1;
                while (i < AllLines.Length)
                {
                    T reference = new T();
                    string[] LineParts = AllLines[i].Split(';');
                    if (typeof(T) == typeof(User) && LineParts.Count() == 6)
                    {
                        if (!test)
                        {
                            throw new CustomException("Neteisingai įvesta įvedimo data duomenų faile!");
                        }
                        reference.ParseLine(LineParts);
                        reference.AddDate(date);
                        list.Add(reference);
                    }

                    else if (typeof(T) == typeof(Publication) && LineParts.Count() == 3)
                    {
                        reference.ParseLine(LineParts);
                        list.Add(reference);
                    }
                    i++;
                }
                return list;
            }

            catch (CustomException)
            {
                throw;
            }

            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Reads all data files
        /// </summary>
        /// <typeparam name="T">Type to search for in files</typeparam>
        /// <param name="fileNames">array containing all fileNames</param>
        /// <returns>List of needed type</returns>
        public static List<T> ReadAllFilesOfType<T>(string[] fileNames) where T : IParsable, new()
        {

            List<T> classItems = new List<T>();
            int i = 0;
            if (fileNames.Count() == 0) throw new CustomException("Nėra duomenų failo!");
            try
            {
                while (i < fileNames.Count())
                {
                    var fileList = ReadFile<T>(fileNames[i]);
                    if (fileList != null)
                    {
                        classItems.AddRange(fileList);
                    }
                    i++;
                }
                return classItems;
            }
            catch(CustomException)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw new CustomException("Klaida su nuskaitymu!", ex);
            }
        }
        /// <summary>
        /// Prints resuklts
        /// </summary>
        /// <param name="fileName">name of the results file</param>
        /// <param name="header">header to print</param>
        /// <param name="Filtered">list to print</param>
        public static void PrintResults(string fileName, string header, List<User> Filtered)
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                try
                {
                    if (Filtered.Count() == 0) throw new CustomException("Sąrašas yra tuščias.");
                    output.WriteLine(header);
                    string line = String.Format("|{0, -20}|{1, -20}|{2, -20}|{3, -15}|{4, -15}|{5, -15}|{6, -20}|{7, -15}", "Pavardė", "Adresas", "Pradžios mėnuo", "Laikotarpis", "Kodas", "Leidinių kiekis", "Laikotarpis", "Pilna suma");
                    output.WriteLine(new string('-', line.Length));
                    output.WriteLine(line);
                    output.WriteLine(new string('-', line.Length));
                    foreach (User user in Filtered)
                    {
                        output.WriteLine(user.ToResults());
                    }
                    output.WriteLine();
                }
                catch (CustomException ex)
                {
                    output.WriteLine(ex.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// Prints starting data
        /// </summary>
        /// <typeparam name="T">Type of starting data that needs to be printed</typeparam>
        /// <param name="fileName">fileName to print results in</param>
        /// <param name="data">data to print</param>
        public static void PrintStartingData<T>(string fileName, List<T> data) where T : IResults, new()
        {
            using (StreamWriter output = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                try
                {
                    if (data.Count() == 0) throw new CustomException("Sąrašas yra tuščias.");
                    output.WriteLine("Pradiniai duomenys");
                    T obj = new T();
                    string line = obj.ReturnHeader();
                    output.WriteLine(new string('-', line.Length));
                    output.WriteLine(line);
                    output.WriteLine(new string('-', line.Length));
                    foreach (T value in data)
                    {
                        output.WriteLine(value.ToString());
                    }
                    output.WriteLine();
                }
                catch (CustomException ex)
                {
                    output.WriteLine(ex.ErrorMessage);
                }
            }
        }

    }
}
