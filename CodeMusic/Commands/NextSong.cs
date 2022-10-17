using Microsoft.VisualStudio.OLE.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMusic.Commands
{
    [Command(PackageIds.cmdNext)]
    internal sealed class NextSong : BaseCommand<NextSong>
    {
        private static MusicPlayer _player = PauseMusic.musicPlayer;

        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            MusicPlayer player = _player;

            if (!player.Play)
            {
                
                player.Start();
                return;
            }

            GeneralSettings options = await GeneralSettings.GetLiveInstanceAsync();

            if (string.IsNullOrEmpty(options.MusicFolder))
            {
                return;
            }

      
            player.NextSong();
        }
    }
}
