using WorldGenerator.Utils;
using SkiaSharp;

namespace WorldGenerator.Core;

/// <summary>
/// Used to generate random 2-dimensional noise.
/// </summary>
public static class NoiseGenerator
{
    /// <summary>
    /// Generates a noise map as a byte array.
    /// </summary>
    /// <param name="width">Noise map width in pixels.</param>
    /// <param name="height">Noise map height in pixels.</param>
    /// <param name="seed">Seed for the generator.</param>
    /// <param name="noiseType">Type of noise to generate.</param>
    /// <param name="frequency">Frequency value. Impacts generation.</param>
    /// <param name="octaves">Octaves value. Impacts generation.</param>
    public static int[,] GenerateNoise(int width, int height, int seed, FastNoise.NoiseType noiseType, float frequency,
        int octaves = 1)
    {
        // Initializers.
        var noiseMap = new int[width, height];

        var noiseGenerator = new FastNoise(seed);
        noiseGenerator.SetNoiseType(noiseType);
        noiseGenerator.SetFrequency(frequency);
        noiseGenerator.SetFractalOctaves(octaves);

        // Get maximum and minimum values from noise in order to cap color values.
        var max = 0f;
        var min = 0f;

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (noiseGenerator.GetNoise(x, y) > max)
                    max = noiseGenerator.GetNoise(x, y);

                if (noiseGenerator.GetNoise(x, y) < min)
                    min = noiseGenerator.GetNoise(x, y);
            }
        }

        Console.WriteLine("max: " + max + ", min: " + min);

        // Draw noise map.
        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
            noiseMap[x, y] = (byte)MathUtils.Clamp(0, 255, MathUtils.Map(noiseGenerator.GetNoise(x, y),
                min, max, 0f, 255f));

        return noiseMap;
    }
}