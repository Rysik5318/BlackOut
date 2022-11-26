using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

namespace BlackOut
{
    public class EventHandlers
    {
        public Plugin plugin;
        internal CoroutineHandle BlackoutCoroutine;
        private readonly IEnumerable<ZoneType> zoneTypes = new List<ZoneType>() { ZoneType.Entrance, ZoneType.HeavyContainment, ZoneType.LightContainment };

        public EventHandlers(Plugin _plugin)
        {
            plugin = _plugin;
        }

        private bool BlackoutON = false;
        internal void OnRoundStarted() => BlackoutCoroutine = Timing.RunCoroutine(DoBlackout());
        public IEnumerator<float> DoBlackout()
        {
            for (; ; )
            {
                if (Round.IsStarted && !BlackoutON)
                {
                    Map.TurnOffAllLights(plugin.Rand.Next(plugin.Config.MinBlackoutTime, plugin.Config.MaxBlackoutTime), zoneTypes);
                    if (plugin.Config.offCassie)
                    {
                        Timing.CallDelayed(3f, () => Cassie.Message(plugin.Config.CassieLight, false, true, plugin.Config.Subtitles));
                    }
                    BlackoutON = true;
                    yield return Timing.WaitForSeconds(plugin.Rand.Next(plugin.Config.MinBlackoutStartTime, plugin.Config.MaxBlackoutStartTime));
                }
            }
        }
    }
}
