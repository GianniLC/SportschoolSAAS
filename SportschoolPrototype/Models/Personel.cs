using SportschoolPrototype.Interface;

namespace SportschoolPrototype.Models
{
    public class Personel : IPerson
    {
        public int Id { get; set; }

        public string? firstname { get; set; }

        public string? lastname { get; set; }

        public string? typeOfStaff { get; set; }

    }
}
