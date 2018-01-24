using MediatR;

namespace CQRS_step3.Domain.ProductsManagememt.Commands
{
    public class ChangeFieldValueCommand : IRequest
    {
        public int FieldValueId { get; set; }

        public object Value { get; set; }
    }
}