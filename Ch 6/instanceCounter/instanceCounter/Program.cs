using System;
using System.Collections.Generic;
using System.Threading;

namespace firstPractice
{
    class Program
    {
        class Product
        {
            public static int counter = 0;
            public int id;
            public string name;
            public int price;

            public Product(string name, int price) // 생성자
            {
                Product.counter += 1; // 클래스 변수
                this.id = counter;
                this.name = name;
                this.price = price;
            }
        }

        public static void Main(string[] args)
        {
            Product productA = new Product("potato", 2000); // 생성자로 인스턴스 생성
            Product productB = new Product("carrot", 1000);

            Console.WriteLine(productA.id + ". " + productA.name + " : " + productA.price);
            Console.WriteLine(productB.id + ". " + productB.name + " : " + productB.price);
            Console.WriteLine(Product.counter + "개 생성");
        }
    }
}


