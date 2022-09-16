using System.ComponentModel;

namespace SportschoolPrototype.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public int? courseID { get; set; }
        public string? title { get; set; }

        [DisplayName("Subscription description")]
        public string? description { get; set; }

        public int? weeklyUses { get; set; }
        public int duration { get; set; }

        public virtual ICollection<Course>? courses { get; set; }
    }
}
