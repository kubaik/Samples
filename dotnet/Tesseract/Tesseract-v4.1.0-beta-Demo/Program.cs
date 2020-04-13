using System;
using System.IO;
using Tesseract;

namespace TesseractOcrDemo
{
    class Program
    {
        // Download modelos:
        // https://github.com/tesseract-ocr/tessdata/tree/4.0.0
        // https://github.com/tesseract-ocr/tessdata_best
        // https://github.com/tesseract-ocr/tessdata_fast
        private const string TessDataFolder = @"C:\Tesseract-OCR\tessdata\4\current";
        private static string _baseDir;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tesseract Demo!");

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

        private static string DoOcr(string imagePath, string language)
        {
            using var engine = new TesseractEngine(TessDataFolder, language, EngineMode.Default);
            using var img = Pix.LoadFromFile(imagePath);
            var page = engine.Process(img);
            var result = page.GetText();
            return string.IsNullOrWhiteSpace(result) ? "OCR concluído. Nenhum texto identificado." : result.Trim();
        }
    }
}