using SkiaSharp;

namespace WorldGenerator.Utils;

public static class IOUtils
{
    public static void SaveSKBitmapLocally(string name, SKBitmap bitmap)
    {
        
        var path = Directory.GetCurrentDirectory() + String.Format($"{0}.png", name);
        
        Console.WriteLine("Path: " + path);

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 80);
        using var stream = File.OpenWrite(path);
        data.SaveTo(stream);
    }
}
