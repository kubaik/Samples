using System;
using System.IO;
using TesseractSharp;

namespace TesseractSharpDemo
{
    class Program
    {
        private static string _baseDir;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello TesseractSharp Library Demo!");
            
            _baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\input_samples");
            
            PrintOcr("doc-por.jpg", "por");
            PrintOcr("doc-eng.jpg", "eng");
            
            PrintOcr("plate-OJJ3984-1.jpg", "por");
            PrintOcr("plate-OJJ3984-1.jpg", "eng");
            PrintOcr("plate-OJJ3984-2.jpg", "por");
            PrintOcr("plate-OJJ3984-2.jpg", "eng");
            PrintOcr("plate-OJJ3984-3.jpg", "por");
            PrintOcr("plate-OJJ3984-3.jpg", "eng");
            PrintOcr("plate-OJJ3984-4.jpg", "por");
            PrintOcr("plate-OJJ3984-4.jpg", "eng");
            PrintOcr("plate-ATF7354.jpg", "por");
            PrintOcr("plate-ATF7354.jpg", "eng");
            
            Console.WriteLine(new string('-', 35));
        }
        
        private static void PrintOcr(string file, string language)
        {
            var text = DoOcr(Path.Combine(_baseDir, file), language);
            Console.WriteLine(new string('-', 15) + $" {language.ToUpper()} => {file} " + new string('-', 15));
            Console.WriteLine(text);
        }
        
        private static string DoOcr(string imagePath, string destinationLanguage)
        {
            using var stream = Tesseract.ImageToTxt(imagePath, languages: new[] {Language.Portuguese});
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd().Trim();
        }
    }
}