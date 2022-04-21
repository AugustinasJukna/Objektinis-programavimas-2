using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1_WebApp
{
    public class ErrorProof
    {
        /// <summary>
        /// Checks if there are too many inputs
        /// </summary>
        /// <param name="n">the amount of inputs</param>
        /// <returns>a true or false statement</returns>
        public static bool CheckTheN(int n)
        {
            if (n > 50 || n < 5)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}