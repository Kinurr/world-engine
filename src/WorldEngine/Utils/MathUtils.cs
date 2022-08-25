namespace WorldEngine.Utils;

public static class MathUtils
{
    public static double Map(double value, double originalMinimum, double originalMaximum, double targetMinimum, double targetMaximum) =>
        targetMinimum + (value-originalMinimum)*(targetMaximum-targetMinimum)/(originalMaximum-originalMinimum);
}
