using Prism.Mvvm;

namespace EmojiCards.Models
{
    public class MemoryCardModel : BindableBase
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

        private string _soundSource;
        public string SoundSource
        {
            get => _soundSource;
            set => SetProperty(ref _soundSource, value);
        }


        private string _imageSource1;
        public string ImageSource1
        {
            get => _imageSource1;
            set => SetProperty(ref _imageSource1, value);
        }


        private string _imageSource2;
        public string ImageSource2
        {
            get => _imageSource2;
            set => SetProperty(ref _imageSource2, value);
        }

        private string _imageSource3;
        public string ImageSource3
        {
            get => _imageSource3;
            set => SetProperty(ref _imageSource3, value);
        }

        private string _imageSource4;
        public string ImageSource4
        {
            get => _imageSource4;
            set => SetProperty(ref _imageSource4, value);
        }

        private string _correctImage;
        public string CorrectImage
        {
            get => _correctImage;
            set => SetProperty(ref _correctImage, value);
        }
    }
}
