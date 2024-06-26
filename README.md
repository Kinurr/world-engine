# World Engine

A C# library that generates tile-based fictional worlds. 

## What's this for?

The purpose of this project is to provide developers with a practical tool to procedurally generate interesting worlds which can also be extended and customized. It's meant primarily to be used in games and world-building tools but it can be changed to fit other needs.

## Examples

> **Please note that the examples shown are generated by a debug function meant to quickly visualize a map. Every implementation will have different ways of visualizing maps.**

<details>
  <summary>Example 1 - Endless Earth-like</summary>
  
  ![map](https://user-images.githubusercontent.com/51026793/197367446-24100817-26d9-467a-9d76-91c5c1d1f4b6.png)
</details>

<details>
  <summary>Example 2 - Endless Fractal</summary>
  
  ![map](https://user-images.githubusercontent.com/51026793/197367479-8998cb1b-421b-4dd8-bdfa-87e3c5f07b47.png)
</details>

<details>
  <summary>Example 3 - Endless Fractal (Lower Frequency)</summary>
  
  ![map](https://user-images.githubusercontent.com/51026793/197367607-b559d134-9626-488a-b275-34e23925e3fa.png)
</details>


## Current Features
- Procedural landmass generation;
- Saving map to png;
- Build as library;
- Biomes;
- Different noise maps for altitude, humidity, temperature...;

## To Be Implemented
- Selective coastline smoothing;
- Scripted formations (rivers, volcanos, icecaps...);
- Spawnrates for objects/entities in tiles;
- Save and restore world state;

### License
Distributed under the Unlicense License. See `LICENSE` for more information.

### Built With
* [dotnet](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [FastNoiseLite](https://github.com/Auburn/FastNoiseLite)

### Contacts
Project Link: [https://github.com/Kinurr/world-engine](https://github.com/Kinurr/world-engine)

### Acknowledgments
* [Best-README-Template](https://github.com/othneildrew/Best-README-Template)
* [Making maps with noise functions](https://www.redblobgames.com/maps/terrain-from-noise/)
* [Jordan Peck](https://jordanpeck.me/)
