using Microsoft.AspNetCore.Components;
using ScheduleMixer.Shared.Core.Objects;

namespace ScheduleMixer.Shared.Pages;

public partial class EffectsEditor : ComponentBase
{
    string? SelectedEffectName { get; set; }
    Effect? SelectedEffect { get; set; }
    EffectType SelectedReplacementKey { get; set; }
    EffectType SelectedReplacementValue { get; set; }
}