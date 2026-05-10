using Verse;
using UnityEngine;
using HarmonyLib;

namespace SolarFlareRework
{
    public class SolarFlareRework : Mod
    {
        public SolarFlareRework(ModContentPack content) : base(content)
        {
            GetSettings<SolarFlareReworkSettings>();

            Harmony harmony = new Harmony("SolarFlareRework");
            harmony.PatchAll();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            SolarFlareReworkSettings.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "SolarFlareRework".Translate();
        }
    }
}
