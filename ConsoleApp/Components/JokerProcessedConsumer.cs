using MassTransit;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Components
{
    public class JokerProcessedConsumer : IConsumer<IProcessJoker>
    {
        public async Task Consume(ConsumeContext<IProcessJoker> context)
        {
        
            await context.RespondAsync<JokerProcessedOk>(new
            {
                CatalogName = context.Message.CatalogName,
                CatagoryName = context.Message.CatagoryName,
                Message = "Başarılı",
                Date = DateTime.Now 
            });
        }
    }
}
