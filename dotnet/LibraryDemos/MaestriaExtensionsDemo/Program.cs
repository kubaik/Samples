using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using Maestria.Extensions;

namespace MaestriaExtensionsDemo
{
    public enum MyColors
    {
        [Display(Name = "RED", Description = "Color is RED")]
        Red,

        [DisplayName("GREEN")] [Description("Color is GREEN")]
        Green,

        Blue,
        Yellow,
        White,
        Black
    }

    class Program
    {
        private static readonly MyColors[] RgbColors = {MyColors.Red, MyColors.Green, MyColors.Blue};
        private static readonly List<int> Values = new List<int> {15, 10, 4, 9};

        private static readonly Dictionary<string, object> Dic = new Dictionary<string, object>
        {
            {"name", "Fábio"},
            {"age", 32},
        };

        static void Main(string[] args)
        {
            Console.WriteLine($"{new string('-', 25)} AggregateExtensions {new string('-', 25)}");
            Console.WriteLine("Max value: " + AggregateExtensions.Max(15, 10, 4, 9));
            Console.WriteLine("Max value: " + new[] {15, 10, 4, 9}.Max());
            Console.WriteLine("Min value: " + AggregateExtensions.Min(15, 10, 4, 9));
            Console.WriteLine("Min value: " + new[] {15, 10, 4, 9}.Min());
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} Base64Extensions {new string('-', 25)}");
            Console.WriteLine($"Base64 encode: {Base64Extensions.Encode("my test")}");
            Console.WriteLine($"Base64 decode: {Base64Extensions.Decode("bXkgdGVzdA==")}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} CollectionExtensions {new string('-', 25)}");
            Console.WriteLine($"IsNullOrEmpty: {Values.IsNullOrEmpty()}");
            Console.WriteLine($"HasItems: {Values.HasItems()}");
            Values.Iterate((item, index) => Console.WriteLine($"Iterate {index}: {item}"));
            Console.WriteLine($"Dicionary TryGetValue name: {Dic.TryGetValue("name")}");
            Console.WriteLine($"Dicionary TryGetValue age: {Dic.TryGetValue("age")}");
            Console.WriteLine($"Dicionary TryGetValue birthday: {Dic.TryGetValue("birthday", "unavailable")}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} EnumExtensions {new string('-', 25)}");
            Console.WriteLine($"GetDisplayName: {MyColors.Red.GetDisplayName()}");
            Console.WriteLine($"GetDisplayName: {MyColors.Green.GetDisplayName()}");
            Console.WriteLine($"GetDescription: {MyColors.Red.GetDescription()}");
            Console.WriteLine($"GetDescription: {MyColors.Green.GetDescription()}");
            Console.WriteLine(
                $"GetValues: { EnumExtensions.GetValues<MyColors>().Select(i => i.ToString()).Join(", ") }");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} ExceptionExtensions {new string('-', 25)}");
            try
            {
                int.Parse("a");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToLogString());
                Console.WriteLine();

                var ex2 = new Exception("Test", e);
                Console.WriteLine($"GetMostInner: {e.GetMostInner().Message}");
            }

            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} HashExtensions {new string('-', 25)}");
            Console.WriteLine($"    MD5: {"Maestria Extensions".GetHashMd5()}");
            Console.WriteLine($"  SHA 1: {"Maestria Extensions".GetHashSha1()}");
            Console.WriteLine($"SHA 256: {"Maestria Extensions".GetHashSha256()}");
            Console.WriteLine($"SHA 384: {"Maestria Extensions".GetHashSha384()}");
            Console.WriteLine($"SHA 512: {"Maestria Extensions".GetHashSha512()}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} IfNullExtensions {new string('-', 25)}");
            Console.WriteLine($"IffNull: {((int?) null).IfNull(999)}");
            Console.WriteLine($"IfNullOrEmpty: {((string) null).IfNullOrEmpty("empty string")}");
            Console.WriteLine($"IffNull: {"   ".IfNullOrWhiteSpace("empty string")}");
            Console.WriteLine($"IffNull: {"   ".IfNullOrWhiteSpace("empty string")}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} NullIfExtensions {new string('-', 25)}");
            Console.WriteLine($"NullIf: {10.NullIf(10)}");
            Console.WriteLine($"NullIf: {10.4f.NullIf(10, 1)}");
            Console.WriteLine($"NullIf: {10.4f.NullIf(10)}");
            Console.WriteLine($"NullIfBetween: {10.4f.NullIfBetween(5, 12)}");
            Console.WriteLine($"NullIfIn: {10.NullIfIn(9, 10, 11)}");
            Console.WriteLine($"NullIfEmpty: {"".NullIfEmpty()}");
            Console.WriteLine($"NullIfWhiteSpace: {"  ".NullIfWhiteSpace()}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} RoundExtensions {new string('-', 25)}");
            Console.WriteLine($"Round: {10.4f.Round()}");
            Console.WriteLine($"Round: {10.422f.Round(1)}");
            Console.WriteLine($"RoundUp: {10.4f.RoundUp()}");
            Console.WriteLine($"RoundUp: {10.422f.RoundUp(1)}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} StringExtensions {new string('-', 25)}");
            Console.WriteLine($"RemoveIfStartsWith: {"name is Fábio".RemoveIfStartsWith("name ")}");
            Console.WriteLine($"RemoveIfEndsWith: {"name is Fábio".RemoveIfEndsWith(" Fábio")}");
            Console.WriteLine($"AddToLeftIfNotStartsWith: {"Fábio".AddToLeftIfNotStartsWith("name is ")}");
            Console.WriteLine($"AddToRightIfNotEndsWith: {"name is".AddToRightIfNotEndsWith(" Fábio")}");
            Console.WriteLine($"AddToLeftIfHasValue: {"Fábio".AddToLeftIfHasValue("name is ")}");
            Console.WriteLine($"AddToRightIfHasValue: {"name is".AddToRightIfHasValue(" Fábio")}");
            Console.WriteLine($"Format: {"name is {0}".Format("Fábio")}");
            Console.WriteLine($"IsNullOrEmpty: {string.Empty.IsNullOrEmpty()}");
            Console.WriteLine($"IsNullOrWhiteSpace: {string.Empty.IsNullOrWhiteSpace()}");
            Console.WriteLine($"HasValue: {string.Empty.HasValue()}");
            Console.WriteLine($"EqualsIgnoreCase: {"Fábio".EqualsIgnoreCase("Fábio")}");
            Console.WriteLine($"OnlyNumber: {"123abc456".OnlyNumbers()}");
            Console.WriteLine($"OnlyNumber: {"value is: $ -8.456".OnlyNumbers(true, true, CultureInfo.GetCultureInfo("en"))}");
            Console.WriteLine($"RemoveAccents: {"áéíóúãõ".RemoveAccents()}");
            Console.WriteLine($"Join: {new[] {"My", "name", "is", "Fábio"}.Join(" ")}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} SyntaxExtensions {new string('-', 25)}");
            var color = MyColors.Yellow;
            Console.WriteLine(color + " in RGB: " + color.In(RgbColors));
            Console.WriteLine(color + " in Non-RGB: " + color.In(MyColors.Yellow, MyColors.White, MyColors.Black));
            Console.WriteLine($"In: {1.In(1, 5, 9)}");
            Console.WriteLine($"Between: {5.Between(3, 8)}");
            Console.WriteLine($"Between: {5.Between(5, 8)}");
            Console.WriteLine($"Between: {5.Between(6, 8)}");
            Console.WriteLine();

            Console.WriteLine($"{new string('-', 25)} TruncateExtensions {new string('-', 25)}");
            Console.WriteLine($"Truncate: {10.9f.Truncate()}");
            Console.WriteLine($"Truncate: {10.499f.Truncate(1)}");
            Console.WriteLine();
        }
    }
}