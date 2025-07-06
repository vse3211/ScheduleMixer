namespace ScheduleMixer.Shared.Core.Objects;

// Base object for products && ingredients
public class Base
{
    public string Name { get; set; } = String.Empty;
    public List<Effect> Effects { get; set; } = [];
    public double IndividualCost { get; set; }
}