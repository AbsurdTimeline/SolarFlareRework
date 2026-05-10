using RimWorld;
using HarmonyLib;

namespace SolarFlareRework.Patch
{
    [HarmonyPatch(typeof(PowerNet))]
    [HarmonyPatch("CurrentEnergyGainRate")]
    public static class PowerNet_CurrentEnergyGainRate_Patch
    {
        /// <summary>
        /// Reduce power generation during solar flares.
        /// </summary>
        [HarmonyPrefix]
        public static bool ReducePowerGain(PowerNet __instance, ref float __result)
        {
            if (__instance.Map.gameConditionManager.ElectricityDisabled(__instance.Map))
            {
                float total = 0f;
                for (int i = 0; i < __instance.powerComps.Count; i++)
                {
                    if (__instance.powerComps[i].PowerOn)
                    {
                        float energyOutput = __instance.powerComps[i].EnergyOutputPerTick;
                        if (energyOutput > 0f)
                        {
                            total += energyOutput * SolarFlareReworkSettings.electricityMultiplier;
                        }
                        else
                        {
                            total += energyOutput;
                        }
                    }
                }
                __result = total;
                return false;
            }
            return true;
        }
    }
}
