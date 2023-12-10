using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity;
using UnityEngine.Audio;

namespace CowboySwaps
{
    [BepInPlugin(modGUID,modName,modVersion)]
    public class CowboySwaps : BaseUnityPlugin
    {
        private const string modGUID = "Theronguard.CowboySwaps";
        private const string modName = "CowboySwaps";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static ManualLogSource CustomLogger;

        //file id + file name
        public static Dictionary<string,string> files = new Dictionary<string,string>();

        void Awake()
        {
            files.Add("HornClose","ggn1.wav");
            files.Add("HornFar", "ggn2.wav");
            files.Add("JesterWindup", "jst.wav");

            CustomLogger = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            CustomLogger.LogInfo("Daniel works!");
            harmony.PatchAll(typeof(CowboySwaps));
            harmony.PatchAll(typeof(HornSourcePatch));
            harmony.PatchAll(typeof(JesterSFXPatch));
        }
    }
}
