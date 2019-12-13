using System;
using System.Globalization;
using FluentCast;

namespace FluentCastDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // fixed point
            short int16Value = "150".ToInt16();
            int int32Value = "150".ToInt32();
            long int64Value = "150".ToInt64();
            int int32ValueFromStringFloating = "150.345".ToInt32();
            int int32ValueFromDouble = 150.345.ToInt32();

            // floating point
            float floatInvariantValue = "150.45".ToFloat();
            double doubleEnValue = "150.45".ToDouble(CultureInfo.GetCultureInfo("en"));
            decimal decimalPtValue = "150,45".ToDecimal(CultureInfo.GetCultureInfo("pt-BR"));

            // date time
            DateTime dateInvariantValue = "2019-06-29 13:31:59".ToDateTime();
            DateTime dateEnValue = "6/29/19 1:31:59 PM".ToDateTime(CultureInfo.GetCultureInfo("en"));
            DateTime datePtValue = "29/06/2019 13:31:59".ToDateTime(CultureInfo.GetCultureInfo("pt-BR"));

            // guid
            Guid guidValue = "a7fb69ba-7922-4d88-9569-d8d0d6641b86".ToGuid();

            // string
            string stringValue = ((object) null).ToStringSafe(); // out is a empty string

            // safe conversion support
            int? int32SafeNullableValue = "broken input".ToInt32Safe(); // out is nullable int
            int int32SafeValue = "broken input".ToInt32Safe(-1); // out is -1
            DateTime? dateSafeNullableValue = "broken input".ToDateTimeSafe(); // out is nullable DateTime
            DateTime dateSafeValue = "broken input".ToDateTimeSafe(DateTime.Today); // out is today DateTime

            // exception throws
//            "broken input".ToInt32();
//            "broken input".ToDecimal();
//            "broken input".ToDateTime();
//            "broken input".ToGuid();

            // Crazy fluent pipeline
            var crazyPipeline = "source"
                .ToGuidSafe()
                .ToInt16Safe()
                .ToInt32Safe()
                .ToInt32Safe()
                .ToFloatSafe()
                .ToDoubleSafe()
                .ToDecimalSafe()
                .ToStringSafe();

            Console.WriteLine(int16Value);
            Console.WriteLine(int32Value);
            Console.WriteLine(int32ValueFromStringFloating);
            Console.WriteLine(int32ValueFromDouble);
            Console.WriteLine(int64Value);
            Console.WriteLine(floatInvariantValue);
            Console.WriteLine(doubleEnValue);
            Console.WriteLine(decimalPtValue);
            Console.WriteLine(dateInvariantValue);
            Console.WriteLine(dateEnValue);
            Console.WriteLine(datePtValue);
            Console.WriteLine(guidValue);
            Console.WriteLine(stringValue);

            Console.WriteLine(int32SafeNullableValue);
            Console.WriteLine(int32SafeValue);
            Console.WriteLine(dateSafeNullableValue);
            Console.WriteLine(dateSafeValue);

            Console.WriteLine(crazyPipeline);
        }
    }
}