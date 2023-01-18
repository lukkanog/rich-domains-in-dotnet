using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class Student 
    {
        public Student(Name name, Document document, Email email, string address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Address { get; private set; }
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
            foreach (var sub in Subscriptions) 
            {
                sub.Inactivate();
            }

            _subscriptions.Add(subscription);
        }
    }
    
}