using System;
using System.Collections.Generic;
using System.Threading;

namespace firstPractice
{
    class Program
    {
        class Pet
        {
            public string name;
            public int age;

        }

        class Person
        {
            public string name;
            public string address;
            public List<Pet> pets;
        }

        static void Main(string[] args)
        {
            Pet petA = new Pet() { name = "cloud", age = 7 };
            Pet petB = new Pet() { name = "star", age = 1 };

            Person person = new Person()
            {
                name = "byh",
                address = "Gimpo",
                pets = new List<Pet>() { petA, petB }
            };

            Console.WriteLine(petA.name + " : " + petA.age + "살");
            Console.WriteLine(petB.name + " : " + petB.age + "살");
            Console.WriteLine(person.name + " 주소 : " + person.address + "\n");
            Console.Write(person.name + " 애완동물 목록 : ");
            
            foreach (var pet in person.pets)
            {
                Console.Write(pet.name + " " + pet.age + "살\t");
            }
            Console.WriteLine();
        }
    }
}


