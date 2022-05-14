using Microsoft.AspNetCore.Mvc;
using Order.Business.Abstract;
using Order.DataAccess.Model;
using System.Diagnostics;

namespace Order.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderController(IProductService productService, IOrderService orderService,ILogger<OrderController> logger)
        {
            _logger = logger;
            _productService = productService;
            _orderService = orderService;
        }
        [HttpGet("{category}")]
        public async Task<IActionResult> GetProducts(string category)
        {
            var productList = await _productService.GetProductsByCategory(category);
            if (productList != null)
            {
                return Ok(productList);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("Order api is Logged with SeriLog...");
            var productList = await _productService.GetAllProducts();
            if (productList != null)
            {
                return Ok(productList);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrder)
        {
            
            var order = await _orderService.CreateOrder(createOrder);
            //_logger.LogInformation("{order} id li sipariş oluşturuldu...",order);
            return Ok(order);
        }
    }
}
