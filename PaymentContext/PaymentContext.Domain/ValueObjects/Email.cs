using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email: ValueObject
    {
        public Email(Address address)
        {
            Address = address;
        }
        
        public Address Address { get; private set; }
    }
}
