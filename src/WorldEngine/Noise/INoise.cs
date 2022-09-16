namespace WorldEngine.Noise;

public interface INoise
{
    /// <summary>
    /// Returns noise value for coordinates.
    /// </summary>
    /// <param name="x">X axis coordinate</param>
    /// <param name="y">Y axis coordinate</param>
    /// <returns></returns>
    public float Get(int x, int y);
}