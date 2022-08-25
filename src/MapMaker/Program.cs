using System.Diagnostics;
using WorldEngine;
using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Utils;

// This class serves only to test the World Engine library.

// Library usage.
Console.WriteLine("Test generating world...");

var ruleset = new Ruleset("Da Rules", 1000, 0.0025f, 1000);

var layers = new List<Layer>();

layers.Add(new Layer("Land", 1, LayerTypes.Landmass, FastNoise.NoiseType.PerlinFractal, 1000, .0025f, 8));
layers.Add(new Layer("Height", 2, LayerTypes.Altitude, FastNoise.NoiseType.PerlinFractal, 1000, .0003f, 12));

var generator = new Generator(ruleset, layers);

var world = generator.CreateWorld();

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();

WorldEngine.Debug.Tools.SaveWorldChunkAsPng(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "map.png",
    world, 0, 0, 1920, 1080);

stopwatch.Stop();

TimeSpan ts = stopwatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);

Console.WriteLine("Elapsed Time is {0}", elapsedTime);