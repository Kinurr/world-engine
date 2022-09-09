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
    
    private float max = 0, min = 0;

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
                GetPrecipitation(precipitationLayer.GetTileAt(x, y)),
                GetTemperature(temperatureLayer.GetTileAt(x, y)));

            if (landmassLayer.GetTileAt(x, y) > max)
                max = landmassLayer.GetTileAt(x, y);
            
            
            if (landmassLayer.GetTileAt(x, y) < min)
                min = landmassLayer.GetTileAt(x, y);
            
            // Console.WriteLine($"({x}, {y}) - {_tile.Altitude} m - {temperatureLayer.GetTileAt(x, y)} Cº - {precipitationLayer.GetTileAt(x, y)} cm - max: {max} min: {min}");
        }

        return _tile;
    }

    private int GetAltitude(float landmassValue, float altitudeValue) =>
        (int)(MathF.Abs(landmassValue + (altitudeValue / 2)) * Rules.MaxAltitude);

    private int GetPrecipitation(float precipitationValue) =>
        (int)Utils.MathUtils.Map(precipitationValue, -.5f, .5f, 0, Rules.MaxPrecipitation);

    private int GetTemperature(float temperatureValue) => 
        (int)Utils.MathUtils.Map(temperatureValue, -.5f, .5f, Rules.MinTemperature, Rules.MaxTemperature);


}