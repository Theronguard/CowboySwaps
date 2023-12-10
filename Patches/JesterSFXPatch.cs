using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CowboySwaps
{
    [HarmonyPatch(typeof(JesterAI))]
    public class JesterSFXPatch : BaseUnityPlugin
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void PatchJesterSFX(JesterAI __instance)
        {
            __instance.popGoesTheWeaselTheme = AudioPatcher.BepInLoadClip(CowboySwaps.files["JesterWindup"]);
            CowboySwaps.CustomLogger.LogWarning("Daniel Jester Patched!");
        }
    }

    
}
