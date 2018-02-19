using MediatR;

namespace CQRS_step2.Domain.Products.Commands
{
    public class ChangeProductFieldValueCommand : IRequest<int>
    {
        public int FieldId { get; set; }

        public object FieldValue { get; set; }

        public int ProductId { get; set; }
    }
}