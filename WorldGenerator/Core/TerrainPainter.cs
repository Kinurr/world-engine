using SkiaSharp;

namespace WorldGenerator.Core;

public class TerrainPainter
{
    private static SKColor deepWaterColor = SKColors.DarkBlue;
    
    private static SKColor shallowWaterColor = SKColors.Blue;

    private static SKColor land = SKColors.Bisque;

	private static SKColor shallowLand = SKColors.Beige;

	private static SKColor mediumLand = SKColors.Green;

	private static SKColor highLand = SKColors.SaddleBrown;
    
    private static SKBitmap _coloredMap;

    public static SKBitmap PaintTerrain(SKBitmap landMap, SKBitmap heightMap)
    {
        _coloredMap = new SKBitmap(landMap.Width, landMap.Height);
        
        for (int x = 0; x < landMap.Width; x++)
        {
            for (int y = 0; y < landMap.Height; y++)
            {
                if (landMap.GetPixel(x, y).Blue < 128)
                {
                    if (landMap.GetPixel(x, y).Blue > 105)
                        _coloredMap.SetPixel(x, y, shallowWaterColor);
                    else
                        _coloredMap.SetPixel(x, y, deepWaterColor);

                }
                else
                {
					if(heightMap.GetPixel(x, y).Blue < 85)
                    	_coloredMap.SetPixel(x, y, shallowLand);
					else if(heightMap.GetPixel(x, y).Blue < 170)
                    	_coloredMap.SetPixel(x, y, mediumLand);
					else
                    	_coloredMap.SetPixel(x, y, highLand);
                }
            }
        }
        return _coloredMap;
    }
}