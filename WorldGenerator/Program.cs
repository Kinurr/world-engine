using SkiaSharp;
using WorldGenerator.Core;
using WorldGenerator.Utils;

Console.WriteLine("Generating map...");

SKBitmap noiseMap = NoiseGenerator.GenerateNoise(1920, 1080, FastNoise.NoiseType.PerlinFractal, 0.0025f, 12);

IOUtils.SaveSKBitmapLocally(Directory.GetCurrentDirectory() + "/map.png", TerrainPainter.PaintTerrain(noiseMap));

Console.WriteLine("Map generated and saved.");
