using System;

namespace ArrayTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1차 배열
            string[] players = new string[10];

            var a = Love.God;
            Console.WriteLine(a);

            var spring = Seasons.Spring;
            var startingOnEquinox = Seasons.Spring | Seasons.Autumn | Seasons.Winter;
            var theYear = Seasons.All;

            Console.WriteLine(spring + " / " + startingOnEquinox + " / " + theYear);
        }

        public enum Love
        {
            God,
            Jesus,
            HolySpirit
        }

        [Flags]
        public enum Seasons
        {
            None = 0,
            Summer = 1,
            Autumn = 2,
            Winter = 4,
            Spring = 8,
            All = Summer | Autumn | Winter | Spring
        }
    }
}
