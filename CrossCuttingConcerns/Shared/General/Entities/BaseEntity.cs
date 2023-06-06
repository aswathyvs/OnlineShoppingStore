namespace OnlineShoppingStore.CrossCuttingConcerns.Shared.General.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
    }
}
