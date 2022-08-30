using System.Linq;

namespace Utilites
{
    public static class Utils
    {
        public static string MusicVolumeKey = "MusicVolume";
        public static string EffectVolumeKey = "EffectsVolume";
        
        
        
        public static bool HasStringInArray(string comparable, string[] array)
        {
            return array.Any(elem => comparable == elem);
        }
    }
}