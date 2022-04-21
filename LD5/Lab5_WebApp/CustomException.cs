using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WebApp
{
    class CustomException : Exception
    {
        public string ErrorMessage { get; set; }

        public Exception Inner { get; set; }

        public CustomException(string errorMessage, Exception inner) //Constructor
        {
            ErrorMessage = errorMessage;
            Inner = inner;
        }

        public CustomException(string errorMessage) //Another constructor
        {
            ErrorMessage = errorMessage;
            Inner = null;
        }
    }
}
