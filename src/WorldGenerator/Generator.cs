using SkiaSharp;
using WorldGenerator.Core;
using WorldGenerator.Rules;
using WorldGenerator.Utils;

namespace WorldGenerator;

public static class Generator
{
    public static void TestGenerate()
    {
        Console.WriteLine("Printed from library.");
        
        Console.WriteLine("Generating map...");

        var rules = new Ruleset("Da Rules");

        SKBitmap landMap = NoiseGenerator.GenerateNoise(1920, 1080, FastNoise.NoiseType.PerlinFractal, 0.0025f, 12);
        SKBitmap heightMap = NoiseGenerator.GenerateNoise(1920, 1080, FastNoise.NoiseType.PerlinFractal, 0.0025f, 12);

        IOUtils.SaveSKBitmapLocally(Directory.GetCurrentDirectory() + "/map.png", TerrainPainter.PaintTerrain(landMap, heightMap));

        Console.WriteLine("Map generated and saved.");
    }
}