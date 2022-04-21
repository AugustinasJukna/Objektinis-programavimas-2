using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WebApp
{
    public class Subscription //Class for a better information managment
    {
        public User SubscriptionUser { get; set; }
        public Publication SubscriptionPublication { get; set; }

        public Subscription(User user, Publication publication) //Constructor
        {
            SubscriptionUser = user;
            SubscriptionPublication = publication;
        }
    }
}
