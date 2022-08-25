using WorldEngine.Layers;
using WorldEngine.Rules;

namespace WorldEngine;

using System.ComponentModel;
using System.Data;
using SkiaSharp;
using WorldEngine.Core;
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

    private List<Layer> layers;

    public LayerTypes[] RequiredLayers =
    {
        LayerTypes.Landmass
    };

    public Generator(Ruleset rules)
    {
        Rules = rules;
        layers = new List<Layer>();
    }

    public Generator(Ruleset rules, List<Layer> layers)
    {
        Rules = rules;
        this.layers = layers;
    }

    public World.World CreateWorld()
    {
        ValidateLayers();
        
        var world = new World.World(Rules, layers);

        return world;
    }

    private void ValidateLayers()
    {
        var currentLayerTypes = new List<LayerTypes>();

        foreach (var layer in layers)
            currentLayerTypes.Add(layer.LayerType);

        if (RequiredLayers.Except(currentLayerTypes).Any())
            throw new Exception("Missing required layers.");
    }
}