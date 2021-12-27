using System;
using System.Collections.Generic;

namespace interface01
{
    class Program
    {
        class Product : IComparable
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public override string ToString()
            {
                return Name + " : " + Price + "원";
            }

            public int CompareTo(object obj)
            {
                return this.Price.CompareTo((obj as Product).Price);
            }
        }

        static void Main(string[] args)
        {
            List<Product> list = new List<Product>()
            {
                new Product() {Name = "potato", Price = 5000 },
                new Product() {Name = "carrot", Price = 2000 },
                new Product() {Name = "peach", Price = 3000 },
                new Product() {Name = "amond", Price = 10000 }
            };
            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
