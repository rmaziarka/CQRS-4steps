using MediatR;

namespace CQRS_step1.Domain.Products.Commands
{
    public class ChangeProductFieldValueCommand : IRequest<int>
    {
        public int FieldId { get; set; }

        public object FieldValue { get; set; }

        public int ProductId { get; set; }
    }
}