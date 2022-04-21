using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    public class Subscription
    {
        public User SubscriptionUser { get; set; }
        public Publication SubscriptionPublication { get; set; }

        public Subscription(User user, Publication publication)
        {
            SubscriptionUser = user;
            SubscriptionPublication = publication;
        }

        public void SetPrice()
        {
            SubscriptionUser.FullPrice = ((SubscriptionPublication.MonthlyPrice * SubscriptionUser.Duration) * SubscriptionUser.AmountOfPublications);
        }
    }
}
