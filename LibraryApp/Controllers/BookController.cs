
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using webserver.Entities;
using webserver.Repositories;


namespace webserver.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]

public class BookController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepository;

    public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    } //

    //get all products
    [HttpGet]
    [Route("GetProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productRepository.GetAllProducts();
        return Ok(products);
    }

    //get product by id
    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productRepository.GetProductById(id);

        return Ok(product);
    }

    //create product
    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        product = await _productRepository.CreateProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    //update product
    [HttpPut("{id:int}", Name = "UpdateProduct")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        await _productRepository.UpdateProduct(id, product);
        return NoContent();
    }

    //delete product
    [HttpDelete("{id:int}", Name = "DeleteProduct")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        await _productRepository.DeleteProduct(id);
        return NoContent();
    }
}