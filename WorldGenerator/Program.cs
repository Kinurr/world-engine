using System.Drawing;
using WorldGenerator.Core;
using WorldGenerator.Utils;

Console.WriteLine("Generating map...");

Bitmap? simplexNoiseMap = Generator.GenerateOpenSimplexNoise(32, 32);
Bitmap? randomNoiseMap = Generator.GenerateSimpleNoise(32, 32);
Bitmap? perlinNoiseMap = Generator.GeneratePerlinNoise(1024, 1024);

IOUtils.SaveBitmapLocally("open simplex", simplexNoiseMap);
IOUtils.SaveBitmapLocally("simple", randomNoiseMap);
IOUtils.SaveBitmapLocally("perlin", perlinNoiseMap);

Console.WriteLine("Map generated and saved.");
