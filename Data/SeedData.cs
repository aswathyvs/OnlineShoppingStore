using Microsoft.EntityFrameworkCore;
using OnlineShoppingStore.CrossCuttingConcerns.Shared.General.Constants;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Data
{
    public class SeedData
    {
        public static void SeedDatabase(OnlineShoppingStoreContext context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {

                Category mobilePhones = new Category
                {
                    Name = "Mobile Phones",
                    Slug = "mobiles",
                    CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                    ModifiedDate = DateTime.Now
                };

                Category laptops = new()
                {
                    Name = "Laptops",
                    Slug = "laps",
                    CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                    ModifiedDate = DateTime.Now
                };

                context.Products.AddRange(
                        new Product
                        {
                            Name = "OnePlus 11 5G",
                            Slug = "Android",
                            Description = "OnePlus 11 5G (Eternal Green, 8GB RAM, 128GB Storage)",
                            Price = 50000.00M,
                            Discount = 5.00M,
                            Category = mobilePhones,
                            Image = "mobile1.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Samsung Galaxy M04 Dark Blue",
                            Slug = "Android",
                            Description = "Samsung Galaxy M04 Dark Blue, 4GB RAM, 64GB Storage",
                            Price = 8500.00M,
                            Discount = 10.00M,
                            Category = mobilePhones,
                            Image = "mobile2.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Oppo F23 5G",
                            Slug = "Android",
                            Description = "Oppo F23 5G (Bold Gold, 8GB RAM, 256GB Storage)",
                            Price = 25000.00M,
                            Discount = 20.00M,
                            Category = mobilePhones,
                            Image = "mobile3.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Nokia C12",
                            Slug = "Android",
                            Description = "Nokia C12 Android 12 (Go Edition) Smartphone",
                            Price = 7500.00M,
                            Discount = 5.00M,
                            Category = mobilePhones,
                            Image = "mobile4.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Apple iPhone 14 Pro Max",
                            Slug = "Apple",
                            Description = "Apple iPhone 14 Pro Max (256 GB) - Deep Purple",
                            Price = 150000.00M,
                            Discount = 9.00M,
                            Category = mobilePhones,
                            Image = "mobile5.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Lenovo IdeaPad Slim 3",
                            Slug = "Laptop",
                            Description = "Intel Core i3 11th Gen 14",
                            Price = 37000.00M,
                            Discount = 38.00M,
                            Category = laptops,
                            Image = "lap1.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "HP Chromebook 13",
                            Slug = "Laptop",
                            Description = "G1 6th Gen Intel Core m5 FHD",
                            Price = 15000.00M,
                            Discount = 83.00M,
                            Category = laptops,
                            Image = "lap2.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "DELL Latitude 5490",
                            Slug = "Laptop",
                            Description = "Core i5 7th Gen Laptop",
                            Price = 20000.00M,
                            Discount = 59.00M,
                            Category = laptops,
                            Image = "lap3.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Apple 2023 MacBook Pro",
                            Slug = "Laptop",
                            Description = "Laptop M2 Pro chip",
                            Price = 200000.00M,
                            Discount = 0.00M,
                            Category = laptops,
                            Image = "lap4.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        },
                        new Product
                        {
                            Name = "Dell Vostro 3510 Laptop",
                            Slug = "Laptop",
                            Description = "Intel Core i5-1135G7",
                            Price = 52000.00M,
                            Discount = 26.00M,
                            Category = laptops,
                            Image = "lap5.jpg",
                            CreatedBy = OnlineShoppingStoreConstants.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = OnlineShoppingStoreConstants.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        }
                );

                context.SaveChanges();
            }
        }
    }
}
