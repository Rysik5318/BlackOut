namespace BlackOut
{
    using Exiled.API.Enums;
    using Exiled.API.Interfaces;

    using System.ComponentModel;

    internal sealed class Config : IConfig
    {
        [Description("Gets or sets a value indicating whether the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Gets or sets a value indicating whether C.A.S.S.I.E subtitles should be shown.")]
        public bool Subtitles { get; set; } = true;

        [Description("Gets or sets the annoucement C.A.S.S.I.E will play when the lights will be turned off.")]
        public string BlackoutAnnouncement { get; set; } = "jam_70_5 warning .g5 warning ChaosInsurgency Hacked Complex jam_70_5 system . . Return system";

        [Description("Gets or sets the delay to await before playing the C.A.S.S.I.E message.")]
        public float BlackoutAnnouncementDelay { get; set; } = 3.0f;

        [Description("Gets or sets a value indicating whether C.A.S.S.I.E will play the message when the lights will be turned off.")]
        public bool ShouldPlayCassieAnnouncement { get; set; } = true;

        [Description("Gets or sets the minimum boundary range of time, expressed in seconds, according to which the lights will be turned off at the beginning.\n" +
            "Setting this property's value to -1 will make the plugin use the minimum ongoing delay.")]
        public float MinInitialBlackoutDelay { get; set; } = 30.0f;

        [Description("Gets or sets the maximum boundary range of time, expressed in seconds, according to which the lights will be turned off at the beginning.\n" +
            "Setting this property's value to -1 will make the plugin use the maximum ongoing delay.")]
        public float MaxInitialBlackoutDelay { get; set; } = 60.0f;

        [Description("Gets or sets the minimum boundary range of time, expressed in seconds, according to which the lights will be turned off during the game.")]
        public float MinOngoingBlackoutDelay { get; set; } = 60.0f;

        [Description("Gets or sets the maximum boundary range of time, expressed in seconds, according to which the lights will be turned off during the game.")]
        public float MaxOngoingBlackoutDelay { get; set; } = 300.0f;

        [Description("Gets or sets the minimum time, expressed in seconds, according to which the lights will remain off at the beginning.")]
        public float MinInitialBlackoutTime { get; set; } = 30.0f;

        [Description("Gets or sets the maximum time, expressed in seconds, according to which the lights will remain off at the beginning.")]
        public float MaxInitialBlackoutTime { get; set; } = 30.0f;

        [Description("Gets or sets the minimum time, expressed in seconds, according to which the lights will remain off during the game.")]
        public float MinOngoingBlackoutTime { get; set; } = 30.0f;

        [Description("Gets or sets the maximum time, expressed in seconds, according to which the lights will remain off during the game.")]
        public float MaxOngoingBlackoutTime { get; set; } = 30.0f;

        [Description("Gets or sets affected facility zones when the lights will be turned off.")]
        public ZoneType[] AffectedZones { get; set; } = { ZoneType.LightContainment, ZoneType.Entrance, ZoneType.HeavyContainment };
    }
}
