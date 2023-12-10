using BepInEx;
using HarmonyLib;

namespace CowboySwaps
{
    [HarmonyPatch(typeof(ShipAlarmCord))]
    public class HornSourcePatch : BaseUnityPlugin
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void PatchHorn(ShipAlarmCord __instance)
        {
            __instance.hornClose.clip = AudioPatcher.BepInLoadClip(CowboySwaps.files["HornClose"]);
            __instance.hornFar.clip = AudioPatcher.BepInLoadClip(CowboySwaps.files["HornFar"]);

            CowboySwaps.CustomLogger.LogWarning("Horn Patched!");
        }
    }

    
}
