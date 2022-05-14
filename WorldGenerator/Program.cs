using SkiaSharp;
using WorldGenerator.Core;
using WorldGenerator.Utils;

Console.WriteLine("Generating map...");

SKBitmap noiseMap = Generator.GenerateNoise(1280, 720, FastNoise.NoiseType.PerlinFractal, 0.002f, 6);

IOUtils.SaveSKBitmapLocally(Directory.GetCurrentDirectory() + "/noise.png", noiseMap);

Console.WriteLine("Map generated and saved.");
