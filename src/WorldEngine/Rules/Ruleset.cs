namespace WorldEngine.Rules;

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
    /// <param name="waterLevel">Map water level.</param>
    public Ruleset(string name, int seed, float waterLevel = 0.0f)
    {
        Name = name;
        Seed = seed;
        WaterLevel = waterLevel;
    }

    /// <summary>
    /// Name of the ruleset.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Seed for the map generator.
    /// </summary>
    public int Seed { get; }

    /// <summary>
    /// Map water level.
    /// </summary>
    public float WaterLevel { get; }
}