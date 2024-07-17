using StrategyPattern.Interfaces;

namespace StrategyPattern.Concretes
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {

        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }

    }
}
