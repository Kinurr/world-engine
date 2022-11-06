namespace WorldEngine.Core.World;

public class WorldParameter{

    public string Name { get; }

    public float Value { get; }

    public WorldParameter(string name, float value)
    {
        this.Name = name;
        this.Value = value;
    }
}