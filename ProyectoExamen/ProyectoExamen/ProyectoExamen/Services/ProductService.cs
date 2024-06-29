using Newtonsoft.Json;
using ProyectoExamen.Dtos;
using ProyectoExamen.Entities;
using static ProyectoExamen.Entities.Product;
using static ProyectoExamen.Services.Interfaces.IProductService;

namespace ProyectoExamen.Services
{
    public class ProductService : IProductService
    {
        public readonly string _JSON_FILE;
       
        public ProductService()
        {
            _JSON_FILE = "SeedData/json.json";
        }
        public ProductService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Product> GetProducts()
        {
            return LoadProductsFromFile();
        }

        public Product GetProductById(int id)
        {
            var products = LoadProductsFromFile();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(ProductDto productDto)
        {
            var products = LoadProductsFromFile();
            var newProduct = new Product
            {
                Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1,
                Name = productDto.Name,
                Quantity = productDto.Quantity,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };
            products.Add(newProduct);
            SaveProductsToFile(products);
        }

        public void UpdateProduct(int id, ProductDto productDto)
        {
            var products = LoadProductsFromFile();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Quantity = productDto.Quantity;
                product.Price = productDto.Price;
                product.CategoryId = productDto.CategoryId;
                SaveProductsToFile(products);
            }
        }

        public void DeleteProduct(int id)
        {
            var products = LoadProductsFromFile();
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                SaveProductsToFile(products);
            }
        }

        public void AssignProductToCategory(int productId, int categoryId)
        {
            var products = LoadProductsFromFile();
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.CategoryId = categoryId;
                SaveProductsToFile(products);
            }
        }

        public decimal CalculateTotalInventoryValue()
        {
            var products = LoadProductsFromFile();
            return products.Sum(p => p.Price * p.Quantity);
        }

        private void SaveProductsToFile(List<Product> products)
        {
            var json = JsonConvert.Serialize(products);
            File.WriteAllText(_JSON_FILE, json);
        }

        private List<Product> LoadProductsFromFile()
        {
            var json =JsonConvert.SerializeObject(json, Formatting.Indented);
            if (File.Exists(_JSON_FILE))

                await File.WriteAllTextAsync(_JSON_FILE, json);
        }
            return new List<Product>();
        }
    }

}




