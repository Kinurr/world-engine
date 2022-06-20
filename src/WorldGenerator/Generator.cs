namespace WorldGenerator;

using System.ComponentModel;
using System.Data;
using SkiaSharp;
using WorldGenerator.Core;
using WorldGenerator.Layers;
using WorldGenerator.Rules;
using WorldGenerator.Utils;
using WorldGenerator.World;

/// <summary>
/// A high level object capable of randomly generating a 2-dimensional map from a given ruleset and multiple layers.
/// </summary>
public class Generator
{
    public Ruleset Rules { get; set; }

    private List<Layer> layers;

    public LayerTypes[] RequiredLayers =
    {
        LayerTypes.Water,
        LayerTypes.Altitude
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

    public World.World GenerateWorld()
    {
        ValidateLayers();
        
        foreach (var layer in layers.Where(layer => !layer.IsEmpty()))
            layer.Generate();

        var world = new World.World(Rules);

        world.Generate(layers);
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

    // public static void TestGenerate()
    // {
    //     Console.WriteLine("Printed from library.");
    //
    //     Console.WriteLine("Generating map...");
    //
    //     var rules = new Ruleset("Da Rules");
    //
    //     SKBitmap landMap = NoiseGenerator.GenerateNoise(1920, 1080, FastNoise.NoiseType.PerlinFractal, 0.0025f, 12);
    //     SKBitmap heightMap = NoiseGenerator.GenerateNoise(1920, 1080, FastNoise.NoiseType.PerlinFractal, 0.0025f, 12);
    //
    //     IOUtils.SaveSKBitmapLocally(Directory.GetCurrentDirectory() + "/map.png",
    //         TerrainPainter.PaintTerrain(landMap, heightMap));
    //
    //     Console.WriteLine("Map generated and saved.");
    // }
}