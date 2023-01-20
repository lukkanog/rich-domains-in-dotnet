using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects 
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract<Address>()
                .Requires()
                .IsGreaterOrEqualsThan(Street, 3, "Address.Street", "Street should contain at least 3 characters")
                .IsGreaterOrEqualsThan(Number, 1, "Address.Number", "Number should contain at least 1 character")
                .IsGreaterOrEqualsThan(Neighborhood, 3, "Address.Neighborhood", "Neighborhood should contain at least 3 characters")
                .IsGreaterOrEqualsThan(City, 3, "Address.City", "City should contain at least 3 characters")
                .IsGreaterOrEqualsThan(State, 2, "Address.State", "State should contain at least 2 characters")
                .IsGreaterOrEqualsThan(Country, 2, "Address.Country", "Country should contain at least 2 characters")
                .IsGreaterOrEqualsThan(ZipCode, 3, "Address.ZipCode", "ZipCode should contain at least 3 characters")
                .IsLowerOrEqualsThan(Street, 40, "Address.Street", "Street should contain at most 40 characters")
                .IsLowerOrEqualsThan(Number, 6, "Address.Number", "Number should contain at most 6 characters")
                .IsLowerOrEqualsThan(Neighborhood, 40, "Address.Neighborhood", "Neighborhood should contain at most 40 characters")
                .IsLowerOrEqualsThan(City, 60, "Address.City", "City should contain at most 60 characters")
                .IsLowerOrEqualsThan(State, 40, "Address.State", "State should contain at most 40 characters")
                .IsLowerOrEqualsThan(Country, 40, "Address.Country", "Country should contain at most 40 characters")
                .IsLowerOrEqualsThan(ZipCode, 8, "Address.ZipCode", "ZipCode should contain at most 8 characters")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}