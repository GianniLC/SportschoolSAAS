using SportschoolPrototype.Interface;
using System.ComponentModel;

namespace SportschoolPrototype.Models
{
    public class Member : IPerson
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public string? firstname { get; set; }

        [DisplayName("Last name")]
        public string? lastname { get; set; }

        [DisplayName("Subscription ID")]
        public int subscriptionId { get; set; }

        [DisplayName("The amount of time you can still go this week")]
        public int TimesLeft { get; set; }


        public Subscription subscriptions { get; set; }
    }
}
