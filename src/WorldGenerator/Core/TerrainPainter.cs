using SkiaSharp;

namespace WorldGenerator.Core;

public static class TerrainPainter
{
    private static SKColor _deepWaterColor = SKColors.DarkBlue;

    private static SKColor _shallowWaterColor = SKColors.Blue;

    private static SKColor _land = SKColors.Bisque;

	private static SKColor _shallowLand = SKColors.Beige;

	private static SKColor _mediumLand = SKColors.Green;

	private static SKColor _highLand = SKColors.SaddleBrown;
    
    private static SKBitmap? _coloredMap;

    public static SKBitmap? PaintTerrain(SKBitmap landMap, SKBitmap heightMap)
    {
        _coloredMap = new SKBitmap(landMap.Width, landMap.Height);
        
        for (var x = 0; x < landMap.Width; x++)
        {
            for (var y = 0; y < landMap.Height; y++)
            {
                _coloredMap.SetPixel(x, y,
                    landMap.GetPixel(x, y).Blue < 90
                        ? new SKColor(0, 0, landMap.GetPixel(x, y).Blue)
                        : new SKColor(heightMap.GetPixel(x, y).Red, 0, 0));
            }
        }
        return _coloredMap;
    }
}