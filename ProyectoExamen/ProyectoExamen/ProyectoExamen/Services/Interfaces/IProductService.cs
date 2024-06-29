using Microsoft.AspNetCore.Mvc;
using ProyectoExamen.Dtos;
using ProyectoExamen.Entities;
using ProyectoExamen.Services.Interfaces;
using static ProyectoExamen.Entities.Product;

namespace ProyectoExamen.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(ProductDto productDto);
        void UpdateProduct(int id, ProductDto productDto);
        void DeleteProduct(int id);
        void AssignProductToCategory(int productId, int categoryId);
        decimal CalculateTotal();
     }
}

