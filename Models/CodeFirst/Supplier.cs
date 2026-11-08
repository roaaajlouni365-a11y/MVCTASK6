
using UniversityCafeteria.Models.DatabaseFirst;

namespace UniversityCafeteria.Models.CodeFirst
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public ICollection<Product> Products { get; set; }
            = new List<Product>();
    }
}
