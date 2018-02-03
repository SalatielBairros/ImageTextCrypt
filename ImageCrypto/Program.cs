using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFramework.Util.ImageFile;
using CustomFramework.Util.IO;
using CustomFramework.Util.Text;

namespace ImageCrypto
{
    internal class Program
    {
        private const string ImageBaseFilePath = "C:\\ImageCrypto\\Files\\BaseImage.jpg";
        private const string FileTextToImage = "C:\\ImageCrypto\\Files\\FileToCrypt.txt";
        private const string FileTextFromImage = "C:\\ImageCrypto\\Files\\TextFromImage.txt";
        private const string NegativeFilePath = "C:\\ImageCrypto\\Files\\NegativeBaseImage.jpg";
        private const string FileTextOnImage = "C:\\ImageCrypto\\Files\\TextOnImage.jpg";
        private const string DiffImage = "C:\\ImageCrypto\\Files\\Diff.jpg";

        static void Main(string[] args)
        {
            Console.WriteLine("Início do processamento...");

            Image.FromFile(ImageBaseFilePath).CreateNegative(NegativeFilePath);
            var pk = Image.FromFile(ImageBaseFilePath).SetTextOnImage(FileActions.ReadFile(FileTextToImage), FileTextOnImage);
            Image.FromFile(ImageBaseFilePath).Diff(Image.FromFile(FileTextOnImage), DiffImage);
            var retString = Image.FromFile(FileTextOnImage).GetTextFromImage(Image.FromFile(ImageBaseFilePath), pk);
            retString.WriteToFile(FileTextFromImage);

            Console.WriteLine("Processado.");
            Console.ReadKey();
        }
    }
}
