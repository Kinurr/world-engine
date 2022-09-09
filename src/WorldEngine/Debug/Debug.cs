using System.Net.NetworkInformation;
using SkiaSharp;
using WorldEngine.World;

namespace WorldEngine.Debug;

public static class Tools
{
    public static async Task SaveWorldChunkAsPng(string path, World.World world, int xOrigin, int yOrigin, int width, int height)
    {
        Console.WriteLine($"Saving map chunk as png. Origin point: ({xOrigin}, {yOrigin}) Size: {width} by {height}px");
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
        WorldTile _tile;
        
        for (int i = xOrigin; i < xOrigin + width; i++)
        {
            y = 0;
            for (int j = yOrigin; j < yOrigin + height; j++)
            {
                _tile = world.GetTileAt(i, j);

                if (_tile.Biome == Biomes.Water)
                    bitmap.SetPixel(x, y, SKColors.DarkBlue);
                else
                {
                    bitmap.SetPixel(x, y, SKColors.Bisque);

                    // var altitude = (byte)Utils.MathUtils.Map(_tile.Altitude, 0, 1000, 0, 255);
                    // // Console.WriteLine($"Altitude ({x}, {y}) - {_tile.Altitude}");
                    // bitmap.SetPixel(x, y, new SKColor(altitude, altitude, altitude));
                }
                
                y++;
            }
            x++;
        }
        
        return bitmap;
    }
}