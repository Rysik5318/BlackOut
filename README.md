### https://github.com/Edren-Baton-Team/BlackOut

# BlackOut
BlackOut plugin for SCP SL

He helped me rewrite it @Aer#6500

# Description: 
The plugin allows you to turn off the lights whenever you want, but only once. And you can also configure cassie or turn it off altogether.

# Default config:
```yaml
BlackOut:
# ↓Indicates whether the plugin is enabled or not
  is_enabled: true
  # ↓Indicates whether the subtitles for cassie will be shown or not
  subtitles: true
  # ↓Specifies which cassie will be used when the light is turned off
  cassie_light: jam_70_5 warning .g5 warning ChaosInsurgency Hacked Complex jam_70_5 system . . Return system
  # ↓Indicates whether cassie will be played when the lights are turned off. (false = will not. true = will be)
  off_cassie: true
  # Specifies in which seconds a random time will be selected
  # ↓Minimum value
  min_blackout_start_time: 60
  # ↓Maximum value
  max_blackout_start_time: 300
  # Indicates how many seconds the light is turned off
  # ↓Minimum value
  min_blackout_time: 30
  # ↓Maximum value
  max_blackout_time: 30
```
