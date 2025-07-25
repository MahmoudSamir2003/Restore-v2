using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>();

            context.Database.Migrate();

            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Wired Headphones",
                    Description = "High quality wired headphones.",
                    Price = 150,
                    PictureUrl = "boot-ang1.png",
                    Type = "Headphones",
                    Brand = "Sony",
                    QuantityInStock = 15
                },
                new Product
                {
                    Name = "Bluetooth Speaker",
                    Description = "Portable Bluetooth speaker with deep bass.",
                    Price = 300,
                    PictureUrl = "boot-ang2.png",
                    Type = "Speakers",
                    Brand = "JBL",
                    QuantityInStock = 25
                },
                new Product
                {
                    Name = "Smart Watch",
                    Description = "Fitness tracking smartwatch with AMOLED display.",
                    Price = 500,
                    PictureUrl = "boot-core1.png",
                    Type = "Wearables",
                    Brand = "Xiaomi",
                    QuantityInStock = 30
                },
                new Product
                {
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with adjustable DPI.",
                    Price = 100,
                    PictureUrl = "boot-core2.png",
                    Type = "Accessories",
                    Brand = "Logitech",
                    QuantityInStock = 20
                },
                new Product
                {
                    Name = "Gaming Keyboard",
                    Description = "Mechanical gaming keyboard with RGB backlight.",
                    Price = 400,
                    PictureUrl = "boot-redis1.png",
                    Type = "Accessories",
                    Brand = "Corsair",
                    QuantityInStock = 12
                },
                new Product
                {
                    Name = "Laptop Stand",
                    Description = "Adjustable laptop stand for desk use.",
                    Price = 120,
                    PictureUrl = "glove-code1.png",
                    Type = "Accessories",
                    Brand = "AmazonBasics",
                    QuantityInStock = 40
                },
                new Product
                {
                    Name = "USB-C Hub",
                    Description = "7-in-1 USB-C hub with HDMI, USB and SD card reader.",
                    Price = 250,
                    PictureUrl = "glove-code2.png",
                    Type = "Adapters",
                    Brand = "Anker",
                    QuantityInStock = 35
                },
                new Product
                {
                    Name = "Power Bank 20000mAh",
                    Description = "High-capacity portable charger with fast charging.",
                    Price = 220,
                    PictureUrl = "glove-react1.png",
                    Type = "Power",
                    Brand = "Anker",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Car Phone Holder",
                    Description = "Magnetic phone holder for car dashboard.",
                    Price = 80,
                    PictureUrl = "hat-core1.png",
                    Type = "Car Accessories",
                    Brand = "Baseus",
                    QuantityInStock = 60
                },
                new Product
                {
                    Name = "Noise Cancelling Earbuds",
                    Description = "Wireless earbuds with active noise cancellation.",
                    Price = 600,
                    PictureUrl = "sb-core2.png",
                    Type = "Earbuds",
                    Brand = "Samsung",
                    QuantityInStock = 18
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
