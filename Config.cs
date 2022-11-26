using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BlackOut
{
    public class Config : IConfig
    {
        [Description("↓Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;
        [Description("↓Indicates whether the subtitles for cassie will be shown or not")]
        public bool Subtitles { get; set; } = true;
        [Description("↓Specifies which cassie will be used when the light is turned off")]
        public string CassieLight { get; set; } = "jam_70_5 warning .g5 warning ChaosInsurgency Hacked Complex jam_70_5 system . . Return system";
        [Description("↓Indicates whether cassie will be played when the lights are turned off. (false = will not. true = will be)")]
        public bool offCassie { get; set; } = true;

        [Description("Specifies in which seconds a random time will be selected\n" +
            "↓Minimum value")]
        public int MinBlackoutStartTime { get; set; } = 60;
        [Description("↓Maximum value")]
        public int MaxBlackoutStartTime { get; set; } = 300;

        [Description("Indicates how many seconds the light is turned off\n" +
            "↓Minimum value")]
        public int MinBlackoutTime { get; set; } = 30;
        [Description("↓Maximum value")]
        public int MaxBlackoutTime { get; set; } = 30;

    }
}
