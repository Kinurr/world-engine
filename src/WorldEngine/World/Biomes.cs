namespace WorldEngine.World;

public static class Biomes
{
    public static BiomeTypes GetBiome(float landValue, int altitude, int precipitation, int temperature)
    {
        if (altitude is >= 450 and < 550 )
            return BiomeTypes.MountainBase;
        if (altitude is >= 550 and < 750 )
            return BiomeTypes.Mountain;
        if (altitude is >= 750 and < 900)
            return BiomeTypes.MountainTop;
        if (altitude >= 900)
            return BiomeTypes.Summit;
        

        if (temperature <= 0)
        {
            return BiomeTypes.Tundra;
        } 
        else if (temperature is > 0 and <= 12)
        {
            if (precipitation < 200)
            {
                if (Math.Abs(landValue) < 0.05f)
                    return BiomeTypes.Beach;
                
                return BiomeTypes.Grassland;
            }
            
            return BiomeTypes.Forest;
        }
        else if (temperature is > 12 and <= 17)
        {

            if (precipitation is > 200 and <= 300)
                return BiomeTypes.Forest;

            if (precipitation > 300)
                return BiomeTypes.TropicalForest;
                
            if (Math.Abs(landValue) < 0.05f)
                return BiomeTypes.Beach;
                
            return BiomeTypes.Grassland;
            
        }
        else
        {
            if (precipitation < 200)
                return BiomeTypes.Desert;
            else
                return BiomeTypes.Savanna;
        }
    }
}