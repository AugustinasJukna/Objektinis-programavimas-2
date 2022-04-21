using System;
namespace Lab4_WebApp
{
    public interface IParsable
    {
        //interface for parsing data to class objects
        void ParseLine(string[] Parts);
    }
}
