using MediatR;

namespace CQRS_step3.Events
{
    public class ProductAddedEvent : INotification
    {
        public ProductAddedEvent(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }

        public int Id { get; }

        public string Name { get; }

        public int CategoryId { get; }
    }
}