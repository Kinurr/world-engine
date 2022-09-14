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
                SKColor color;

                switch (_tile.Biome)
                {
                    case BiomeTypes.ShallowOcean:
                        color = SKColors.RoyalBlue;
                        break;
                    case BiomeTypes.DeepOcean:
                        color = SKColors.DarkBlue;
                        break;
                    case BiomeTypes.Beach:
                        color = SKColors.LightYellow;
                        break;
                    case BiomeTypes.Savanna:
                        color = SKColors.Goldenrod;
                        break;
                    case BiomeTypes.Desert:
                        color = SKColors.Gold;
                        break;
                    case BiomeTypes.Grassland:
                        color = SKColors.LightGreen;
                        break;
                    case BiomeTypes.Forest:
                        color = SKColors.ForestGreen;
                        break;
                    case BiomeTypes.TropicalForest:
                        color = SKColors.DarkGreen;
                        break;
                    case BiomeTypes.Tundra:
                        color = SKColors.Snow;
                        break;
                    case BiomeTypes.MountainBase:
                        color = SKColors.Peru;
                        break;
                    case BiomeTypes.Mountain:
                        color = SKColors.Chocolate;
                        break;
                    case BiomeTypes.MountainTop:
                        color = SKColors.SaddleBrown;
                        break;
                    case BiomeTypes.Summit:
                        color = SKColors.GhostWhite;
                        break;
                    case BiomeTypes.Null:
                        color = SKColors.HotPink;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                bitmap.SetPixel(x, y, color);

                y++;
            }
            x++;
        }
        
        return bitmap;
    }
}