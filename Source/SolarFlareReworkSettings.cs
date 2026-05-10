using UnityEngine;
using Verse;

namespace SolarFlareRework
{
    public class SolarFlareReworkSettings : ModSettings
    {
        /// <summary>
        /// Default multiplier value.
        /// </summary>
        private const float ElectricityMultiplierDefault = 0.1f;
        
        /// <summary>
        /// Current multiplier value.
        /// </summary>
        public static float electricityMultiplier;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("ElectricityMultiplierDescription".Translate(Mathf.RoundToInt(electricityMultiplier * 100f)));
            electricityMultiplier = Mathf.Round(listingStandard.Slider(electricityMultiplier, 0f, 1f) * 100f) / 100f;
            if (listingStandard.ButtonText("Reset".Translate()))
            {
                electricityMultiplier = ElectricityMultiplierDefault;
            }
            listingStandard.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref electricityMultiplier, "electricityMultiplier", ElectricityMultiplierDefault);
            base.ExposeData();
        }
    }
}
