using System.Collections.Concurrent;
using ScheduleMixer.Shared.Core.Objects;
using Effect = ScheduleMixer.Shared.Core.Objects.Effect;

namespace ScheduleMixer.Shared.Core;

public class Data
{
    public static bool IsReady => Effects.Count > 0;
    private static ConcurrentDictionary<EffectType, Effect>? _effects = null;
    public static ConcurrentDictionary<EffectType, Effect> Effects
    {
        get
        {
            if (_effects == null)
            {
                _effects = new ConcurrentDictionary<EffectType, Effect>();
                Enum.GetValues(typeof(EffectType)).Cast<EffectType>().ToList().ForEach(x => _effects.TryAdd(x, new Effect(x)));
            }
            return _effects;
        }
        set => _effects = value;
    }
}