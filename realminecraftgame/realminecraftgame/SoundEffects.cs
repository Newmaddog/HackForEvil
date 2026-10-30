using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace realminecraftgame
{
    internal class SoundEffects
    {
        public static Dictionary<string, Sound> soundEffects = new Dictionary<string, Sound>
        {
            {"BombFallingSound", Raylib.LoadSound("Sounds/FallingBombSoundEffect.mp3") },
            {"VillagerDeathSound", Raylib.LoadSound("Sounds/VillagerDeathSoundEffect.mp3") },
        };

        public static bool BombSoundEffect()
        {
            Raylib.InitAudioDevice(); // Initiate raylib's audio system

            Sound fallingBombSound = soundEffects["BombFallingSound"];

            Raylib.SetSoundVolume(fallingBombSound, 1f);

            Raylib.PlaySound(fallingBombSound);

            if (!Raylib.IsSoundPlaying(fallingBombSound))
            {
                Raylib.UnloadSound(fallingBombSound);
            }

            return true;
        }

        public static bool VillagerDeathSoundEffect()
        {
            //Raylib.InitAudioDevice(); // Initiate raylib's audio system

            Sound villagerDeathSound = soundEffects["VillagerDeathSound"];

            Raylib.SetSoundVolume(villagerDeathSound, 7f);

            Raylib.PlaySound(villagerDeathSound);

            if (!Raylib.IsSoundPlaying(villagerDeathSound))
            {
                Raylib.UnloadSound(villagerDeathSound);
            }

            return true;
        }

        public static bool IsSoundPlaying()
        {
            foreach (Sound sound in soundEffects.Values)
            {
                if (Raylib.IsSoundPlaying(sound))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
