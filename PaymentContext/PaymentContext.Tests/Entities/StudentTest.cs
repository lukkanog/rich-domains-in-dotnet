using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests 
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddSubscription() {
            var subscription = new Subscription(null);

            var student = new Student(
                "Bruce",
                "Wayne",
                "12345678910",
                "imnotbatman@wayne.com",
                "Wayne Manor, Gotham City"
            );

            student.AddSubscription(subscription);        }
    }
}