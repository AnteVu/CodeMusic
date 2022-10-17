using Community.VisualStudio.Toolkit;
using EnvDTE;
using Microsoft.VisualStudio.Debugger.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace CodeMusic
{
    public class MusicPlayer
    {
        private WindowsMediaPlayer player;

        public MusicPlayer()
        {
            player = new WindowsMediaPlayer();
        }
        public bool Play => player.playState == WMPPlayState.wmppsPlaying;
        public void Start()
        {
            if (player.playState != WMPPlayState.wmppsPaused)
            {
                player.currentPlaylist = GeneratePlayList();
                
            }
            player.controls.play();
        }

        public void Pause()
        {
            player.controls.pause();
        }

        public void Stop()
        {
            player.controls.stop();
        }

        private IWMPPlaylist GeneratePlayList()
        {
            IWMPPlaylistArray playlists = player.playlistCollection.getByName(nameof(MusicPlayer));
            IWMPPlaylist playlist;

            if (playlists.count > 0)
            {
                playlist = playlists.Item(0);
                playlist.clear();
            }
            else
            {
                playlist = player.playlistCollection.newPlaylist(nameof(MusicPlayer));
            }
            foreach (var file in Directory.EnumerateFiles(GeneralSettings.Instance.MusicFolder, "*.mp3"))
            {
                IWMPMedia media = player.newMedia(file);
                playlist.appendItem(media);
            }
            return playlist;
        }
        public void NextSong()
        {
            player.controls.next();
        }

        public void PreviousSong()
        {
            player.controls.previous();
        }

    }
}
