using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    class CustomException : Exception
    {
        public string ErrorMessage { get; set; }

        public Exception Inner { get; set; }

        public CustomException(string errorMessage, Exception inner)
        {
            ErrorMessage = errorMessage;
            Inner = inner;
        }

        public CustomException(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Inner = null;
        }
    }
}
