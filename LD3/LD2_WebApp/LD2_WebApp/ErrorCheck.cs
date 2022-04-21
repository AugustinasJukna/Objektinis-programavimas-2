using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2_WebApp
{
    public class ErrorCheck
    {
        /// <summary>
        /// Checks if a given string parses to long or not
        /// </summary>
        /// <param name="value">string to parse from</param>
        /// <returns>a true or false statement</returns>
        public static bool CheckIfLong(string value)
        {
            bool c = long.TryParse(value, out long number);
            return c;
        }

        /// <summary>
        /// Checks if a given string parses into integer
        /// </summary>
        /// <param name="value">name of the string to parse from</param>
        /// <returns>a true or false statement</returns>
        public static bool CheckIfInt(string value)
        {
            bool c = int.TryParse(value, out int number);
            return c;
        }

        /// <summary>
        /// Checks if the string contains only letters and no special symbols
        /// </summary>
        /// <param name="value">string input to check</param>
        /// <returns>true or false statement based on letters count in string compared to string's length</returns>
        public static bool CheckIfAllLetters(string value)
        {
            int count = 0;
            for (int i = 0; i < value.Count(); i++)
            {
                if (char.IsLetter(value[i]) || (value[i] == ' ') && i != 0)
                {
                    count++;
                }
            }
            if (count == value.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}