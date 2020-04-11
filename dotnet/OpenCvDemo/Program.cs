using System;
using System.IO;
using System.Threading.Tasks;
using OpenCvSharp;
using Tesseract;

namespace OpenCvDemo
{
    class Program
    {
        private const string TessDataFolder = @"C:\Tesseract-OCR\trained_current\tessdata";
        private const string TempFolder = @"C:\Tesseract-OCR\temp";

        static void Main(string[] args)
        {
            Console.WriteLine("Open CV Demo!");
            var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input_samples\sao-luis.jpeg");

            var src = new Mat(input);
            Cv2.ImShow("original", src);

            var gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.ImShow("gray", gray);

            var binary = new Mat();
            Cv2.Threshold(gray, binary, 50, 255, ThresholdTypes.Binary);
            Cv2.ImShow("binary", binary);

            Task.Run(() =>
            {
                try
                {
                    if (!Directory.Exists(TempFolder)) 
                        Directory.CreateDirectory(TempFolder);
                    var tempFile = Path.Combine("temp.jpg");
                    binary.SaveImage(tempFile);
                    var ocrText = DoOcr(tempFile, "por");
                    Console.WriteLine(ocrText);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Tesseract OCR error: " + e.Message);
                }
            });

            Cv2.WaitKey();
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