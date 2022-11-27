namespace BlackOut
{
    using Exiled.API.Features;

    using System;

    /// <summary>
    /// <inheritdoc cref="Plugin{TConfig}"/>
    /// </summary>
    internal sealed class Plugin : Plugin<Config>
    {
        private ServerHandler _serverHandler;

        /// <summary>
        /// <inheritdoc cref="Exiled.API.Interfaces.IPlugin{TConfig}.Prefix"/>
        /// </summary>
        public override string Prefix => "BlackOut";

        /// <summary>
        /// <inheritdoc cref="Exiled.API.Interfaces.IPlugin{TConfig}.Name"/>
        /// </summary>
        public override string Name => "BlackOut";

        /// <summary>
        /// <inheritdoc cref="Exiled.API.Interfaces.IPlugin{TConfig}.Author"/>
        /// </summary>
        public override string Author => "Rysik5318";

        /// <summary>
        /// <inheritdoc cref="Exiled.API.Interfaces.IPlugin{TConfig}.Version"/>
        /// </summary>
        public override Version Version { get; } = new Version(2, 0, 0);

        /// <summary>
        /// The <see cref="Plugin"/> instance.
        /// </summary>
        internal static Plugin Instance { get; private set; }

        /// <summary>
        /// <inheritdoc cref="Exiled.API.Interfaces.IPlugin{TConfig}.OnEnabled"/>
        /// </summary>
        public override void OnEnabled()
        {
            Instance = this;

            SubscribeEvents();

            base.OnEnabled();
        }

        /// <summary>
        /// <inheritdoc cref="Exiled.API.Interfaces.IPlugin{TConfig}.OnDisabled"/>
        /// </summary>
        public override void OnDisabled()
        {
            UnsubscribeEvents();

            Instance = null;

            base.OnDisabled();
        }

        private void SubscribeEvents()
        {
            _serverHandler = new(this);

            Exiled.Events.Handlers.Server.RoundStarted += _serverHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += _serverHandler.OnRoundEnded;
        }

        private void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= _serverHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= _serverHandler.OnRoundEnded;

            _serverHandler = null;
        }
    }
}
