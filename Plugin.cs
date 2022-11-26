using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using MEC;
using System;

namespace BlackOut
{
    public class Plugin : Plugin<Config>
    {
        internal Random Rand;
        public override string Prefix => "BlackOut";
        public override string Name => "BlackOut";
        public override string Author => "Rysik5318";
        public override Version Version { get; } = new Version(1, 1, 8);
        private EventHandlers Handlers;

        public override void OnEnabled()
        {
            Handlers = new EventHandlers(this);
            Rand = new Random();
            Server.RoundStarted += Handlers.OnRoundStarted;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Timing.KillCoroutines(Handlers.BlackoutCoroutine);
            Server.RoundStarted -= Handlers.OnRoundStarted;
            Rand = null;
            Handlers = null;
            base.OnDisabled();
        }
    }
}
