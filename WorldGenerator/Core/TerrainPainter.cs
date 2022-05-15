using SkiaSharp;

namespace WorldGenerator.Core;

public class TerrainPainter
{
    private static SKColor deepWaterColor = SKColors.DarkBlue;
    
    private static SKColor shallowWaterColor = SKColors.Blue;

    private static SKColor shoreColor = SKColors.Beige;
    
    private static SKColor grasslandsColor = SKColors.LightGreen;
    
    private static SKColor forestColor = SKColors.ForestGreen;
    
    private static SKColor mountainColor = SKColors.DarkGreen;

    private static SKBitmap _coloredMap;

    public static SKBitmap PaintTerrain(SKBitmap noiseMap)
    {
        _coloredMap = new SKBitmap(noiseMap.Width, noiseMap.Height);
        
        for (int x = 0; x < noiseMap.Width; x++)
        {
            for (int y = 0; y < noiseMap.Height; y++)
            {
                if (noiseMap.GetPixel(x, y).Blue > 128)
                {
                    if (noiseMap.GetPixel(x, y).Blue < 140)
                        _coloredMap.SetPixel(x, y, shallowWaterColor);
                    else
                        _coloredMap.SetPixel(x, y, deepWaterColor);

                }
                else
                {
                    if (noiseMap.GetPixel(x, y).Blue > 110)
                        _coloredMap.SetPixel(x, y, shoreColor);
                    else if (noiseMap.GetPixel(x, y).Blue > 90)
                        _coloredMap.SetPixel(x, y, grasslandsColor);
                    else if (noiseMap.GetPixel(x, y).Blue > 50)
                        _coloredMap.SetPixel(x, y, forestColor);
                    else 
                        _coloredMap.SetPixel(x, y, mountainColor);
                }
            }
        }
        return _coloredMap;
    }
}