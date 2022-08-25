using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Core;
using WorldEngine.Utils;

namespace WorldEngine.World;

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
        var landmassLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Landmass);
        var altitudeLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Altitude);
        WorldTile _tile;

        float? _landValue = landmassLayer?.GetTileAt(x, y);

        if (_landValue < Rules.WaterLevel)
            _tile = new WorldTile(x, y, Biomes.Water, 0);
        else
        {
            _tile = new WorldTile(x, y, Biomes.Land,
                GetAltitude(landmassLayer.GetTileAt(x, y), altitudeLayer.GetTileAt(x, y)));
        }

        return _tile;
    }

    private int GetAltitude(float landmassValue, float altitudeValue) =>
        (int)(MathF.Abs(landmassValue + (altitudeValue / 2)) * Rules.MaxAltitude);
}