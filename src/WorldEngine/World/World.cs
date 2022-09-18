using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Utils;

namespace WorldEngine.World;

public class World
{
    private Ruleset _rules { get; }

    private List<Layer> Layers { get; }
    
    public World(Ruleset rules, List<Layer> layers)
    {
        _rules = rules;
        Layers = layers;
        
        InitializeLayers();
    }

    private void InitializeLayers()
    {
        foreach (var layer in Layers)
        {
            layer.Id = Layers.IndexOf(layer);
            layer.SetupGenerator(_rules.Seed / (layer.Id + 1));
        }
    }

    public WorldTile GetTileAt(int x, int y)
    {
        var landmassLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Landmass);
        var altitudeLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Altitude);
        var precipitationLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Precipitation);
        var temperatureLayer = Layers.FirstOrDefault(l => l.LayerType == LayerTypes.Temperature);
        
        WorldTile tile;

        var _landValue = landmassLayer.GetTileAt(x, y);
        var _altitudeValue = GetAltitude(landmassLayer.GetTileAt(x, y), altitudeLayer.GetTileAt(x, y));
        var _temperatureValue = GetTemperature(temperatureLayer.GetTileAt(x, y));
        var _precipitationValue = GetPrecipitation(precipitationLayer.GetTileAt(x, y));

        if (_landValue < _rules.WaterLevel)
            tile = new WorldTile(x, y, BiomeTypes.DeepOcean, 0, 0, 0);
        else
        {
            tile = new WorldTile(
                x, 
                y, 
                Biomes.GetBiome(_landValue, _altitudeValue, _precipitationValue, _temperatureValue),
                _altitudeValue,
                _temperatureValue,
                _precipitationValue);
        }

        return tile;
    }

    private int GetAltitude(float landmassValue, float altitudeValue) =>
        (int)(MathF.Abs(landmassValue + (altitudeValue / 2)) * _rules.MaxAltitude);

    private int GetPrecipitation(float precipitationValue) =>
        (int)precipitationValue.Remap(-1, 1, _rules.MinPrecipitation, _rules.MaxPrecipitation);

    private int GetTemperature(float temperatureValue) => 
        (int)temperatureValue.Remap(-1, 1, _rules.MinTemperature, _rules.MaxTemperature);


}