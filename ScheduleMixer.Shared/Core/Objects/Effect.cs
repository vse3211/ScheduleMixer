namespace ScheduleMixer.Shared.Core.Objects;

public class Effect(EffectType type)
{
    private string? _name = null;

    public string Name
    {
        get { return _name ??= Type.ToString(); }
        set => _name = value;
    }
    public EffectType Type { get; } = type;

    public double CostMultiplier
    {
        get
        {
            Core.Tools.CheckDirectory($"Effects/{Type}");
            if (!File.Exists(Tools.GetPathFromBaseDirectory($"Effects/{Type}/CostMultiplier.txt")))
            {
                
            }
            return Double.Parse(File.ReadAllText(Tools.GetPathFromBaseDirectory($"Effects/{Type}/CostMultiplier.txt")));
        }
    }

    public Dictionary<EffectType, EffectType> Replacements
    {
        get
        {
            Core.Tools.CheckDirectory($"Effects/{Type}");
            if (!File.Exists(Tools.GetPathFromBaseDirectory($"Effects/{Type}/Replacements.txt")))
            {
                File.WriteAllText(Tools.GetPathFromBaseDirectory($"Effects/{Type}/Replacements.txt"), "");
                return []; // TODO
            }
            return File.ReadAllLines(Tools.GetPathFromBaseDirectory($"Effects/{Type}/Replacements.txt"))
                .Select(line => line.Split('='))
                .ToDictionary(
                    parts => Enum.Parse<EffectType>(parts[0]),
                    parts => Enum.Parse<EffectType>(parts[1])
                );
        }
        set
        {
            Core.Tools.CheckDirectory($"Effects/{Type}");
            File.WriteAllLines(Tools.GetPathFromBaseDirectory($"Effects/{Type}/Replacements.txt"),
                value.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}