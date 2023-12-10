using UnityEngine.Networking;
using UnityEngine;
using System.IO;
using BepInEx;
using System.Linq;
using System.Collections.Generic;

namespace CowboySwaps
{
    public static class AudioPatcher
    {
        public static AudioClip BepInLoadClip(string itemName)
        {
            List<string> list = Directory.GetDirectories(Paths.PluginPath, "CowboySwapsSFX", SearchOption.AllDirectories).ToList();
            foreach (string item in list)
            {
                string newPath = item + "\\" + itemName;
                if (File.Exists(newPath))
                    return LoadClip(newPath);
            }
            return null;
        }

        public static AudioClip LoadClip(string path)
        {
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + path, AudioType.WAV))
            {
                www.SendWebRequest();

                while (!www.isDone);

                if (www.result == UnityWebRequest.Result.Success)
                    return DownloadHandlerAudioClip.GetContent(www);
                else
                    CowboySwaps.CustomLogger.LogError($"Failed to load WAV audio clip from {path}. Error: {www.error}");
            }
            return null;
        }
    }
}