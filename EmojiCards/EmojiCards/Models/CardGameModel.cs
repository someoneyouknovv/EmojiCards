using Prism.Mvvm;

namespace EmojiCards.Models
{
    public class CardGameModel : BindableBase
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

        private string _imageSource;
        public string ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        private string _soundSource;
        public string SoundSource
        {
            get => _soundSource;
            set => SetProperty(ref _soundSource, value);
        }
    }
}
