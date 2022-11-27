namespace BlackOut
{
    using Exiled.API.Enums;
    using Exiled.API.Features;

    using MEC;

    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The API interface to handle <see cref="BlackOut"/> from external applications.
    /// </summary>
    public static class API
    {
        /// <summary>
        /// Gets or sets a value indicating whether the blackout is enabled.
        /// </summary>
        public static bool IsBlackoutEnabled { get; set; } = true;

        /// <summary>
        /// Gets the <see cref="Plugin"/>'s config.
        /// </summary>
        internal static Config Config => Plugin.Instance.Config;

        /// <summary>
        /// Forces the blackout to start.
        /// </summary>
        public static void ForceBlackout()
        {
            ForceBlackout(UnityEngine.Random.Range(Config.MinOngoingBlackoutTime, Config.MaxOngoingBlackoutTime),
                Config.AffectedZones, Config.ShouldPlayCassieAnnouncement,
                Config.BlackoutAnnouncementDelay, Config.BlackoutAnnouncement, Config.Subtitles);
        }

        /// <summary>
        /// Forces the blackout to start.
        /// </summary>
        /// <param name="duration">The duration of the blackout.</param>
        /// <param name="zoneTypes">The affected zones.</param>
        public static void ForceBlackout(float duration = default, IEnumerable<ZoneType> zoneTypes = default)
        {
            ForceBlackout(duration > 0.0f ? duration : UnityEngine.Random.Range(Config.MinOngoingBlackoutTime, Config.MaxOngoingBlackoutTime),
                !zoneTypes.Any() ? Config.AffectedZones : zoneTypes, Config.ShouldPlayCassieAnnouncement,
                Config.BlackoutAnnouncementDelay, Config.BlackoutAnnouncement, Config.Subtitles);
        }

        /// <summary>
        /// Turns off all the lights in the facility, 
        /// </summary>
        /// <param name="duration">The duration of the blackout.</param>
        /// <param name="zoneTypes">The affected zones.</param>
        /// <param name="playCassieMessage">A value indicating whether the C.A.S.S.I.E should play the annoucement.</param>
        /// <param name="cassieMessageDelay">The amount of time to await before announcing the blackout.</param>
        /// <param name="cassieMessage">The announcement to be played when the lights will be turned off.</param>
        /// <param name="showSubtitles">A value indicating whether subtitles should be shown.</param>
        public static void ForceBlackout(
            float duration,
            IEnumerable<ZoneType> zoneTypes,
            bool playCassieMessage = true,
            float cassieMessageDelay = 0.0f,
            string cassieMessage = "",
            bool showSubtitles = true)
        {
            Map.TurnOffAllLights(duration, zoneTypes);

            if (playCassieMessage)
                Timing.CallDelayed(cassieMessageDelay, () => Cassie.Message(cassieMessage, isSubtitles: showSubtitles));
        }
    }
}
