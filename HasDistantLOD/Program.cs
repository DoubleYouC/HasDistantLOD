using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Fallout4;
using Noggog;

namespace HasDistantLOD
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<IFallout4Mod, IFallout4ModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.Fallout4, "HasDistantLOD.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<IFallout4Mod, IFallout4ModGetter> state)
        {
            Console.WriteLine("HasDistantLOD START");

            //iterate over all static records
            foreach (var staticGetter in state.LoadOrder.PriorityOrder.Static().WinningOverrides())
            {
                //check if the static has the HasDistantLOD flag
                if (!EnumExt.HasFlag(staticGetter.MajorRecordFlagsRaw, 32768)) continue;

                //add it to the patch
                var myFavoriteStatic = state.PatchMod.Statics.GetOrAddAsOverride(staticGetter);

                //remove flag
                myFavoriteStatic.MajorRecordFlagsRaw = staticGetter.MajorRecordFlagsRaw - 32768;
                Console.WriteLine($"Removed HasDistantLOD flag from {staticGetter.EditorID}.");
            }
        }
    }
}
