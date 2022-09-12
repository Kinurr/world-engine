using SkiaSharp;
using WorldEngine.Utils;

namespace WorldEngine.Core;

/// <summary>
/// Used to generate random noise.
/// </summary>
public static class NoiseGenerator
{
    /// <summary>
    /// Generates a tile from a noise map.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <param name="seed">Seed for the generator.</param>
    /// <param name="noiseProfile">Profile for noise generator.</param>
    public static float GetNoise(int x, int y, int seed, NoiseProfile noiseProfile)
    {
        var noiseGenerator = new FastNoiseLite(seed);
        noiseGenerator.SetNoiseType(noiseProfile.Type);
        noiseGenerator.SetFrequency(noiseProfile.Frequency);
        noiseGenerator.SetFractalType(noiseProfile.FractalType);
        noiseGenerator.SetFractalOctaves(noiseProfile.FractalOctaves);
        noiseGenerator.SetFractalGain(noiseProfile.FractalGain);
        noiseGenerator.SetFractalLacunarity(noiseProfile.FractalLacunarity);

        return noiseGenerator.GetNoise(x, y);
    }
}