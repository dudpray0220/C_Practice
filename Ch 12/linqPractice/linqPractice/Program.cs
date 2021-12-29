using System;
using System.Collections.Generic;
using System.Linq;

namespace linqPractice
{
    class Program
    {
        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public override string ToString()
            {
                return this.Name + " : " + this.Price + "원" ;
            }
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product() {Name = "고구마", Price = 1500 },
                new Product() {Name = "사과", Price = 2400 },
                new Product() {Name = "바나나", Price = 1000 },
                new Product() {Name = "배", Price = 3000 }
            };

            var output = from item in products
                         where item.Price < 2000
                         orderby item.Price descending
                         select item;

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
