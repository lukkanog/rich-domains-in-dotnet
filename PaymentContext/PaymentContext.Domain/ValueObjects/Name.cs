using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(FirstName, 3, "Name.FirstName", "FirstName should contain at least 3 characters")
                .IsGreaterOrEqualsThan(LastName, 3, "Name.LastName", "LastName should contain at least 3 characters")
                .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "FirstName should contain at most 40 characters")
                .IsLowerOrEqualsThan(LastName, 60, "Name.LastName", "LastName should contain at most 60 characters")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}