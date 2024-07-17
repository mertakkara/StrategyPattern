using StrategyPattern.Interfaces;

namespace StrategyPattern.Concretes
{
    public class BitcoinPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Bitcoin payment of {amount:C}");
        }

    }
}
