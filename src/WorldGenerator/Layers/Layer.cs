using WorldGenerator.Core;
using WorldGenerator.Rules;
using WorldGenerator.Utils;

namespace WorldGenerator.Layers;

/// <summary>
/// Represents a map layer.
/// </summary>
public class Layer
{
    private int[,] map;

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
    /// Initializes map layer.
    /// </summary>
    /// <param name="seed">Seed used to generate layer.</param>
    /// <param name="ruleset"></param>
    public Layer(string name, Ruleset ruleset)
    {
        this.Name = name;
        this.ruleset = ruleset;
    }

    /// <summary>
    /// Generates noisemap for this layer.
    /// </summary>
    public void Generate()
    {
        try
        {
            map = NoiseGenerator.GenerateNoise(ruleset.Width, ruleset.Height, FastNoise.NoiseType.PerlinFractal,
                ruleset.Frequency, ruleset.Octaves);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Returns true if the layer has been gennerated.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => map.Length <= 0;

    /// <summary>
    /// Returns the tile value at a given coordinate.
    /// </summary>
    /// <param name="x">X coordinate value.</param>
    /// <param name="y">Y coordinate value.</param>
    /// <returns></returns>
    public int GetTileAt(int x, int y) => IsEmpty() ? 0 : map[x, y];

    public int[,] GetTileChunkAt(int x, int y, int width, int height)
    {
        var chunk = new int[width, height];

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