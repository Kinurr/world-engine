namespace WorldEngine.Core.Noise;

public interface INoise
{
    /// <summary>
    /// Seed value for this noise generator.
    /// </summary>
    public int? Seed { get; }

    /// <summary>
    /// Returns noise value for coordinates.
    /// </summary>
    /// <param name="x">X axis coordinate</param>
    /// <param name="y">Y axis coordinate</param>
    /// <returns></returns>
    public float Get(int x, int y);

    /// <summary>
    /// Initializes noise generator.
    /// This is a required step if the noise hasn't been given a seed parameter in the constructor.
    /// </summary>
    /// <param name="seed"></param>
    public void SetupGenerator(int seed);
}