using WorldGenerator.Layers;
using WorldGenerator.Rules;

namespace WorldGenerator.World;

public class World
{
    public List<WorldTile> Tilemap { get; set; }

    public Ruleset Rules { get; set; }
    
    public World(Ruleset rules)
    {
        Rules = rules;
        Tilemap = new List<WorldTile>();
    }

    public void Generate(List<Layer> layers)
    {
        // Get layers.
        var waterLayer = layers.FirstOrDefault(l => l.LayerType == LayerTypes.Water);
        var altitudeLayer = layers.FirstOrDefault(l => l.LayerType == LayerTypes.Altitude);

        // Figure out biomes and tilemap.
        WorldTile _tile;
        
        for (var x = 0; x < Rules.Width; x++)
        {
            for (var y = 0; y < Rules.Height; y++)
            {
                if (waterLayer.GetTileAt(x, y) < Rules.WaterLevel)
                    _tile = new WorldTile(x, y, Biomes.Water);
                else
                    _tile = new WorldTile(x, y, Biomes.Land);

                Tilemap.Add(_tile);
            }
        }
    }

    public WorldTile GetTileAt(int x, int y)
    {
        var tile = Tilemap.FirstOrDefault(wt => wt.XCoordinate == x && wt.YCoordinate == y);

        if (tile != null)
            return tile;
        else
            throw new Exception("No tile at these coordinates.");
    }

}