using System.Drawing;
using WorldGenerator.Core;
using WorldGenerator.Utils;

Console.WriteLine("Generating map...");

Bitmap? noiseMap = Generator.GenerateSimpleNoise(512, 512);

IOUtils.SaveBitmapLocally("noisemap", noiseMap);

Console.WriteLine("Map generated and saved.");
