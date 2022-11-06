using WorldEngine.Core.Utils;

namespace WorldEngine.Core.Noise;

/// <summary>
/// Generator for fractal perlin noise.
/// </summary>
public class FractalPerlinNoise : INoise
{
    /// <summary>
    /// Noise frequency.
    /// </summary>
    private float _frequency;

    /// <summary>
    /// Noise gain per octave.
    /// </summary>
    private float _fractalGain;

    /// <summary>
    /// Number of octaves to pass noise through.
    /// </summary>
    private int _fractalOctaves;

    /// <summary>
    /// Fractal lacunarity.
    /// </summary>
    private int _fractalLacunarity;

    /// <summary>
    /// Seed for this noise generator.
    /// </summary>
    public int? Seed { get; }

    /// <summary>
    /// Generator object.
    /// </summary>
    private FastNoiseLite? _generator;

    /// <summary>
    /// Constructor for 2D fractal perlin noise.
    /// </summary>
    /// <param name="frequency">Noise frequency. Higher value results in </param>
    /// <param name="fractalOctaves"></param>
    /// <param name="fractalGain"></param>
    /// <param name="fractalLacunarity"></param>
    /// <param name="seed"></param>
    public FractalPerlinNoise(float frequency, int fractalOctaves, float fractalGain, int fractalLacunarity, int? seed = null)
    {
        _frequency = frequency;
        _fractalOctaves = fractalOctaves;
        _fractalGain = fractalGain;
        _fractalLacunarity = fractalLacunarity;
        Seed = seed;

        // If a seed is provided in the constructor params, initialize generator.
        if (Seed != null)
            SetupGenerator(Seed ?? 0);
    }

    /// <summary>
    /// Setup generator with assigned parameters.
    /// </summary>
    public void SetupGenerator(int seed)
    {
        _generator = new FastNoiseLite(seed);

        _generator.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        _generator.SetFractalType(FastNoiseLite.FractalType.FBm);
        _generator.SetFrequency(_frequency);
        _generator.SetFractalOctaves(_fractalOctaves);
        _generator.SetFractalGain(_fractalGain);
        _generator.SetFractalLacunarity(_fractalLacunarity);
    }

    /// <summary>
    /// Returns a noise value for a pair of coordinates.
    /// </summary>
    /// <param name="x">X axis coordinate.</param>
    /// <param name="y">Y axis coordinate.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Throws exception in case generator hasn't been initialized yet.</exception>
    public float Get(int x, int y)
    {
        try
        {
            if (_generator != null)
                return _generator.GetNoise(x, y);

            throw new Exception("Noise generator hasn't been initialized");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}