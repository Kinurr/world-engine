using System.Diagnostics;
using WorldEngine;
using WorldEngine.Core;
using WorldEngine.Layers;
using WorldEngine.Rules;
using WorldEngine.Utils;

// This class serves only to test the World Engine library.

// Library usage.
Console.WriteLine("Test generating world...");

var ruleset = new Ruleset("Da Rules", 1000, 0.0025f);

var layers = new List<Layer>();

var landProfile = new NoiseProfile(FastNoiseLite.NoiseType.Value, 0.005f, FastNoiseLite.FractalType.FBm, 6, 0.4f, 2);
var heightProfile = new NoiseProfile(FastNoiseLite.NoiseType.Value, 0.005f, FastNoiseLite.FractalType.FBm, 6, 0.4f, 2);
var precipitationProfile = new NoiseProfile(FastNoiseLite.NoiseType.Perlin, 0.005f, FastNoiseLite.FractalType.None, 6, 0.4f, 2);
var temperatureProfile= new NoiseProfile(FastNoiseLite.NoiseType.Perlin, 0.005f, FastNoiseLite.FractalType.None, 6, 0.4f, 2);

var seed = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

layers.Add(new Layer("Land", 1, LayerTypes.Landmass, seed, landProfile));
layers.Add(new Layer("Height", 2, LayerTypes.Altitude, seed, heightProfile));
layers.Add(new Layer("Precipitation", 3, LayerTypes.Precipitation, seed, precipitationProfile));
layers.Add(new Layer("Temperature", 4, LayerTypes.Temperature, seed, temperatureProfile));

var generator = new Generator(ruleset, layers);

var world = generator.CreateWorld();

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();

await WorldEngine.Debug.Tools.SaveWorldChunkAsPng(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "map.png",
    world, 0, 0, 1920, 1080);

stopwatch.Stop();

TimeSpan ts = stopwatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);

Console.WriteLine("Elapsed Time is {0}", elapsedTime);