namespace BlackOut
{
    using Exiled.Events.EventArgs;
    using MEC;

    using System.Collections.Generic;

    using static API;

    /// <summary>
    /// <inheritdoc cref="Exiled.Events.Handlers.Server"/>
    /// </summary>
    internal sealed class ServerHandler
    {
        private readonly Plugin _plugin;
        private CoroutineHandle _blackoutHandle;

        internal ServerHandler(Plugin plugin) => _plugin = plugin;

        /// <summary>
        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        /// </summary>
        internal void OnRoundStarted() => Timing.CallDelayed(UnityEngine.Random.Range(
                _plugin.Config.MinInitialBlackoutDelay > -1.0 ? _plugin.Config.MinInitialBlackoutDelay : _plugin.Config.MinOngoingBlackoutDelay,
                _plugin.Config.MaxInitialBlackoutDelay > -1.0 ? _plugin.Config.MaxInitialBlackoutDelay : _plugin.Config.MaxOngoingBlackoutDelay),
                () => _blackoutHandle = Timing.RunCoroutine(DoBlackout()));

        /// <summary>
        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundEnded"/>
        /// </summary>
        internal void OnRoundEnded(RoundEndedEventArgs _) => Timing.KillCoroutines(_blackoutHandle);

        private IEnumerator<float> DoBlackout()
        {
            yield return UnityEngine.Random.Range(
                _plugin.Config.MinInitialBlackoutDelay > -1.0 ? _plugin.Config.MinInitialBlackoutDelay : _plugin.Config.MinOngoingBlackoutDelay,
                _plugin.Config.MaxInitialBlackoutDelay > -1.0 ? _plugin.Config.MaxInitialBlackoutDelay : _plugin.Config.MaxOngoingBlackoutDelay);

            while (!API.IsBlackoutEnabled)
                yield return Timing.WaitForSeconds(1.0f);

            ForceBlackout();

            for (; ; )
            {
                yield return UnityEngine.Random.Range(_plugin.Config.MinOngoingBlackoutDelay, _plugin.Config.MaxOngoingBlackoutDelay);

                while (!API.IsBlackoutEnabled)
                    yield return Timing.WaitForSeconds(1.0f);

                ForceBlackout();
            }
        }
    }
}
