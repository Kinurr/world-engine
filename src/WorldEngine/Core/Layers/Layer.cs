using WorldEngine.Core.Noise;
using WorldEngine.Core.Utils;

namespace WorldEngine.Core.Layers;

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
    /// Layer name. Used to identify this layer in the layer collection.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Upper limit for this layer's tile value;
    /// </summary>
    public float MaximumValue { get; set; }


    /// <summary>
    /// Lower limit for this layer's tile value;
    /// </summary>
    public float MinimumValue { get; set; }

    /// <summary>
    /// Noise profile.
    /// </summary>
    private INoise _noise { get; }

    /// <summary>
    /// Initializes map layer
    /// </summary>
    /// <param name="noise">Noise map</param>
    /// <param name="type">Layer type</param>
    public Layer(string name, LayerTypes type, INoise noise, float minimumValue, float maximumValue)
    {
        Name = name;
        LayerType = type;
        _noise = noise;
        MinimumValue = minimumValue;
        MaximumValue = maximumValue;
    }

    /// <summary>
    /// Initializes noise generator if it hasn't been already.
    /// </summary>
    /// <param name="seed"></param>
    public void SetupGenerator(int seed)
    {
        // If noise has no seed, initialize noise generator with seed.
        if (_noise.Seed == null)
            _noise.SetupGenerator(seed);
    }

    /// <summary>
    /// Returns the tile value at a given coordinate.
    /// </summary>
    /// <param name="x">X coordinate value.</param>
    /// <param name="y">Y coordinate value.</param>
    /// <returns></returns>
    public float GetTileAt(int x, int y) => MapNoiseToLayerRange(_noise.Get(x, y));

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

    /// <summary>
    /// Maps a noise value to this layer's value range.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private float MapNoiseToLayerRange(float value) =>
        value.Remap(-1, 1, MinimumValue, MaximumValue);
}