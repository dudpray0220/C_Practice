using System;
using System.Collections.Generic;
using System.Linq;

namespace productLinq
{
    class Program
    {
        private static object input;

        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public override string ToString()
            {
                return this.Name + " : " + this.Price;
            }
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Name = "potato", Price = 1000 },
                new Product() { Name = "carrot", Price = 2000 },
                new Product() { Name = "amond", Price = 3000 },
                new Product() { Name = "strawberry", Price = 1500 },
                new Product() { Name = "choco", Price = 1300 },
                new Product() { Name = "banana", Price = 2900 },
                new Product() { Name = "orange", Price = 500 }
            };

            var output = from item in products
                         where item.Price > 1500
                         orderby item.Name ascending
                         select item;

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
