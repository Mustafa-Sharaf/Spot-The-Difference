using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SpotDifferenceGames.GameLogic
{
    

    public static class SoundPlayerService
    {
        public static void Play(string path)
        {
            var reader = new AudioFileReader(path);
            var player = new WaveOutEvent();

            player.Init(reader);
            player.Play();

            player.PlaybackStopped += (s, e) =>
            {
                player.Dispose();
                reader.Dispose();
            };
        }

       
    }

}
