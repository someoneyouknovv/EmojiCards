using Prism.Mvvm;

namespace EmojiCards.Models
{
    public class GuessMeCardModel : BindableBase
    {
        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _emojiName;
        public string EmojiName
        {
            get => _emojiName;
            set => SetProperty(ref _emojiName, value);
        }

        private string _correctEmoji;
        public string CorrectEmoji
        {
            get => _correctEmoji;
            set => SetProperty(ref _correctEmoji, value);
        }

        private string _wrongEmoji;
        public string WrongEmoji
        {
            get => _wrongEmoji;
            set => SetProperty(ref _wrongEmoji, value);
        }

        private string _soundSource;
        public string SoundSource
        {
            get => _soundSource;
            set => SetProperty(ref _soundSource, value);
        }
    }
}
