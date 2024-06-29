using ProyectoExamen.Dtos;
using ProyectoExamen.Entities;

namespace ProyectoExamen.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(Guid id);
        void CreateCategory(CategoryDto categoryDto);
        decimal CalculateTotal(int categoryId);
    }
}

