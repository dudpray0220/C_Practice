using System;

namespace FactoryMethodPattern02
{
    // Product abstract class
    abstract class Product
    {

    }
    // A ConcreteProduct class
    class ConcreteProductA : Product
    {

    }
    // B ConcreteProduct class
    class ConcreteProductB : Product
    {

    }

    // ---------------------------------------------------------------------------------------------------------------

    // Creator abstract class
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }
    // A ConcreteCreator class
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()      // return type은 Product인 Method
        {
            return new ConcreteProductA();
        }
    }
    // B ConcreteCreator class
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()     // return type은 Product인 Method
        {
            return new ConcreteProductB();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {   // 배열로 객체생성
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            Console.ReadKey();
        }
    }
}
