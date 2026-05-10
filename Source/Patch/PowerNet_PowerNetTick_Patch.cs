using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace SolarFlareRework.Patch
{
    [HarmonyPatch(typeof(PowerNet))]
    [HarmonyPatch("PowerNetTick")]
    public static class PowerNet_PowerNetTick_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            // Ignore standard blackout effect caused by ElectricityDisabled condition
            return instructions.MethodReplacer(
                AccessTools.Method(typeof(GameConditionManager), "ElectricityDisabled"),
                AccessTools.Method(typeof(PowerNet_PowerNetTick_Patch), "ElectricityDisabled"));
        }

        public static bool ElectricityDisabled(this GameConditionManager __instance, Map map)
        {
            return false;
        }
    }
}
