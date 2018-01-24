using MediatR;
namespace CQRS_step3.Domain.ProductsManagememt.Commands
{
    public class AddProductCommand: IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}