using MassTransit;
using Models;
using System;

namespace ConsolePub
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
            });

     



            var message = new
            {
                CatalogName = "deniz",
                CatagoryName = "murat",
                IsAllJokerDefinitionsPaused = true
            };
            Console.WriteLine("Press any key to publish");
            Console.ReadKey();
            bus.Publish<IProcessJoker>(message);
            Console.WriteLine($"Published");


            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

       
        }
    }
}
