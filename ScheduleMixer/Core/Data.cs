using System.Collections.Concurrent;
using ScheduleMixer.Core.Objects;
using Effect = ScheduleMixer.Core.Objects.Effect;

namespace ScheduleMixer.Core;

public class Data
{
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