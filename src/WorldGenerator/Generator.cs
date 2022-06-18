using System.ComponentModel;
using System.Data;
using SkiaSharp;
using WorldGenerator.Core;
using WorldGenerator.Layers;
using WorldGenerator.Rules;
using WorldGenerator.Utils;
using WorldGenerator.World;

namespace WorldGenerator;

/// <summary>
/// A high level object capable of randomly generating a 2-dimensional map from a given ruleset and multiple layers.
/// </summary>
public class Generator
{
    public Ruleset Ruleset { get; set; }

    private List<Layer> layers;

    public LayerTypes[] RequiredLayers =
    {
        LayerTypes.Water,
        LayerTypes.Altitude
    };

    public Generator(Ruleset ruleset)
    {
        Ruleset = ruleset;
        layers = new List<Layer>();
    }

    public Generator(Ruleset ruleset, List<Layer> layers)
    {
        Ruleset = ruleset;
        this.layers = layers;
    }

    public World.World GenerateWorld()
    {
        ValidateLayers();
        
        foreach (var layer in layers.Where(layer => !layer.IsEmpty()))
            layer.Generate();

        return new World.World();
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