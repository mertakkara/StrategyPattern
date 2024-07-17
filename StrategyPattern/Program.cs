
using StrategyPattern.Concretes;
using StrategyPattern.Interfaces;

namespace StrategyPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IPaymentContext, PaymentContext>();
            builder.Services.AddSingleton<CreditCardPaymentStrategy>();
            builder.Services.AddSingleton<PayPalPaymentStrategy>();
            builder.Services.AddSingleton<BitcoinPaymentStrategy>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapPost("/pay", async (decimal amount,
                           string method,
                           IPaymentContext paymentContext,
                           IServiceProvider serviceProvider) =>
            {
                IPaymentStrategy strategy = method.ToLower() switch
                {
                    "creditcard" => serviceProvider.GetService<CreditCardPaymentStrategy>(),
                    "paypal" => serviceProvider.GetService<PayPalPaymentStrategy>(),
                    "bitcoin" => serviceProvider.GetService<BitcoinPaymentStrategy>(),
                    _ => throw new NotSupportedException("Invalid payment method selected.")
                };

                paymentContext.SetPaymentStrategy(strategy);
                paymentContext.ExecutePayment(amount);

                return Results.Ok($"Payment of {amount:C} using {method} processed successfully.");
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
