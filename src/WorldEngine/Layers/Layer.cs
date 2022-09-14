using System.Data;
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
    /// Seed for the map generator.
    /// </summary>
    public int Seed { get; }

    /// <summary>
    /// Noise profile.
    /// </summary>
    public NoiseProfile NoiseProfile { get; }

    private float max = 0, min = 0;
    
    /// <summary>
    /// Initializes map layer
    /// </summary>
    /// <param name="name">Layer name</param>
    /// <param name="id">Layer id</param>
    /// <param name="noiseProfile">World ruleset</param>
    /// <param name="type">Layer type</param>
    /// <param name="seed">Generator seed</param>
    public Layer(string name, int id, LayerTypes type, int seed, NoiseProfile noiseProfile)
    {
        Name = name;
        LayerType = type;
        Id = id;
        Seed = seed;
        NoiseProfile = noiseProfile;
    }

    /// <summary>
    /// Returns the tile value at a given coordinate.
    /// </summary>
    /// <param name="x">X coordinate value.</param>
    /// <param name="y">Y coordinate value.</param>
    /// <returns></returns>
    public float GetTileAt(int x, int y)
    {
        var value = NoiseGenerator.GetNoise(x, y, Seed / Id, NoiseProfile);

        // if (LayerType == LayerTypes.Precipitation)
        // {
        //     if (max == 0)
        //         max = value;
        //     
        //     if (min == 0)
        //         min = value;
        //
        //     if (value > max)
        //         max = value;
        //
        //     if (value < min)
        //         min = value;
        //     
        //     Console.WriteLine($"{value} max: {max}, min: {min}");
        // }
        
        return value;
    }

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