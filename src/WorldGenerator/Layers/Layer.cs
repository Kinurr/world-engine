using WorldGenerator.Core;
using WorldGenerator.Rules;
using WorldGenerator.Utils;

namespace WorldGenerator.Layers;

/// <summary>
/// Represents a map layer.
/// </summary>
public class Layer
{
    private Ruleset ruleset;

    /// <summary>
    /// Layer name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Layer type.
    /// </summary>
    public LayerTypes LayerType { get; set; }
    
    /// <summary>
    /// Layer ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Initializes map layer.
    /// </summary>
    /// <param name="seed">Seed used to generate layer.</param>
    /// <param name="ruleset"></param>
    public Layer(string name, int id, Ruleset ruleset, LayerTypes type)
    {
        this.Name = name;
        this.ruleset = ruleset;
        this.LayerType = type;
        this.Id = id;
    }

    /// <summary>
    /// Returns the tile value at a given coordinate.
    /// </summary>
    /// <param name="x">X coordinate value.</param>
    /// <param name="y">Y coordinate value.</param>
    /// <returns></returns>
    public float GetTileAt(int x, int y) =>
        NoiseGenerator.GenerateNoise(x, y, ruleset.Seed, FastNoise.NoiseType.PerlinFractal, 
            ruleset.Frequency, ruleset.Octaves);
    
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