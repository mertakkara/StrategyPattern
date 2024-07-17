namespace StrategyPattern.Interfaces
{
    public interface IPaymentContext
    {
        void SetPaymentStrategy(IPaymentStrategy paymentStrategy);
        void ExecutePayment(decimal amount);

    }
}
