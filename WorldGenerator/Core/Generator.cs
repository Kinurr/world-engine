using WorldGenerator.Utils;
using SkiaSharp;

namespace WorldGenerator.Core;

public static class Generator
{
    private static byte _randomValue;

    private static readonly Random Rng = new();

    private static SKBitmap? _noiseMap;

    private static float _min, _max;

    /// <summary>
    /// Generates a monochromatic noise map.
    /// </summary>
    /// <param name="width">Noise map width in pixels.</param>
    /// <param name="height">Noise map height in pixels.</param>
    /// <param name="noiseType">Type of noise to generate.</param>
    /// <param name="frequency">Frequency value. Impacts generation.</param>
    /// <param name="octaves">Octaves value. Impacts generation.</param>
    /// <returns>An monochromatic noise map in the form of an object of type SKBitmap.</returns>
    public static SKBitmap? GenerateNoise(int width, int height, FastNoise.NoiseType noiseType, float frequency, int octaves = 1)
    {
        // Initializers.
        _noiseMap = new SKBitmap(width, height);

        var noiseGenerator = new FastNoise((int)DateTime.Now.Ticks);
        noiseGenerator.SetNoiseType(noiseType);
        noiseGenerator.SetFrequency(frequency);
        noiseGenerator.SetFractalOctaves(octaves);

        // Get maximum and minimum values from noise in order to cap color values.
        _max = 0f;
        _min = 0f;
        
        for (var x = 0; x < _noiseMap.Width; x++)
        {
            for (var y = 0; y < _noiseMap.Height; y++)
            {
                if (noiseGenerator.GetNoise(x, y) > _max)
                    _max = noiseGenerator.GetNoise(x, y);
                
                if (noiseGenerator.GetNoise(x, y) < _min)
                    _min = noiseGenerator.GetNoise(x, y);
            }
        }
        
        // Draw noise map.
        try
        {
            for (var x = 0; x < _noiseMap.Width; x++)
            {
                for (var y = 0; y < _noiseMap.Height; y++)
                {
                    _randomValue = (byte)MathUtils.Clamp(0, 255, MathUtils.Map(noiseGenerator.GetNoise(x, y), 
                        _min, _max, 0f, 255f));
                    _noiseMap.SetPixel(x, y, new SKColor(_randomValue, _randomValue, _randomValue));

                }
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return _noiseMap;
    }
}
