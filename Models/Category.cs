using OnlineShoppingStore.CrossCuttingConcerns.Shared.General.Entities;

namespace OnlineShoppingStore.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}
