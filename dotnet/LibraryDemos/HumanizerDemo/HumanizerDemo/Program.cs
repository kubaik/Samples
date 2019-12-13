using System;
using Humanizer;
using Humanizer.Configuration;
using Humanizer.DateTimeHumanizeStrategy;

namespace HumanizerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

//            Humanizer.ini

//            Configurator.DateTimeHumanizeStrategy = new PrecisionDateTimeHumanizeStrategy(precision: .75);
//            Configurator.DateTimeOffsetHumanizeStrategy = new PrecisionDateTimeOffsetHumanizeStrategy(precision: .75); // configure when humanizing DateTimeOffset

            Console.WriteLine("PascalCaseInputStringIsTurnedIntoSentence".Humanize());
            Console.WriteLine("Underscored_input_string_is_turned_into_sentence".Humanize());
            Console.WriteLine("Underscored_input_String_is_turned_INTO_sentence".Humanize());
            Console.WriteLine("HUMANIZER".Transform(To.LowerCase, To.TitleCase));
            Console.WriteLine("Lon".Truncate(6));
            Console.WriteLine("Long text to truncate".Truncate(6, ""));
            Console.WriteLine("Long text to truncate".Truncate(6));
            Console.WriteLine("Long text to truncate".Truncate(6, "---"));
            Console.WriteLine("Long text to truncate".Truncate(6, "..."));
            Console.WriteLine(DateTime.UtcNow.AddDays(-1).Humanize());
            Console.WriteLine(DateTime.UtcNow.AddHours(-1).Humanize());
            Console.WriteLine(DateTime.UtcNow.Humanize());
            Console.WriteLine(DateTime.UtcNow.AddMinutes(10).Humanize());
            Console.WriteLine(DateTime.UtcNow.AddMinutes(60).Humanize());

            Console.WriteLine(DateTime.UtcNow.AddSeconds(45).Humanize());
            Console.WriteLine(DateTime.UtcNow.AddSeconds(-45).Humanize());
            Console.WriteLine(DateTime.UtcNow.AddSeconds(46).Humanize());
            Console.WriteLine(DateTime.UtcNow.AddSeconds(-46).Humanize());
            Console.WriteLine(DateTime.UtcNow.ToOrdinalWords());

            Console.WriteLine("homem".Pluralize());
            Console.WriteLine("mulher".Pluralize());
            Console.WriteLine("carro".Pluralize());

            Console.WriteLine("carro".ToQuantity(1));
            Console.WriteLine("carro".ToQuantity(1));
            Console.WriteLine(1.Ordinalize());
            Console.WriteLine(2.Ordinalize());
            Console.WriteLine(3.Ordinalize());
            Console.WriteLine(4.Ordinalize());
            Console.WriteLine(1.ToOrdinalWords());
            Console.WriteLine(2.ToOrdinalWords());
            Console.WriteLine(3.ToOrdinalWords());
            Console.WriteLine(4.ToOrdinalWords());

            Console.WriteLine("fáBio Monteiro_naspolini".Titleize());
            Console.WriteLine("fáBio Monteiro_naspolini".Pascalize());
            Console.WriteLine("fáBio Monteiro_naspolini".Camelize());
            Console.WriteLine("fáBio Monteiro_naspolini".Dasherize());
            Console.WriteLine("fáBio Monteiro_naspolini".Hyphenate());
            Console.WriteLine("fáBio Monteiro_naspolini".Kebaberize());

            Console.WriteLine(1.ToWords());
            Console.WriteLine(2.ToWords());
            Console.WriteLine(225.ToWords());
            Console.WriteLine(2252.ToWords());
            Console.WriteLine(2252.ToWords(GrammaticalGender.Feminine));

            Console.WriteLine(1d.ToMetric());
            Console.WriteLine(1230d.ToMetric());
            Console.WriteLine(0.1.ToMetric());

            var fileSize = 50;
            var fileSize2 = 1200;
            Console.WriteLine(fileSize.Bytes().Humanize());
            Console.WriteLine(fileSize.Kilobytes().Humanize());
            Console.WriteLine(fileSize.Megabytes().Humanize());
            Console.WriteLine(fileSize.Gigabytes().Humanize());

            Console.WriteLine(fileSize2.Bytes().Humanize());
            Console.WriteLine(fileSize2.Bytes().Humanize("KB"));
            Console.WriteLine(fileSize2.Bytes().Humanize("MB"));
            Console.WriteLine(fileSize2.Kilobytes().Humanize());
            Console.WriteLine(fileSize2.Megabytes().Humanize());
            Console.WriteLine(fileSize2.Gigabytes().Humanize());

            Console.WriteLine(0d.ToHeadingArrow());
            Console.WriteLine(90d.ToHeadingArrow());
            Console.WriteLine(180d.ToHeadingArrow());
            Console.WriteLine(270d.ToHeadingArrow());
        }
    }
}