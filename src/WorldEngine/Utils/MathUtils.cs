namespace WorldEngine.Utils;

public static class MathUtils
{
    // TODO: This function is utter trash and barely works, make it work as it should.
    public static float Remap (float value, float originalMinimum, float originalMaximum, float targetMinimum, float targetMaximum) {
        var newValue = (value - originalMinimum) / (originalMaximum - originalMinimum) * (targetMaximum - targetMinimum) + targetMinimum;

        if (newValue > targetMaximum)
            newValue = targetMaximum;

        if (newValue < targetMinimum)
            newValue = targetMinimum;
        
        return newValue;
    }

}
