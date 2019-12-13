using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Data;
using System.Globalization;
using Maestria.Data.Extensions;

namespace DataReaderExtensionsDemo
{
    class Program
    {
        private const long FixedPointExpected = 16L;
        private const decimal FloatingPointExpected = 17.0001m;
        private static readonly DateTime DateTimeExpected = DateTime.Today;
        private const string StringExpected = "test value";
        private const string StringNumber = "16.1";
        private const string StringDateInput = "2019-06-30";
        private const string StringDatePtBrInput = "30/06/2019";

        private static SQLiteConnection connection;
        private static SQLiteCommand cmd;
        private static DbDataReader reader;

        static void Main(string[] args)
        {
            connection = new SQLiteConnection("DataSource=:memory:");
            PrepareDb();

            Console.WriteLine(PrepareReader("select * from temp").GetInt32("IntValue"));
            Console.WriteLine(PrepareReader("select * from temp").GetDecimal("NumericValue"));
            Console.WriteLine(PrepareReader("select * from temp").GetInt32("NumericValue"));
            Console.WriteLine(PrepareReader("select * from temp").GetInt32("StringNumber"));
            Console.WriteLine(PrepareReader("select * from temp").GetInt32Safe("StringNull"));
            Console.WriteLine(PrepareReader("select * from temp").GetInt32Safe("StringNull", -1));
            Console.WriteLine(PrepareReader("select * from temp").GetInt32Safe("StringNumber"));
            Console.WriteLine(PrepareReader("select * from temp").GetInt32Safe("StringNumber", -1));
            Console.WriteLine(PrepareReader("select * from temp").GetString("StringDate"));
            Console.WriteLine(PrepareReader("select * from temp").GetDateTime("StringDate"));
            Console.WriteLine(PrepareReader("select * from temp").GetString("StringDatePtBr"));
            Console.WriteLine(PrepareReader("select * from temp").GetDateTime("StringDatePtBr", CultureInfo.GetCultureInfo("pt-BR")));
//            Console.WriteLine(PrepareReader("select * from temp").GetString("InvalidField"));

            Console.WriteLine("Fim!");
        }

        private static DbDataReader PrepareReader(string query)
        {
            reader?.Close();
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            reader.Read();
            return reader;
        }

        private static void PrepareDb()
        {
            connection.Open();

            cmd = connection.CreateCommand();
            cmd.CommandText =
                "create table temp (IntValue int, IntNull int, " +
                "NumericValue numeric(10,4), NumericNull numeric(10,4), " +
                "DateValue Date, DateNull Date, " +
                "StringValue varchar(20), StringNull varchar(20), " +
                "StringNumber varchar(20), " +
                "StringDate varchar(20), StringDatePtBr varchar(20))";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "insert into temp values(@int, null, @numeric, null, @date, null, @string, null, @stringNumber, @stringDate, @stringDatePtBr)";
            cmd.Parameters.AddWithValue("@int", FixedPointExpected);
            cmd.Parameters.AddWithValue("@numeric", FloatingPointExpected);
            cmd.Parameters.AddWithValue("@date", DateTimeExpected);
            cmd.Parameters.AddWithValue("@string", StringExpected);
            cmd.Parameters.AddWithValue("@stringNumber", StringNumber);
            cmd.Parameters.AddWithValue("@stringDate", StringDateInput);
            cmd.Parameters.AddWithValue("@stringDatePtBr", StringDatePtBrInput);
            cmd.ExecuteNonQuery();
        }
    }
}