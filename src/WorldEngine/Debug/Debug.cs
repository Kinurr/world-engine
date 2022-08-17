using System.Net.NetworkInformation;
using SkiaSharp;
using WorldEngine.World;

namespace WorldEngine.Debug;

public static class Tools
{
    public static async Task SaveWorldChunkAsPng(string path, World.World world, int xOrigin, int yOrigin, int width, int height)
    {
        Console.WriteLine(String.Format("Saving map chunk as png. Origin point: ({0}, {1}) Size: {2} by {3}px",
            xOrigin, yOrigin, width, height));
        var data = SKImage.FromBitmap(CreateWorldBitmap(world, xOrigin, yOrigin, width, height)).Encode(SKEncodedImageFormat.Png, 100);
        await using (var stream = File.OpenWrite(path))
        {
            // save the data to a stream
            data.SaveTo(stream);
        }

    }

    private static SKBitmap CreateWorldBitmap(World.World world, int xOrigin, int yOrigin, int width, int height)
    {
        var bitmap = new SKBitmap(width, height);
        int x = 0, y;
        
        for (int i = xOrigin; i < xOrigin + width; i++)
        {
            y = 0;
            for (int j = yOrigin; j < yOrigin + height; j++)
            {
                bitmap.SetPixel(x, y, world.GetTileAt(i, j).Biome == Biomes.Water ? 
                    SKColors.MediumBlue : SKColors.Bisque);
                y++;
            }
            x++;
        }
        
        return bitmap;
    }
}