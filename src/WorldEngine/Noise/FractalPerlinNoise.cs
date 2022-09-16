using WorldEngine.Utils;

namespace WorldEngine.Noise;

public class FractalPerlinNoise : INoise
{
    private float _frequency;
    private float _fractalGain;
    private int _fractalOctaves;
    private int _fractalLacunarity;
    private int _seed;

    private FastNoiseLite? _generator;

    public FractalPerlinNoise(int seed, float frequency, int fractalOctaves, float fractalGain, int fractalLacunarity)
    {
        _seed = seed;
        _frequency = frequency;
        _fractalOctaves = fractalOctaves;
        _fractalGain = fractalGain;
        _fractalLacunarity = fractalLacunarity;

        SetupGenerator();
    }

    /// <summary>
    /// Setup generator with assigned parameters.
    /// </summary>
    private void SetupGenerator()
    {
        _generator = new FastNoiseLite(_seed);

        _generator.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
        _generator.SetFractalType(FastNoiseLite.FractalType.FBm);
        _generator.SetFrequency(_frequency);
        _generator.SetFractalOctaves(_fractalOctaves);
        _generator.SetFractalGain(_fractalGain);
        _generator.SetFractalLacunarity(_fractalLacunarity);
    }

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