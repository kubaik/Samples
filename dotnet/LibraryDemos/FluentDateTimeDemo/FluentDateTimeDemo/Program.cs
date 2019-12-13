using System;
using System.Globalization;
using System.Threading;
using FluentDate;
using FluentDateTime;

namespace FluentDateTimeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(DateTime.Now.PreviousDay());
            Console.WriteLine(DateTime.Now.BeginningOfDay());
            Console.WriteLine(DateTime.Now.EndOfDay());

            Console.WriteLine(DateTime.Now.BeginningOfDay().Previous(DayOfWeek.Sunday));
            Console.WriteLine(DateTime.Now.EndOfDay().Previous(DayOfWeek.Sunday));

            Console.WriteLine(DateTime.Now.AddBusinessDays(1));
            Console.WriteLine(DateTime.Now.AddBusinessDays(10));

            Console.WriteLine(DateTime.Now.LastDayOfWeek());
            Console.WriteLine(DateTime.Now.LastDayOfWeek().Next(DayOfWeek.Sunday).EndOfDay());

            Console.WriteLine("BeginningOfWeek: " + DateTime.Now.BeginningOfWeek());
            Console.WriteLine("EndOfWeek: " + DateTime.Now.EndOfWeek());

            Console.WriteLine(DateTime.Now.StartOfWeek());


//            var inicio = new DateTime(2019, 07, 10);
//            var fim = new DateTime(2019, 07, 14);
//            Console.WriteLine(inicio.);

//            Console.WriteLine(Math.Sign(10));
//            Console.WriteLine(Math.Sign(0));
//            Console.WriteLine(Math.Sign(-10));

        }
    }
}