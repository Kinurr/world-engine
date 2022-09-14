using System.Security.Cryptography;
using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Core;
using WorldEngine.Utils;

namespace WorldEngine.World;

public class World
{
    private Ruleset Rules { get; }

    private List<Layer> Layers { get; }
    
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
        
        WorldTile tile;

        var _landValue = landmassLayer.GetTileAt(x, y);
        var _altitudeValue = GetAltitude(landmassLayer.GetTileAt(x, y), altitudeLayer.GetTileAt(x, y));
        var _temperatureValue = GetTemperature(temperatureLayer.GetTileAt(x, y));
        var _precipitationValue = GetPrecipitation(precipitationLayer.GetTileAt(x, y));

        if (_landValue is < 0 and >= -.04f)
            tile = new WorldTile(x, y, BiomeTypes.ShallowOcean, 0, 0, 0);
        else if (_landValue > -.04f)
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

            // Console.WriteLine($"({x}, {y}) - {tile.Altitude} m - {tile.Temperature} Cº - {tile.Precipitation} cm² - {tile.Biome}");
        }

        return tile;
    }

    private int GetAltitude(float landmassValue, float altitudeValue) =>
        (int)(MathF.Abs(landmassValue + (altitudeValue / 2)) * Rules.MaxAltitude);

    private int GetPrecipitation(float precipitationValue) =>
        (int)precipitationValue.Remap(-1, 1, Rules.MinPrecipitation, Rules.MaxPrecipitation);

    private int GetTemperature(float temperatureValue) => 
        (int)temperatureValue.Remap(-1, 1, Rules.MinTemperature, Rules.MaxTemperature);


}