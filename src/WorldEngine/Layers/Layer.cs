using WorldEngine.Noise;

namespace WorldEngine.Layers;

/// <summary>
/// Represents a map layer.
/// </summary>
public class Layer
{
    /// <summary>
    /// Layer name.
    /// </summary>
    private string _name { get; }

    /// <summary>
    /// Layer type.
    /// </summary>
    public LayerTypes LayerType { get; }

    /// <summary>
    /// Layer ID.
    /// </summary>
    private int _id { get; }
    
    /// <summary>
    /// Seed for the map generator.
    /// </summary>
    private int _seed { get; }

    /// <summary>
    /// Noise profile.
    /// </summary>
    private INoise _noise { get; }

    /// <summary>
    /// Initializes map layer
    /// </summary>
    /// <param name="name">Layer name</param>
    /// <param name="id">Layer id</param>
    /// <param name="noise">Noise map</param>
    /// <param name="type">Layer type</param>
    /// <param name="seed">Generator seed</param>
    public Layer(string name, int id, LayerTypes type, int seed, INoise noise)
    {
        _name = name;
        LayerType = type;
        _id = id;
        _seed = seed;
        _noise = noise;
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