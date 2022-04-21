using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    public static class TaskUtils
    {
        public static List<Subscription> ConnectUsersWithPublications(List<User> users, List<Publication> publications)
        {
            if (users.Count() == 0 || publications.Count() == 0) throw new CustomException("Neužtenka pradinių duomenų!");
            return users.Join(publications, u => u.Number, p => p.Number, (u, p) => new Subscription(u, p)).ToList();
        }

        public static void SetPrices(List<Subscription> subscriptions)
        {
            subscriptions.ForEach(s => s.SubscriptionUser.FullPrice = (s.SubscriptionUser.Duration * s.SubscriptionPublication.MonthlyPrice) * s.SubscriptionUser.AmountOfPublications);
        }

        public static List<User> CustomSort(List<User> users)
        {
            if (users.Count() == 0) throw new CustomException("Sąrašas yra tuščias.");
            return users.OrderBy(u => u.Address).ThenBy(u => u.Surname).ToList();
        }

        public static List<User> FindUsersByCriteria(List<User> users, string month, DateTime startDate, DateTime endDate)
        {
            MonthsDictionary monthsDictionary = new MonthsDictionary();
            List<User> filtered = new List<User>();
            try
            {
                int monthNumber = monthsDictionary.ReturnMonthNumberByName(month);
                filtered = users.Where(u => u.CheckIfFits(monthNumber, startDate, endDate)).ToList();
                return filtered;
            }
            catch (Exception ex)
            {
                throw new CustomException("Skaičiavimo klaida", ex);
            }

        }
    }
}
