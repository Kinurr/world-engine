using System.Numerics;

namespace WorldEngine.Noise;

/// <summary>
/// 2 Dimensional noisy sine wave.
/// </summary>
public class SinusoidalNoise : INoise
{
    /// <summary>
    /// Directional vector of the 2d noisy sine wave.
    /// </summary>
    private Vector2 direction { get; }

    /// <summary>
    /// X and Y offsets.
    /// </summary>
    private Vector2 offset { get; }

    /// <summary>
    /// Sine function period multiplier. 
    /// </summary>
    private float periodMultiplier { get; }

    /// <summary>
    /// Helper noise result multiplier. 
    /// </summary>
    private float helperNoiseMultiplier { get; }

    /// <summary>
    /// Seed for this noise generator.
    /// </summary>
    public int? Seed { get; }

    /// <summary>
    /// Noise to apply over the base sine value.
    /// </summary>
    private INoise helperNoise;

    /// <summary>
    /// Constructor for 2D sinusoidal noise.
    /// </summary>
    /// <param name="direction">Defines direction of the noise.</param>
    /// <param name="offset">Defines X and Y offset of the noise.</param>
    /// <param name="periodMultiplier">Value by wich to multiply sine function period.</param>
    /// <param name="helperNoiseMultiplier">Value by which to multiply helper noise result. 
    /// Higher value results in more jagged noise. 0 nullifies helper noise.</param>
    /// <param name="helperNoise">Noise to appl to base sine function.</param>
    /// <param name="seed">Seed of helper noise. Get overriden if helper noise already has been provided seed.</param>
    public SinusoidalNoise(
        Vector2? direction = null, 
        Vector2? offset = null, 
        float periodMultiplier = 0.005f, 
        float helperNoiseMultiplier = 1f, 
        INoise? helperNoise = null, 
        int? seed = null)
    {
        this.direction = direction ?? new Vector2(0, 1);
        this.offset = offset ?? Vector2.Zero;
        this.periodMultiplier = periodMultiplier;
        this.helperNoiseMultiplier = helperNoiseMultiplier;
        this.Seed = seed;
        this.helperNoise = helperNoise ?? new FractalPerlinNoise(0.005f, 6, 0.4f, 2);

        if(this.helperNoise.Seed == null && Seed != null) {
            SetupGenerator(Seed ?? 0);
        }
    }
    
    public float Get(int x, int y) =>
        MathF.Sin(periodMultiplier * ((direction.X * x + offset.X) + (direction.Y * y + offset.Y)) + helperNoise.Get(x, y) * helperNoiseMultiplier);

    /// <summary>
    /// Setup helper noise with given seed..
    /// </summary>
    public void SetupGenerator(int seed)
    {
        this.helperNoise.SetupGenerator(seed);
    }
}