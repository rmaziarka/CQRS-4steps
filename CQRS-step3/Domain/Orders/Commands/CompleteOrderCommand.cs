using MediatR;

namespace CQRS_step3.Domain.Orders.Commands
{
    public class CompleteOrderCommand : IRequest<int>
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}