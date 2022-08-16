using WorldGenerator.Utils;
using SkiaSharp;

namespace WorldGenerator.Core;

/// <summary>
/// Used to generate random noise.
/// </summary>
public static class NoiseGenerator
{
    /// <summary>
    /// Generates a pixel from a noise map.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <param name="seed">Seed for the generator.</param>
    /// <param name="noiseType">Type of noise to generate.</param>
    /// <param name="frequency">Frequency value. Impacts generation.</param>
    /// <param name="octaves">Octaves value. Impacts generation.</param>
    public static float GenerateNoise(int x, int y, int seed, FastNoise.NoiseType noiseType, float frequency,
        int octaves = 1)
    {
        // Initializers.
        var noiseGenerator = new FastNoise(seed);
        noiseGenerator.SetNoiseType(noiseType);
        noiseGenerator.SetFrequency(frequency);
        noiseGenerator.SetFractalOctaves(octaves);

        return noiseGenerator.GetNoise(x, y);
    }
}