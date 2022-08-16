using System.Diagnostics;
using WorldGenerator;
using WorldGenerator.Layers;
using WorldGenerator.Rules;

// Library usage.
Console.WriteLine("Test generating world...");

var ruleset = new Ruleset("Da Rules", (int)DateTime.Now.Ticks);

var layers = new List<Layer>();

layers.Add(new Layer("Water", 1, ruleset, LayerTypes.Water));
layers.Add(new Layer("Altitude", 2, ruleset, LayerTypes.Altitude));

var generator = new Generator(ruleset, layers);

var world = generator.CreateWorld();

Stopwatch stopwatch = new Stopwatch();
 
stopwatch.Start();

WorldGenerator.Debug.Tools.SaveWorldAsPng(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "map.png", world, 0, 0, 1920, 1080);

stopwatch.Stop();

TimeSpan ts = stopwatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);

Console.WriteLine("Elapsed Time is {0}", elapsedTime);