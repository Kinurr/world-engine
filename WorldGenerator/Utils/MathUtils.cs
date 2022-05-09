namespace WorldGenerator.Utils;

public class MathUtils
{
    public static float Clamp(float min, float max, float value)
    {
        if (value < min)
            value = min;
        if (value > max)
            value = max;
        return value;
    }
    
    public static double Clamp(double min, double max, double value)
    {
        if (value < min)
            value = min;
        if (value > max)
            value = max;
        return value;
    }

    public static double Map(double value, double originalMinimum, double originalMaximum, double targetMinimum, double targetMaximum)
    {
        return targetMinimum + (value-originalMinimum)*(targetMaximum-targetMinimum)/(originalMaximum-originalMinimum);

    }
}
