namespace ScheduleMixer.Core.Objects;

public class Effect(EffectType type)
{
    public string Name { get; set; } = String.Empty;
    public EffectType Type { get; set; } = type;

    public Dictionary<EffectType, EffectType> Replacements
    {
        get
        {
            return File.ReadAllLines($"./Effects/{Type}.ef")
                .Select(line => line.Split('='))
                .ToDictionary(
                    parts => Enum.Parse<EffectType>(parts[0]),
                    parts => Enum.Parse<EffectType>(parts[1])
                );
        }
        set
        {
            File.WriteAllLines($"./Effects/{Type}.ef",
                value.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}