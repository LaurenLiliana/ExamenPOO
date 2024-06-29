using Microsoft.AspNetCore.Mvc;
using ProyectoExamen.Dtos;
using ProyectoExamen.Entities;
using static ProyectoExamen.Entities.Product;
using static ProyectoExamen.Services.Interfaces.IProductService;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet]
    public  Task<ActionResult> GetProducts()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(Guid id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(ProductDto productDto)
    {
        _productService.CreateProduct(productDto);
        return CreatedAtAction(nameof(GetProduct), new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, ProductDto productDto)
    {
        _productService.UpdateProduct(id, productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        return NoContent();
    }

    [HttpPost("{productId}/categories/{categoryId}")]
    public IActionResult AssignProductToCategory(int productId, int categoryId)
    {
        _productService.AssignProductToCategory(productId, categoryId);
        return NoContent();
    }

    [HttpGet("total-value")]
    public ActionResult<decimal> GetTotalInventoryValue()
    {
        var totalValue = _productService.CalculateTotalInventoryValue();
        return Ok(totalValue);
    }
}



