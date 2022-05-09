using System.Drawing;
using WorldGenerator.Utils;

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

    public static Bitmap? GenerateOpenSimplexNoise(int width, int height)
    {
        _noiseMap = new Bitmap(width, height);

        OpenSimplexNoise simplexNoise = new OpenSimplexNoise();
        
        for (var x = 0; x < _noiseMap.Width; x++)
        {
            for (var y = 0; y < _noiseMap.Height; y++)
            {
                var value = MathUtils.Map(simplexNoise.Evaluate(x, y), -1f, 1f, 0f, 255f);
                _noiseMap.SetPixel(x, y, Color.FromArgb((int)value, (int)value, (int)value));
            }
        }
        
        return _noiseMap;
    }

    public static Bitmap? GeneratePerlinNoise(int width, int height)
    {
        _noiseMap = new Bitmap(width, height);

        FastNoise perlinNoise = new FastNoise((int)DateTime.Now.Ticks);
        perlinNoise.SetNoiseType(FastNoise.NoiseType.Perlin);
        perlinNoise.SetFrequency(0.005f);
        // perlinNoise.SetCellularDistance2Indicies(500, 500);

        var max = 0f;
        var min = 0f;
        
        for (var x = 0; x < _noiseMap.Width; x++)
        {
            for (var y = 0; y < _noiseMap.Height; y++)
            {
                if (perlinNoise.GetNoise(x, y) > max)
                    max = perlinNoise.GetNoise(x, y);
                
                if (perlinNoise.GetNoise(x, y) < min)
                    min = perlinNoise.GetNoise(x, y);

                var value = (int)MathUtils.Clamp(0, 255, MathUtils.Map(perlinNoise.GetNoise(x, y), -0.3f, 0.3f, 0f, 255f));
                _noiseMap.SetPixel(x, y, Color.FromArgb(value, value, value));
            }
        }
        
        Console.WriteLine("Maximum: " + max + ", Minimum: "+ min);
        
        return _noiseMap;
    }
}
