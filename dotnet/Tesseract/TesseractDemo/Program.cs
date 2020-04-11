using System;
using Tesseract;

namespace TesseractDemo
{
    class Program
    {
        private const string TessDataFolder = @"C:\Tesseract-OCR\trained_current\tessdata";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tesseract Demo!");
            const string sourceFile = @"C:\Tesseract-OCR\input_samples\cnh\rg.jpg";
            var text = DoOcr(sourceFile, "eng");
            Console.WriteLine(text);
        }

        public static string DoOcr(string imagePath, string destinationLanguage)
        {
            using var engine = new TesseractEngine(TessDataFolder, destinationLanguage, EngineMode.Default);
            using var img = Pix.LoadFromFile(imagePath);
            var page = engine.Process(img);
            var result = page.GetText();
            return string.IsNullOrWhiteSpace(result) ? "Ocr is finished. Return empty" : result.Trim();
        }
    }
}