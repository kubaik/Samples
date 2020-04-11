using System;
using System.IO;
using Tesseract;

namespace TesseractOcrDemo
{
    class Program
    {
        private const string TessDataFolder = @"C:\Tesseract-OCR\trained_my\tessdata";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tesseract Demo!");

            var sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input_samples\doc-por.jpg");
            var text = DoOcr(sourceFile, "por");
            Console.WriteLine(text);
        }

        public static string DoOcr(string imagePath, string destinationLanguage)
        {
            using var engine = new TesseractEngine(TessDataFolder, destinationLanguage, EngineMode.Default);
            using var img = Pix.LoadFromFile(imagePath);
            var page = engine.Process(img);
            var result = page.GetText();
            return string.IsNullOrWhiteSpace(result) ? "OCR concluído. Nenhum texto identificado." : result.Trim();
        }
    }
}