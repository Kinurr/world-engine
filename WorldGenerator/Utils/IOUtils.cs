using System.Drawing;
using SkiaSharp;

namespace WorldGenerator.Utils;

public static class IOUtils
{
    /// <summary>
    /// Saves a bitmap locally
    /// </summary>
    /// <param name="name">The name of the bitmap to save</param>
    /// <param name="image">The bitmap to store locally</param>
    public static void SaveBitmapLocally(string name, Image? image)
    {
        image.Save(Environment.CurrentDirectory + $"/{name}.bmp");
    }

    public static void SaveSKBitmapLocally(string name, SKBitmap bitmap)
    {
        
        string path = Directory.GetCurrentDirectory() + String.Format($"{0}.png", name);

        using (var image = SKImage.FromBitmap(bitmap))
        using (var data = image.Encode(SKEncodedImageFormat.Png, 80))
        {
         using (var stream = File.OpenWrite(path))
         {
             data.SaveTo(stream);
         }
        }
    }
}
