using System.Numerics;

namespace WorldGenerator.World;

public class WorldTile
{
    public Biomes Biome { get; }

    public int XCoordinate { get; }

    public int YCoordinate { get; }

    public WorldTile(int x, int y, Biomes biome)
    {
        Biome = biome;
        XCoordinate = x;
        YCoordinate = y;
    }
}