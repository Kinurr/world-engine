using System.Numerics;

namespace WorldEngine.World;

public class WorldTile
{
    public Biomes Biome { get; }

    public int XCoordinate { get; }

    public int YCoordinate { get; }
    
    public int Altitude { get; }

    
    public WorldTile(int x, int y, Biomes biome, int altitude)
    {
        Biome = biome;
        XCoordinate = x;
        YCoordinate = y;
        Altitude = altitude;
    }
}