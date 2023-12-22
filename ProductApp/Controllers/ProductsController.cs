using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
namespace ProductApp.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;//readonly olarak bir ifade tanımlandıysa ya constructor ya da tanımlandığı yerde set edilebilir.
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;//_logger concrete elde edilmiş oldu.
        }
        //9.satırdan 13.satıra kadar olan kısım pattern Dependency Injection'dır.
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var products = new List<Product>()
            {
                new Product() {ProductID=1, ProductName="Computer"},
                new Product() {ProductID=2,ProductName="Keyboard"},
                new Product() {ProductID=3,ProductName="Mouse"}
            };
            _logger.LogInformation("GetAllProducts action has been called");
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product) //Request Body sinden gelecektir.
        {
            _logger.LogWarning("Product has been created");
            return StatusCode(201);
        }
    }
}