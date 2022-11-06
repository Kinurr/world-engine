using WorldEngine.Core.Layers;
using WorldEngine.Core.Rules;

namespace WorldEngine.Core;

using System.ComponentModel;
using System.Data;
using SkiaSharp;
using Noise;
using WorldEngine.Core.Layers;
using WorldEngine.Core.Rules;
using WorldEngine.Core.Utils;
using WorldEngine.Core.World;

/// <summary>
/// A high level object capable of randomly generating a 2-dimensional map from a given ruleset and multiple layers.
/// </summary>
public class Generator
{
    public Ruleset Rules { get; set; }

    public Layer AltitudeLayer { get; set; }

    public Layer PrecipitationLayer { get; set; }

    public Layer TemperatureLayer { get; set; }

    public Generator(Ruleset rules, Layer altitudeLayer, Layer precipitationLayer,
        Layer temperatureLayer)
    {
        Rules = rules;
        AltitudeLayer = altitudeLayer;
        PrecipitationLayer = precipitationLayer;
        TemperatureLayer = temperatureLayer;
    }

    public Generator(Profile profile)
    {
        Rules = profile.Rules;
        AltitudeLayer = profile.AltitudeLayer;
        PrecipitationLayer = profile.PrecipitationLayer;
        TemperatureLayer = profile.TemperatureLayer;
    }

    public World.World CreateWorld()
    {
        var world = new World.World(Rules, AltitudeLayer, PrecipitationLayer, TemperatureLayer);

        return world;
    }
}