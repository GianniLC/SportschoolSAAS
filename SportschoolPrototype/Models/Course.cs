namespace SportschoolPrototype.Models
{
    public class Course
    {
        public int ID { get; set; }

        public int CourseID { get; set; }

        public Personel? coach { get; set; }
        public string? title { get; set; }

        public string? description { get; set; }

        public virtual ICollection<Member>? members { get; set; }
    }
}
