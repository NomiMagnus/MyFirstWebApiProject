using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
           return await _productService.getProducts(desc, minPrice, maxPrice, categoryIds); 
        }
    }
}
