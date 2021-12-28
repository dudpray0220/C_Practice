using System;
using System.Collections.Generic;

namespace delegate01
{
    class Program
    {
        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        static void Main(string[] args)
        {
            // 리스트 생성
            List<Product> products = new List<Product>()
            {
                new Product() {Name = "potato", Price = 1000 },
                new Product() {Name = "peach", Price = 12000 },
                new Product() {Name = "orange", Price = 7000 },
                new Product() {Name = "carrot", Price = 4000 },
                new Product() {Name = "amond", Price = 3000 }
            };

            // 정렬
            products.Sort((a, b) => a.Price.CompareTo(b.Price));

            // 출력
            foreach (var item in products)
            {
                Console.WriteLine(item.Name + " : " + item.Price);
            }
        }
    }
}
