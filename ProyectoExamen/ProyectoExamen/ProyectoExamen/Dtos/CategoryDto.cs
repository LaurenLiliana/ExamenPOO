using ProyectoExamen.Entities;

namespace ProyectoExamen.Dtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
