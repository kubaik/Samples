using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Maestria.Extensions;

namespace MaestriaExtensionsDemo
{
    public enum MyColors
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black
    }

    class Program
    {
        private static readonly MyColors[] RgbColors = {MyColors.Red, MyColors.Green, MyColors.Blue};

        static void Main(string[] args)
        {
            var color = MyColors.Yellow;
            Console.WriteLine(color + " in RGB: " + color.In(RgbColors));
            Console.WriteLine(color + " in Non-RGB: " + color.In(MyColors.Yellow, MyColors.White, MyColors.Black));
            Console.WriteLine(1.In(1, 5, 9));
            Console.WriteLine();

            Console.WriteLine(5.Between(3, 8));
            Console.WriteLine(5.Between(5, 8));
            Console.WriteLine(5.Between(6, 8));
        }
    }
}