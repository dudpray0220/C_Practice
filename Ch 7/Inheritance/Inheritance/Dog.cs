using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Dog : Animal
    {
        public string color { get; set; }

        public void Bark() { Console.WriteLine("멍멍"); }
        public void Test()
        {
            base.Eat();
            Sleep();
        }
    }
}
