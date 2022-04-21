using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Lab5_ConsoleApp
{
     static class InOutUtils
    {
        public static List<T> ReadFile<T>(string fileName) where T : IParsable, new()
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

            catch (Exception)
            {
                return null;
            }
        }

        public static List<T> ReadAllFilesOfType<T>(List<string> fileNames) where T : IParsable, new()
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
            catch (Exception ex)
            {
                throw new CustomException("Klaida su nuskaitymu!", ex);
            }
        }
    }
}
