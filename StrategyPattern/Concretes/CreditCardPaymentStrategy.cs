using StrategyPattern.Interfaces;

namespace StrategyPattern.Concretes
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}");
        }

    }
}
