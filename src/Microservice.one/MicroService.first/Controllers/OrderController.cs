using System.Threading.Tasks;
using Framework.CQRS;
using Framework.CQRS.MediatRCommands;
using Microsoft.AspNetCore.Mvc;
using Product.Service.CQRS.AddProductCommand;

namespace MicroServiceWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IEventBus _bus;

        public OrderController(IEventBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateProductCommandRequest commandRequest)
        {
            // Uri uri=new Uri("rabbitmq://localhost/order_queue");
            // var endPoint = await _bus.GetSendEndpoint(uri);
            // await endPoint.Send<Order>(order);
            // _rabbit.Publish(order,"exchange.test","topic","*.queue.durable.#");
            var responseCommand = await _bus.Issue(commandRequest);
            return Ok(responseCommand);
        }
    }
}