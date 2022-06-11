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
    /// <param name="width">Map width in pixels.</param>
    /// <param name="height">Map width in pixels.</param>
    /// <param name="waterLevel">Map water level.</param>
    /// <param name="frequency">Perlin noise frequency.</param>
    /// <param name="octaves">Perlin noise octaves.</param>
    public Ruleset(string name, int width = 1920, int height = 1080, byte waterLevel = 90, float frequency = 0.0025f, int octaves = 12)
    {
        Name = name;
        Width = width;
        Height = height;
        WaterLevel = waterLevel;
        Frequency = frequency;
        Octaves = octaves;
    }

    /// <summary>
    /// Name of the ruleset.
    /// </summary>
    private string Name { get; set; }

    /// <summary>
    /// Map width in pixels.
    /// </summary>
    public int Width { get; set; }
    
    /// <summary>
    /// Map height in pixels.
    /// </summary>
    public int Height { get; set; }
    
    /// <summary>
    /// Map water level.
    /// </summary>
    private byte WaterLevel { get; set; }
    
    /// <summary>
    /// Perlin noise frequency.
    /// </summary>
    private float Frequency { get; set; }
    
    /// <summary>
    /// Perlin noise octaves.
    /// </summary>
    private int Octaves { get; set; }

    /// <summary>
    /// Returns true if object is equal to other.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool IsEqual(Ruleset other)
    {
        if (Name != other.Name)
            return false;
        
        if (WaterLevel != other.WaterLevel)
            return false;
        
        if (Frequency.CompareTo(other.Frequency) != 0)
            return false;
        
        if (Octaves != other.Octaves)
            return false;

        return true;
    }
}