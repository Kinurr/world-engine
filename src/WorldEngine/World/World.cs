using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Utils;

namespace WorldEngine.World;

public class World
{
    private Ruleset _rules { get; }

    public Layer LandmassLayer { get; private set; }
    public Layer AltitudeLayer { get; private set; }
    public Layer PrecipitationLayer { get; private set; }
    public Layer TemperatureLayer { get; private set; }

    public World(Ruleset rules, Layer landmassLayer, Layer altitudeLayer, Layer precipitationLayer, Layer temperatureLayer)
    {
        _rules = rules;
        LandmassLayer = landmassLayer;
        AltitudeLayer = altitudeLayer;
        PrecipitationLayer = precipitationLayer;
        TemperatureLayer = temperatureLayer;
        InitializeLayers();
    }

    private void InitializeLayers()
    {
        // Id attribution
        LandmassLayer.Id = 1;
        AltitudeLayer.Id = 2;
        PrecipitationLayer.Id = 3;
        TemperatureLayer.Id = 4;

        // Layer initialization
        LandmassLayer.SetupGenerator(_rules.Seed);
        AltitudeLayer.SetupGenerator(_rules.Seed / 2);
        PrecipitationLayer.SetupGenerator(_rules.Seed / 3);
        TemperatureLayer.SetupGenerator(_rules.Seed / 4);
    }

    public WorldTile GetTileAt(int x, int y)
    {
        WorldTile tile;

        var landValue = LandmassLayer.GetTileAt(x, y);
        var altitudeValue = AltitudeLayer.GetTileAt(x, y);
        var temperatureValue = TemperatureLayer.GetTileAt(x, y);
        var precipitationValue = PrecipitationLayer.GetTileAt(x, y);

        if (landValue < _rules.WaterLevel)
            tile = new WorldTile(x, y, BiomeTypes.DeepOcean, 0, 0, 0);
        else
        {
            tile = new WorldTile(
                x,
                y,
                Biomes.GetBiome(landValue, (int)altitudeValue, (int)precipitationValue, (int)temperatureValue),
                (int)altitudeValue,
                (int)temperatureValue,
                (int)precipitationValue);
        }

        return tile;
    } 
}