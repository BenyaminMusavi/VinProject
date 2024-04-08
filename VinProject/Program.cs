using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

class Program
{
    static void Main()
    {
        Image<Bgr, byte> carCardImage = new Image<Bgr, byte>("C:\\vi.jpg");
        Emgu.CV.OCR.Tesseract ocr = new Emgu.CV.OCR.Tesseract("tessdata", "eng", OcrEngineMode.Default);
        ocr.SetImage(carCardImage);
        ocr.Recognize();

        string vinNumber = ocr.GetUTF8Text().Trim();
        string searchTerm = "VIN: ";
        int index = vinNumber.IndexOf(searchTerm);
        if (index != -1)
        {
            int startIndex = index + searchTerm.Length;
            string substring = vinNumber.Substring(startIndex, 15);
            Console.WriteLine("VIN: " + substring);
        }

    }
}