namespace ScheduleMixer.Core.Objects;

public class Base
{
    public string Name { get; set; } = String.Empty;
    public List<Effect> Effects { get; set; } = [];
    public double IndividualCost { get; set; }
}