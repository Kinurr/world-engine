using WorldEngine.Utils;

namespace WorldEngine.Core;

public class NoiseProfile
{
    public FastNoiseLite.NoiseType Type { get; set; }

    public float Frequency { get; set; }

    public FastNoiseLite.FractalType FractalType { get; set; }

    public int FractalOctaves { get; set; }

    public float FractalGain { get; set; }

    public int FractalLacunarity { get; set; }
    
    public NoiseProfile(FastNoiseLite.NoiseType type, float frequency, FastNoiseLite.FractalType fractalType, int fractalOctaves, float fractalGain, int fractalLacunarity)
    {
        Type = type;
        Frequency = frequency;
        FractalType = fractalType;
        FractalOctaves = fractalOctaves;
        FractalGain = fractalGain;
        FractalLacunarity = fractalLacunarity;
    }
}