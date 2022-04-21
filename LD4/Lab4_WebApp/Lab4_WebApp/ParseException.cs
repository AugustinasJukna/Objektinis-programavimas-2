using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4_WebApp
{
    public class ParseException : Exception
    {
        public string CustomMessage { get; set; }
        Exception Inner { get; set; }
        public ParseException() { }
        //Constructors
        public ParseException(string customMessage)
        {
            CustomMessage = customMessage;
        }

        public ParseException(string customMessage, Exception inner) : base(customMessage, inner)
        {
            CustomMessage = customMessage;
            Inner = inner;
        }
    }
}