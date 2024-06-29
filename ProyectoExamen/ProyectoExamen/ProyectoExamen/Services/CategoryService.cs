using Newtonsoft.Json;
using ProyectoExamen.Dtos;
using ProyectoExamen.Entities;
using ProyectoExamen.Services.Interfaces;

namespace ProyectoExamen.Services
{

    public class CategoryService : ICategoryService
    {
        private readonly string _JSON_FILE;

        public CategoryService()
        {
            _JSON_FILE =" SeedData/categories.json"
        }

        public List<Category> GetCategories()
        {
            return LoadCategoriesFromFile();
        }

        public Category GetCategoryById(Guid id)
        {
            var categories = LoadCategoriesFromFile();
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCategory(CategoryDto categoryDto)
        {
            var categories = LoadCategoriesFromFile();
            var newCategory = new Category
            {
                Id = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1,
                Name = categoryDto.Name,
                Products = new List<Product>()
            };
            categories.Add(newCategory);
            SaveCategoriesToFile(categories);
        }

        public decimal CalculateTotal(int categoryId)
        {
            var products = _productService.GetProducts();
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                return products.Where(p => p.CategoryId == categoryId).Sum(p => p.Price * p.Quantity);
            }
            return 0;
        }

        private void SaveCategoriesToFile(List<Category> categories)
        {
            var json = JsonConvert(categories);
            File.WriteAllText(_JSON_FILE, json);
        }

        private List<Product> LoadProductsFromFile()
        {
            var json = JsonConvert.SerializeObject(json, Formatting.Indented);
            if (File.Exists(_JSON_FILE))

               await File.WriteAllTextAsync(_JSON_FILE, json);
        }
            return new List<Product>();
        }
}

}

