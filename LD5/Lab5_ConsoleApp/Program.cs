using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFr = "Rezultatai.txt";
            if (File.Exists(CFr)) File.Delete(CFr);
            var files = Directory.GetFiles(@"D:\OneDrive - Kaunas University of Technology\Objektinis programavimas\LD5\Lab5_ConsoleApp\bin\Debug");
            var filesList = files.Where(f => f.EndsWith(".txt")).ToList();

            List<User> allUsers = InOutUtils.ReadAllFilesOfType<User>(filesList);
            List<Publication> allPublications = InOutUtils.ReadAllFilesOfType<Publication>(filesList);

            List<Subscription> subscriptions = TaskUtils.ConnectUsersWithPublications(allUsers, allPublications);
            TaskUtils.SetPrices(subscriptions);

            string city = "Balandis";

            List<User> filtered = TaskUtils.FindUsersByCriteria(allUsers, city, new DateTime(2021, 03, 05), new DateTime(2021, 12, 20));
            filtered = TaskUtils.CustomSort(filtered);

            foreach (User user in filtered)
            {
                Console.WriteLine( user.Address + " "+ user.Surname);
            }
             
        }
    }
}
