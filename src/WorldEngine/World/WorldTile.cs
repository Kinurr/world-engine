using System.Numerics;

namespace WorldEngine.World;

public class WorldTile
{
    /// <summary>
    /// Ecological biome of this tile.
    /// </summary>
    public Biomes Biome { get; }

    /// <summary>
    /// 2D X coordinate
    /// </summary>
    public int XCoordinate { get; }

    /// <summary>
    /// 2D Y coordinate.
    /// </summary>
    public int YCoordinate { get; }
    
    /// <summary>
    /// Altitude of this tile relative to sea-level in m
    /// </summary>
    public int Altitude { get; }
    
    /// <summary>
    /// Average annual temperature of this tile in Cº
    /// </summary>
    public int Temperature { get; }
    
    /// <summary>
    /// Average annual precipitation of this tile in cm
    /// </summary>
    public int Precipitation { get; }

    
    public WorldTile(int x, int y, Biomes biome, int altitude, int temperature, int precipitation)
    {
        Biome = biome;
        XCoordinate = x;
        YCoordinate = y;
        Altitude = altitude;
        Temperature = temperature;
        Precipitation = precipitation;
    }
}