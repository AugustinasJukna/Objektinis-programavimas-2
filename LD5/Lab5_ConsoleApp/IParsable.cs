using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    interface IParsable
    {
        void ParseLine(string[] lineParts);
        void AddDate(DateTime date);
    }
}
