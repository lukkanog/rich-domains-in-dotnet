using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number)
        {
            Number = number;
        }
        
        public string Number { get; private set; }
    }
}
