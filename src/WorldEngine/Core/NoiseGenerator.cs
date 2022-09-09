using SkiaSharp;
using WorldEngine.Utils;

namespace WorldEngine.Core;

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
    public static float GenerateNoise(int x, int y, int seed, FastNoiseLite.NoiseType noiseType, float frequency,
        int octaves = 1)
    {
        // Initializers.
        var noiseGenerator = new FastNoiseLite(seed);
        noiseGenerator.SetNoiseType(FastNoiseLite.NoiseType.Value);
        noiseGenerator.SetFrequency(.005f);
        noiseGenerator.SetFractalType(FastNoiseLite.FractalType.FBm);
        noiseGenerator.SetFractalOctaves(6);
        noiseGenerator.SetFractalGain(.4f);
        noiseGenerator.SetFractalLacunarity(2);
        // noiseGenerator.SetFractalGain(octaves);

        return noiseGenerator.GetNoise(x, y);
    }
}