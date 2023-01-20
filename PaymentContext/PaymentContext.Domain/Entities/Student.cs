using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email, address);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        private IList<Subscription> _subscriptions;
        public IReadOnlyCollection<Subscription> Subscriptions
        {
            get 
            { 
                return _subscriptions.ToArray(); 
            } 
        }

        public void AddSubscription(Subscription subscription) 
        {
            var hasSubscriptionActive = false;

            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasSubscriptionActive = true;
                }
            }

            AddNotifications(new Contract<Student>()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "This student already has an active subscription")
                .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "This subscription has no payments")
            );

            if (IsValid)
            {
                _subscriptions.Add(subscription);
            }
        }
    }
    
}