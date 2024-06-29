using Microsoft.AspNetCore.Mvc;
using ProyectoExamen.Dtos;
using ProyectoExamen.Entities;
using static ProyectoExamen.Services.Interfaces.ICategoryService;


[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }

    [HttpGet]
    public Task<ActionResult> GetAll()
    {
        var categories = _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public Task<ActionResult> GetCategory(Guid id)
    {
        var category = _categoryService.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public Task<ActionResult> CreateCategory(CategoryDto categoryDto)
    {
        _categoryService.CreateCategory(categoryDto);
        return CreatedAtAction(nameof(GetCategory), new { id = categoryDto.Id }, categoryDto);
    }

    [HttpGet("{id}/total-value")]
    public ActionResult<decimal> GetTotalInventoryValueByCategory(Guid id)
    {
        var totalValue = _categoryService.CalculateTotalInventoryValueByCategory(id);
        return Ok(totalValue);
    }
}
