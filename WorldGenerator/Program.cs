using System.Drawing;
using SkiaSharp;
using WorldGenerator.Core;
using WorldGenerator.Utils;

Console.WriteLine("Generating map...");

SKBitmap simplexNoiseMap = Generator.GenerateOpenSimplexNoise(32, 32);
SKBitmap randomNoiseMap = Generator.GenerateSimpleNoise(32, 32);
SKBitmap perlinNoiseMap = Generator.GeneratePerlinNoise(1024, 1024);

IOUtils.SaveSKBitmapLocally("open simplex", simplexNoiseMap);
IOUtils.SaveSKBitmapLocally("simple", randomNoiseMap);
IOUtils.SaveSKBitmapLocally("perlin", perlinNoiseMap);

Console.WriteLine("Map generated and saved.");
