using System.Drawing;

namespace WorldGenerator.Core;

public class Generator
{
    private static int randomValue;

    private static Random rng = new Random();
    
    /// <summary>
    /// Returns simple noise in the form of a monochrome bitmap
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static Bitmap GenerateSimpleNoise(int width, int height)
    {
        var noiseMap = new Bitmap(width, height);

        for (var x = 0; x < noiseMap.Width; x++)
        {
            for (var y = 0; y < noiseMap.Height; y++)
            {
                randomValue = rng.Next(0, 255);
                noiseMap.SetPixel(x, y, Color.FromArgb(randomValue, randomValue, randomValue));
            }
        }

        return noiseMap;
    }
}
