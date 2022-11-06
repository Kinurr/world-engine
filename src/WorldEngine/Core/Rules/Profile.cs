using System.Numerics;
using WorldEngine.Core.Layers;
using WorldEngine.Core.Noise;
using WorldEngine.Core.Rules;

namespace WorldEngine.Core.World;

public class Profile
{
    public Ruleset Rules { get; set; }

    public Layer AltitudeLayer { get; set; }

    public Layer PrecipitationLayer { get; set; }

    public Layer TemperatureLayer { get; set; }


    public Profile(Ruleset rules, Layer altitudeLayer, Layer precipitationLayer, Layer temperatureLayer)
    {
        Rules = rules;
        AltitudeLayer = altitudeLayer;
        PrecipitationLayer = precipitationLayer;
        TemperatureLayer = temperatureLayer;
    }

    internal Profile(DefaultProfileSettings defaultProfile)
    {
        int seed = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        switch (defaultProfile)
        {
            case DefaultProfileSettings.EndlessEarthlike:
                Rules = new Ruleset(defaultProfile.ToString(), seed, 1200);
                AltitudeLayer = new Layer("Altitude", LayerTypes.Altitude, new FractalPerlinNoise(0.003f, 6, 0.4f, 2), 0, 2500);
                PrecipitationLayer = new Layer("Precipitation", LayerTypes.Precipitation, new SinusoidalNoise(offset: new Vector2(0, -100), periodMultiplier: 0.012f, helperNoiseMultiplier: 1.8f), 0, 350);
                TemperatureLayer = new Layer("Temperature", LayerTypes.Temperature, new SinusoidalNoise(offset: new Vector2(0, -200), helperNoiseMultiplier: 0.8f), 0, 27);

                break;
            case DefaultProfileSettings.EndlessFractal:
                Rules = new Ruleset(defaultProfile.ToString(), seed, 1200);
                AltitudeLayer = new Layer("Altitude", LayerTypes.Altitude, new FractalPerlinNoise(0.005f, 6, 0.4f, 2), 0, 2500);
                PrecipitationLayer = new Layer("Precipitation", LayerTypes.Precipitation, new FractalPerlinNoise(0.006f, 6, 0.4f, 2), 0, 350);
                TemperatureLayer = new Layer("Temperature", LayerTypes.Temperature, new FractalPerlinNoise(0.004f, 6, 0.4f, 2), -20, 50);
                
                break;
            default:
                Rules = new Ruleset("Default", seed, 1200);
                AltitudeLayer = new Layer("Altitude", LayerTypes.Altitude, new FractalPerlinNoise(0.005f, 6, 0.4f, 2), 0, 2500);
                PrecipitationLayer = new Layer("Precipitation", LayerTypes.Precipitation, new SinusoidalNoise(offset: new Vector2(0, -100), periodMultiplier: 0.012f, helperNoiseMultiplier: 1.8f), 0, 350);
                TemperatureLayer = new Layer("Temperature", LayerTypes.Temperature, new SinusoidalNoise(offset: new Vector2(0, -200), helperNoiseMultiplier: 2f), 0, 27);
               
                break;
        }
    }
}

internal enum DefaultProfileSettings
{
    EndlessEarthlike,
    EndlessFractal
}

public struct Profiles {
    public static Profile EndlessEarthlike => new Profile(DefaultProfileSettings.EndlessEarthlike);
    public static Profile EndlessFractal => new Profile(DefaultProfileSettings.EndlessFractal);
} 