using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    class MonthsDictionary
    {
        private Dictionary<string, int> Months { get; set; }

        public MonthsDictionary()
        {
            Months = new Dictionary<string, int>();
            Months["Sausis"] = 1;
            Months["Vasaris"] = 2;
            Months["Kovas"] = 3;
            Months["Balandis"] = 4;
            Months["Gegužė"] = 5;
            Months["Birželis"] = 6;
            Months["Liepa"] = 7;
            Months["Rugpjūtis"] = 8;
            Months["Rugsėjis"] = 9;
            Months["Spalis"] = 10;
            Months["Lapkritis"] = 11;
            Months["Gruodis"] = 12;
        }

        public int ReturnMonthNumberByName(string name)
        {
            bool tryBool = Months.TryGetValue(name, out int result);
            if (!tryBool) throw new Exception();
            return result;
        }

    }
}
