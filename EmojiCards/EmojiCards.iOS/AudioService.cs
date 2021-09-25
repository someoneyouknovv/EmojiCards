using AVFoundation;
using EmojiCards.Interfaces;
using EmojiCards.iOS;
using Foundation;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace EmojiCards.iOS
{
    public class AudioService : IAudio
    {
		public AudioService() { }
		public void PlayAudioFile(string fileName)
		{
			string sFilePath = NSBundle.MainBundle.PathForResource
			(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
			var url = NSUrl.FromString(sFilePath);
			var _player = AVAudioPlayer.FromUrl(url);
			_player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
				_player = null;
			};
			_player.Play();
		}
	}
}