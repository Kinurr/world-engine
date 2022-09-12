using System.Security.Cryptography;
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
        var precipitationLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Precipitation);
        var temperatureLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Temperature);

        
        WorldTile _tile;

        float? _landValue = landmassLayer?.GetTileAt(x, y);

        if (_landValue < 0)
            _tile = new WorldTile(x, y, Biomes.Water, 0, 0, 0);
        else
        {
            _tile = new WorldTile(x, y, Biomes.Land,
                GetAltitude(landmassLayer.GetTileAt(x, y), altitudeLayer.GetTileAt(x, y)),
                GetTemperature(precipitationLayer.GetTileAt(x, y)),
                GetPrecipitation(temperatureLayer.GetTileAt(x, y)));

            Console.WriteLine($"({x}, {y}) - {_tile.Altitude} m - {_tile.Temperature} Cº - {_tile.Precipitation} cm²");
        }

        return _tile;
    }

    private int GetAltitude(float landmassValue, float altitudeValue) =>
        (int)(MathF.Abs(landmassValue + (altitudeValue / 2)) * Rules.MaxAltitude);

    private int GetPrecipitation(float precipitationValue) =>
        (int)Utils.MathUtils.Remap(precipitationValue, -1f, .1f, 0, Rules.MaxPrecipitation);

    private int GetTemperature(float temperatureValue) => 
        (int)Utils.MathUtils.Remap(temperatureValue, -1f, .1f, Rules.MinTemperature, Rules.MaxTemperature);


}