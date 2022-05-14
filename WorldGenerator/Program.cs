using SkiaSharp;
using WorldGenerator.Core;
using WorldGenerator.Utils;

Console.WriteLine("Generating map...");

SKBitmap perlinNoiseMap = Generator.GeneratePerlinNoise(1024, 1024);

IOUtils.SaveSKBitmapLocally("perlin", perlinNoiseMap);

Console.WriteLine("Map generated and saved.");
