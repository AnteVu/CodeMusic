using Microsoft.Internal.VisualStudio.PlatformUI;
using System.Threading.Tasks;
using System.Windows.Forms;
using DialogResult = System.Windows.Forms.DialogResult;

namespace CodeMusic
{
    [Command(PackageIds.PlayOrPause)]
    internal sealed class PauseMusic : BaseCommand<PauseMusic>
    {
        public  static MusicPlayer musicPlayer = new MusicPlayer();

        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            if (musicPlayer.Play)
            {
                Command.Checked = false;
                musicPlayer.Pause();
                return;
            }
            if (!await IsMusicFolderDefinedAsync())
            {
                return;
            }

            Command.Checked = true;
            musicPlayer.Start();
        }
        private async Task<bool> IsMusicFolderDefinedAsync()
        {
            GeneralSettings options = await GeneralSettings.GetLiveInstanceAsync();

            if (!string.IsNullOrEmpty(options.MusicFolder))
            {
                return true;
            }
            else
            {
                var dialog = new FolderBrowserDialog();
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    options.MusicFolder = dialog.SelectedPath;
                    await options.SaveAsync();
                    return true;
                }

                return false;
            }
        }
    }
}
