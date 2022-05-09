using System.Drawing;

namespace WorldGenerator.Core;

public class Generator
{
    private static int _randomValue;

    private static readonly Random Rng = new();

    private static Bitmap? _noiseMap;
    
    /// <summary>
    /// Returns simple noise in the form of a monochrome bitmap
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public static Bitmap? GenerateSimpleNoise(int width, int height)
    {
        _noiseMap = new Bitmap(width, height);

        for (var x = 0; x < _noiseMap.Width; x++)
        {
            for (var y = 0; y < _noiseMap.Height; y++)
            {
                _randomValue = Rng.Next(0, 255);
                _noiseMap.SetPixel(x, y, Color.FromArgb(_randomValue, _randomValue, _randomValue));
            }
        }

        return _noiseMap;
    }
}
