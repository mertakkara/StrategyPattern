namespace StrategyPattern.Interfaces
{
    public interface IPaymentStrategy
    {
        void ProcessPayment(decimal amount);
    }
}
