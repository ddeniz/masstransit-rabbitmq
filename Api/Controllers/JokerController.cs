using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokerController : ControllerBase
    {
        private readonly ILogger<JokerController> _logger;
        private readonly IRequestClient<IProcessJoker> _requestClient;
        private readonly IPublishEndpoint _publishEndpoint;

        public JokerController(ILogger<JokerController> logger, IRequestClient<IProcessJoker> requestClient, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _requestClient = requestClient;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string catalog, string catagory)
        {
            var respuesta = await _requestClient.GetResponse<JokerProcessedOk>(new
            {
                CatalogName = catalog,
                CatagoryName = catagory,
                IsAllJokerDefinitionsPaused = true

            });
            return Ok(respuesta);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var obj = new
            {
                CatalogName = "burak",
                CatagoryName = "levent",
                IsAllJokerDefinitionsPaused = true

            };
            await _publishEndpoint.Publish<IProcessJoker>(obj);
            return Ok(obj);
        }


    }
}
