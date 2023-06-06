namespace OnlineShoppingStore.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal DiscountTotal { get; set; }
    }
}
