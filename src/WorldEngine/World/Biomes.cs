namespace WorldEngine.World;

public static class Biomes
{
    public static BiomeTypes GetBiome(int altitude, int precipitation, int temperature)
    {
        // TODO: Make all of this costumizeable to users.

        if (temperature > 5)
        {
            if (altitude is >= 1700 and < 1850)
                return BiomeTypes.MountainBase;
            if (altitude is >= 1850 and < 1900)
                return BiomeTypes.Mountain;
            if (altitude is >= 1900 and < 1950)
                return BiomeTypes.MountainTop;
            if (altitude >= 1950)
                return BiomeTypes.Summit;

        }

        if (temperature <= 5)
        {
            return precipitation > 200 ? BiomeTypes.ArcticForest : BiomeTypes.Tundra;
        }
        else if (temperature is > 5 and <= 12)
        {
            if (precipitation < 200)
            {
                if (altitude < 1250)
                    return BiomeTypes.Beach;

                return BiomeTypes.Grassland;
            }

            return BiomeTypes.Forest;
        }
        else if (temperature is > 12 and <= 25)
        {

            if (precipitation is > 200 and <= 300)
                return BiomeTypes.Forest;

            if (precipitation > 300)
                return BiomeTypes.TropicalForest;

            if (altitude < 1250)
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