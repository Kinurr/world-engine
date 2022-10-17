using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Utils;

namespace WorldEngine.World;

public class World
{
    private Ruleset _rules { get; }

    public Layer AltitudeLayer { get; private set; }
    public Layer PrecipitationLayer { get; private set; }
    public Layer TemperatureLayer { get; private set; }

    public World(Ruleset rules, Layer altitudeLayer, Layer precipitationLayer, Layer temperatureLayer)
    {
        _rules = rules;
        AltitudeLayer = altitudeLayer;
        PrecipitationLayer = precipitationLayer;
        TemperatureLayer = temperatureLayer;
        InitializeLayers();
    }

    private void InitializeLayers()
    {
        // Id attribution
        AltitudeLayer.Id = 1;
        PrecipitationLayer.Id = 2;
        TemperatureLayer.Id = 3;

        // Layer initialization
        AltitudeLayer.SetupGenerator(_rules.Seed / 1);
        PrecipitationLayer.SetupGenerator(_rules.Seed / 2);
        TemperatureLayer.SetupGenerator(_rules.Seed / 3);
    }

    public WorldTile GetTileAt(int x, int y)
    {
        WorldTile tile;

        var altitudeValue = (int)AltitudeLayer.GetTileAt(x, y);
        var temperatureValue = (int)TemperatureLayer.GetTileAt(x, y);
        var precipitationValue = (int)PrecipitationLayer.GetTileAt(x, y);

        // Console.WriteLine($" Altitude: {altitudeValue} - Temperature: {temperatureValue} - Precipitation: {precipitationValue}");

        if (altitudeValue < _rules.WaterLevel)
            tile = new WorldTile(x, y, BiomeTypes.DeepOcean, 0, 0, 0);
        else
        {
            tile = new WorldTile(
                x,
                y,
                Biomes.GetBiome(altitudeValue, precipitationValue, temperatureValue),
                altitudeValue,
                temperatureValue,
                precipitationValue);
        }

        return tile;
    } 
}