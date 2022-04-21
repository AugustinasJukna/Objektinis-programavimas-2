using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WebApp
{
    public static class TaskUtils
    {
        /// <summary>
        /// Connects users with publications, creating a new data structure
        /// </summary>
        /// <param name="users">list of User class objects</param>
        /// <param name="publications">list of Publication class objects</param>
        /// <returns>List of Subscription class objects </returns>
        public static List<Subscription> ConnectUsersWithPublications(List<User> users, List<Publication> publications)
        {
            if (users.Count() == 0 || publications.Count() == 0) throw new CustomException("Neužtenka pradinių duomenų!");
            return users.Join(publications, u => u.Number, p => p.Number, (u, p) => new Subscription(u, p)).ToList();
        }

        /// <summary>
        /// Sets prices for all users by referencing connected Subscription class data
        /// </summary>
        /// <param name="subscriptions">List of Subscription class objects</param>
        public static void SetPrices(List<Subscription> subscriptions) => subscriptions.ForEach(s => s.SubscriptionUser.FullPrice = s.SubscriptionUser.Duration * s.SubscriptionPublication.MonthlyPrice * s.SubscriptionUser.AmountOfPublications);

        /// <summary>
        /// Does a custom sort
        /// </summary>
        /// <param name="users">List of User class objects</param>
        /// <returns>a sorted list</returns>
        public static List<User> CustomSort(List<User> users)
        {
            if (users.Count() == 0) throw new CustomException("Sąrašas yra tuščias.");
            return users.OrderBy(u => u.Address).ThenBy(u => u.Surname).ToList();
        }

        /// <summary>
        /// Filters User class objects by criteria into list
        /// </summary>
        /// <param name="users">list of User objects</param>
        /// <param name="month">inputted name of the month</param>
        /// <param name="startDate">searched start date</param>
        /// <param name="endDate">end date</param>
        /// <returns>list of filtered User objects</returns>
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

            catch (CustomException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CustomException("Skaičiavimo klaida", ex);
            }

        }
    }
}
