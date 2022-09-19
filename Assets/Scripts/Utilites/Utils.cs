using System.Linq;
using System.Runtime.CompilerServices;

namespace Utilites
{
    public static class Utils
    {
        public static string MusicVolumeKey = "MusicVolume";
        public static string EffectVolumeKey = "EffectsVolume";
        public static string WinSound = "Win";
        public static string LoseSound = "Lose";
        public static string SliderSound = "SliderSound";
        public static string ButtonSound = "ButtonSound";

        public static string StepsSound = "Steps";
        public static string AttackSound = "Attack";
        public static string GoldSound = "Gold";
        
        
        
        public static bool HasStringInArray(string comparable, string[] array)
        {
            if (array.Length == 0) return true;
            return array.Any(elem => comparable == elem);
        }
    }
}