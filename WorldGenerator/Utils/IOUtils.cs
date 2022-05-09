using System.Drawing;

namespace WorldGenerator.Utils;

public static class IOUtils
{
    /// <summary>
    /// Saves a bitmap locally
    /// </summary>
    /// <param name="name">The name of the bitmap to save</param>
    /// <param name="image">The bitmap to store locally</param>
    public static void SaveBitmapLocally(string name, Image? image)
    {
        image.Save(Environment.CurrentDirectory + $"/{name}.bmp");
    }
    
}
