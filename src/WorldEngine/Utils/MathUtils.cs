namespace WorldEngine.Utils;

public static class MathUtils
{
    public static double Clamp(double min, double max, double value)
    {
        if (value < min)
            value = min;
        if (value > max)
            value = max;
        return value;
    }

    public static double Map(double value, double originalMinimum, double originalMaximum, double targetMinimum, double targetMaximum) =>
        targetMinimum + (value-originalMinimum)*(targetMaximum-targetMinimum)/(originalMaximum-originalMinimum);
}
