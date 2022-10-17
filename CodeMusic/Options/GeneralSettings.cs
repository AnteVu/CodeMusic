using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CodeMusic
{
    internal partial class OptionsProvider
    {
        // Register the options with this attribute on your package class:
        // [ProvideOptionPage(typeof(OptionsProvider.General1Options), "CodeMusic", "General1", 0, 0, true, SupportsProfiles = true)]
        [ComVisible(true)]
        public class General1Options : BaseOptionPage<GeneralSettings> { }
    }

    public class GeneralSettings : BaseOptionModel<GeneralSettings>
    {
        [Category("Music")]
        [DisplayName("Music folder")]
        [Description("Disk folder containg all .mp3 files.")]
        [DefaultValue(true)]
        public string MusicFolder { get; set; } = "";
    }
}
