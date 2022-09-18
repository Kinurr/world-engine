using WorldEngine.Noise;

namespace WorldEngine.Layers;

/// <summary>
/// Represents a map layer.
/// </summary>
public class Layer
{
    /// <summary>
    /// Layer type.
    /// </summary>
    public LayerTypes LayerType { get; }

    /// <summary>
    /// Layer ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Noise profile.
    /// </summary>
    private INoise _noise { get; }

    /// <summary>
    /// Initializes map layer
    /// </summary>
    /// <param name="noise">Noise map</param>
    /// <param name="type">Layer type</param>
    public Layer(LayerTypes type, INoise noise)
    {
        LayerType = type;
        _noise = noise;
    }

    /// <summary>
    /// Initializes noise generator if it hasn't been already.
    /// </summary>
    /// <param name="seed"></param>
    public void SetupGenerator(int seed)
    {
        // If noise has no seed, initialize noise generator with seed.
        if(_noise.Seed == null)
            _noise.SetupGenerator(seed);
    }

    /// <summary>
    /// Returns the tile value at a given coordinate.
    /// </summary>
    /// <param name="x">X coordinate value.</param>
    /// <param name="y">Y coordinate value.</param>
    /// <returns></returns>
    public float GetTileAt(int x, int y) => _noise.Get(x, y);

    /// <summary>
    /// Returns a chunk of tiles 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public float[,] GetTileChunkAt(int x, int y, int width, int height)
    {
        var chunk = new float[width, height];

        try
        {
            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    chunk[i, j] = GetTileAt(x + i, y + j);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return chunk;
    }
}