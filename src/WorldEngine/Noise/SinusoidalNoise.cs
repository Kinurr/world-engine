namespace WorldEngine.Noise;

public class SinusoidalNoise : INoise
{

    /// <summary>
    /// Seed for this noise generator.
    /// </summary>
    public Tuple<float, float> Direction { get; }

    /// <summary>
    /// Seed for this noise generator.
    /// </summary>
    public int? Seed { get; }

    private INoise helperNoise;

    public SinusoidalNoise(int? seed = null, Tuple<float, float>? direction = null)
    {
        Seed = seed;
        direction = Direction;

        var helperNoiseSeed = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        helperNoise = new FractalPerlinNoise(0.005f, 6, 0.4f, 2, helperNoiseSeed);

        if (Seed == null)
            Seed = 0;

        if (Direction == null)
            Direction = new Tuple<float, float>(1f, 1f);
    }

    public float Get(int x, int y) =>
        MathF.Sin(0.006f * ((x) + (y - 250)) + helperNoise.Get(x, y) * 2);

    public void SetupGenerator(int seed)
    {
        return;
    }
}