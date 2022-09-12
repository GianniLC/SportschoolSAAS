using SportschoolPrototype.Interface;

namespace SportschoolPrototype.Models
{
    public class Member : IPerson
    {
        public int Id { get; set; }

        public string? firstname { get; set; }

        public string? lastname { get; set; }

        public int subscriptionId { get; set; }

        public virtual ICollection<Subscription> subscriptions { get; set; }
    }
}
