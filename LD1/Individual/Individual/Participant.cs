using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individual
{
    public class Participant
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SchoolName { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }

        public Participant(string name, string surname, string schoolName, int age, List<string> languages)
        {
            this.Name = name;
            this.Surname = surname;
            this.SchoolName = schoolName;
            this.Age = age;
            this.Languages = languages;
        }

        /// <summary>
        /// Forms languages string
        /// </summary>
        /// <returns>string of languages</returns>
        public string ReturnLanguages()
        {
            string languages = "";
            foreach (string language in this.Languages)
            {
                languages += (language + " ");
            }
            return languages;
        }
    }
}