namespace WorldGenerator.Rules;

/// <summary>
/// Ruleset for map generator. 
/// </summary>
public class Ruleset
{
    /// <summary>
    /// Constructor for generator ruleset.
    /// </summary>
    /// <param name="name">Name of the ruleset.</param>
    /// <param name="seed">Seed for the map generator.</param>
    /// <param name="width">Map width in pixels.</param>
    /// <param name="height">Map width in pixels.</param>
    /// <param name="waterLevel">Map water level.</param>
    /// <param name="frequency">Perlin noise frequency.</param>
    /// <param name="octaves">Perlin noise octaves.</param>
    public Ruleset(string name, int seed, float waterLevel = 0.002f, float frequency = 0.0025f, int octaves = 8)
    {
        Name = name;
        Seed = seed;
        WaterLevel = waterLevel;
        Frequency = frequency;
        Octaves = octaves;
    }

    /// <summary>
    /// Name of the ruleset.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Seed for the map generator.
    /// </summary>
    public int Seed { get; set; }
    
    /// <summary>
    /// Map water level.
    /// </summary>
    public float WaterLevel { get; set; }

    /// <summary>
    /// Perlin noise frequency.
    /// </summary>
    public float Frequency { get; set; }

    /// <summary>
    /// Perlin noise octaves.
    /// </summary>
    public int Octaves { get; set; }
}