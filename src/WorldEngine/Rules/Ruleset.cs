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
    /// <param name="maxAltitude">Maximum altitude in m relative to sea level in m.</param>
    /// <param name="maxPrecipitation">Maximum average annual precipitation in cm.</param>
    /// <param name="minTemperature">Minimum average annual temperature in Cº</param>
    /// <param name="maxTemperature">Maximum average annual temperature in Cº</param>
    public Ruleset(string name, 
        int seed, 
        float waterLevel = 0.002f, 
        int maxAltitude = 1000, 
        int maxPrecipitation = 400,
        int minTemperature = -10,
        int maxTemperature = 30)
    {
        Name = name;
        Seed = seed;
        WaterLevel = waterLevel;
        MaxAltitude = maxAltitude;
        MaxPrecipitation = maxPrecipitation;
        MinTemperature = minTemperature;
        MaxTemperature = maxTemperature;
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
    
    /// <summary>
    /// Maximum altitude in m relative to sea level in m.
    /// </summary>
    public int MaxAltitude { get; }
    
    /// <summary>
    /// Maximum average annual precipitation in cm.
    /// </summary>
    public int MaxPrecipitation { get; }

    /// <summary>
    /// Minimum average annual temperature in Cº 
    /// </summary>
    public int MinTemperature { get; }

    /// <summary>
    /// Maximum average annual temperature in Cº
    /// </summary>
    public int MaxTemperature { get; }
}