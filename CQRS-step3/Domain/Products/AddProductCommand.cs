using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class AddProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}