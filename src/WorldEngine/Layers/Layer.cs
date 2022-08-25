using WorldEngine.Core;
using WorldEngine.Rules;
using WorldEngine.Utils;

namespace WorldEngine.Layers;

/// <summary>
/// Represents a map layer.
/// </summary>
public class Layer
{
    /// <summary>
    /// Layer name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Layer type.
    /// </summary>
    public LayerTypes LayerType { get; }

    /// <summary>
    /// Layer ID.
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Type of noise used to generate this layer.
    /// </summary>
    public FastNoise.NoiseType NoiseType { get; }

    /// <summary>
    /// Seed for the map generator.
    /// </summary>
    public int Seed { get; }

    /// <summary>
    /// Perlin noise frequency.
    /// </summary>
    public float Frequency { get; }

    /// <summary>
    /// Perlin noise octaves.
    /// </summary>
    public int Octaves { get; }

    /// <summary>
    /// Initializes map layer
    /// </summary>
    /// <param name="name">Layer name</param>
    /// <param name="id">Layer id</param>
    /// <param name="ruleset">World ruleset</param>
    /// <param name="type">Layer type</param>
    /// <param name="seed">Generator seed</param>
    /// <param name="frequency">Fractal perlin frequency</param>
    /// <param name="octaves">Fractal perlin octaves</param>
    public Layer(string name, int id, LayerTypes type, FastNoise.NoiseType noiseType, int seed, float frequency, int octaves)
    {
        Name = name;
        LayerType = type;
        Id = id;
        Seed = seed;
        Frequency = frequency;
        Octaves = octaves;
        NoiseType = noiseType;
    }

    /// <summary>
    /// Returns the tile value at a given coordinate.
    /// </summary>
    /// <param name="x">X coordinate value.</param>
    /// <param name="y">Y coordinate value.</param>
    /// <returns></returns>
    public float GetTileAt(int x, int y) =>
        NoiseGenerator.GenerateNoise(x, y, Seed / Id, FastNoise.NoiseType.PerlinFractal, Frequency, Octaves);

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
            {
                for (var j = 0; j < height; j++)
                {
                    chunk[i, j] = GetTileAt(x + i, y + j);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return chunk;
    }
}