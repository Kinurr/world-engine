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
        var altitudeValue = GetAltitude(LandmassLayer.GetTileAt(x, y), AltitudeLayer.GetTileAt(x, y));
        var temperatureValue = GetTemperature(TemperatureLayer.GetTileAt(x, y));
        var precipitationValue = GetPrecipitation(PrecipitationLayer.GetTileAt(x, y));

        if (landValue < _rules.WaterLevel)
            tile = new WorldTile(x, y, BiomeTypes.DeepOcean, 0, 0, 0);
        else
        {
            tile = new WorldTile(
                x, 
                y, 
                Biomes.GetBiome(landValue, altitudeValue, precipitationValue, temperatureValue),
                altitudeValue,
                temperatureValue,
                precipitationValue);
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