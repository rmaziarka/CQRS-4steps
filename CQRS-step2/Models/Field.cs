namespace CQRS_step2.Models
{
    public class Field
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Type { get; set; }
    }
}