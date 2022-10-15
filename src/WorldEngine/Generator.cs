using WorldEngine.Layers;
using WorldEngine.Rules;

namespace WorldEngine;

using System.ComponentModel;
using System.Data;
using SkiaSharp;
using Noise;
using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Utils;
using WorldEngine.World;

/// <summary>
/// A high level object capable of randomly generating a 2-dimensional map from a given ruleset and multiple layers.
/// </summary>
public class Generator
{
    public Ruleset Rules { get; set; }

    public Layer LandmassLayer { get; set; }

    public Layer AltitudeLayer { get; set; }

    public Layer PrecipitationLayer { get; set; }

    public Layer TemperatureLayer { get; set; }

    public Generator(Ruleset rules, Layer landmassLayer, Layer altitudeLayer, Layer precipitationLayer,
        Layer temperatureLayer)
    {
        Rules = rules;
        LandmassLayer = landmassLayer;
        AltitudeLayer = altitudeLayer;
        PrecipitationLayer = precipitationLayer;
        TemperatureLayer = temperatureLayer;
    }

    public World.World CreateWorld()
    {
        var world = new World.World(Rules, LandmassLayer, AltitudeLayer, PrecipitationLayer, TemperatureLayer);

        return world;
    }
}