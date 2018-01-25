namespace CQRS_step3.Domain.ProductsManagememt.Models
{
    public class FieldValue
    {
        public int Id { get; private set; }

        public int FieldId { get; private set; }

        public virtual Field Field { get; private set; }

        public int ProductId { get; private set; }

        public virtual Product Product { get; private set; }

        public int? IntegerValue { get; private set; }

        public string StringValue { get; private set; }

        public object Value
        {
            get
            {
                if (Field.FieldType == FieldType.Integer)
                {
                    return this.IntegerValue;
                }
                else
                {
                    return this.StringValue;
                }
            }
        }

        public void ChangeValue(object commandValue)
        {
            if (Field.FieldType == FieldType.Integer)
            {
                this.IntegerValue = (int)commandValue;
            }
            else
            {
                this.StringValue = (string)commandValue;
            }
        }

    }
}