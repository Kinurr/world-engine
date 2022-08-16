using WorldGenerator.Core;
using WorldGenerator.Layers;
using WorldGenerator.Rules;
using WorldGenerator.Utils;

namespace WorldGenerator.World;

public class World
{
    public Ruleset Rules { get; set; }

    public List<Layer> Layers { get; set; }
    
    public World(Ruleset rules, List<Layer> layers)
    {
        Rules = rules;
        Layers = layers;
    }

    public WorldTile GetTileAt(int x, int y)
    {
        var waterLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Water);
        // var altitudeLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Altitude);
        WorldTile _tile;
        
        if (waterLayer?.GetTileAt(x, y) < Rules.WaterLevel)
            _tile = new WorldTile(x, y, Biomes.Water);
        else
            _tile = new WorldTile(x, y, Biomes.Land);
    
        return _tile;
    }

}