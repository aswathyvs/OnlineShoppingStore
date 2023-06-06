﻿namespace OnlineShoppingStore.Models
{
    public class CartItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; } = 0;
        public decimal DiscountedAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }
        public string Image { get; set; }

        public CartItem()
        {
        }

        public CartItem(Product product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            Price = product.Price;
            Discount = product.Discount;
            Quantity = 1;
            Image = product.Image;
        }
    }
}
