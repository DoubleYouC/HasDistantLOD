using Mutagen.Bethesda.Synthesis.Settings;

namespace HasDistantLOD
{
	internal class HasDistantLodSettings
	{
		[SynthesisOrder]
		[SynthesisSettingName("Verbose")]
		[SynthesisTooltip("Enable verbose messages.")]
		public bool verboseConsoleLog = false;
	}
}