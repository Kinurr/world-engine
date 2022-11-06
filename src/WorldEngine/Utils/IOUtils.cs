using SkiaSharp;

namespace WorldEngine.Core.Utils;

public static class IOUtils
{
    /// <summary>
    /// Saved an SKBitmap as a .png to the disk. 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="bitmap"></param>
    public static void SaveSKBitmapLocally(string path, SKBitmap? bitmap)
    {
        try
        {
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 80);
            using var stream = File.OpenWrite(path);
            data.SaveTo(stream);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
