using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Repository;
using EmojiCards.Resources;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class MemoryGameViewModel : BaseViewModel
    {
        private readonly IGamesRepository _gamesRepository;

        private MemoryCardModel _currentCard;
        public MemoryCardModel CurrentCard
        {
            get => _currentCard;
            set => SetProperty(ref _currentCard, value);
        }

        private string _image1;
        public string Image1
        {
            get => _image1;
            set => SetProperty(ref _image1, value);
        }

        private string _image2;
        public string Image2
        {
            get => _image2;
            set => SetProperty(ref _image2, value);
        }

        private string _image3;
        public string Image3
        {
            get => _image3;
            set => SetProperty(ref _image3, value);
        }

        private string _image4;
        public string Image4
        {
            get => _image4;
            set => SetProperty(ref _image4, value);
        }

        private bool _areImagesEnabled = false;
        public bool AreImagesEnabled
        {
            get => _areImagesEnabled;
            set => SetProperty(ref _areImagesEnabled, value);
        }

        private bool _isUnvealCardsBtnVisible = true;
        public bool IsUnvealCardsBtnVisible
        {
            get => _isUnvealCardsBtnVisible;
            set => SetProperty(ref _isUnvealCardsBtnVisible, value);
        }

        private ObservableCollection<MemoryCardModel> _memoryCardsCollection = new ObservableCollection<MemoryCardModel>();
        public ObservableCollection<MemoryCardModel> MemoryCardsCollection
        {
            get => _memoryCardsCollection;
            set => SetProperty(ref _memoryCardsCollection, value);
        }

        private bool _isVisibleImage1 = true;
        public bool IsVisibleImage1
        {
            get => _isVisibleImage1;
            set => SetProperty(ref _isVisibleImage1, value);
        }

        private bool _isVisibleImage2 = true;
        public bool IsVisibleImage2
        {
            get => _isVisibleImage2;
            set => SetProperty(ref _isVisibleImage2, value);
        }

        private ICommand _unvealCardsCommand;
        public ICommand UnvealCardsCommand => _unvealCardsCommand ??= new DelegateCommand(OnUnvealCardsCommandAsync);

        private ICommand _imageCommand;
        public ICommand ImageCommand => _imageCommand ??= new DelegateCommand<string>(OnImageCommand);

        private ICommand _voiceCommand;
        public ICommand VoiceCommand => _voiceCommand ??= new DelegateCommand<MemoryCardModel>(OnVoiceCommandTapped);

        private ICommand _previousVoiceCardBtn;
        public ICommand PreviousVoiceCardBtn => _previousVoiceCardBtn ??= new DelegateCommand<MemoryCardModel>(OnPreviousVoiceCardBtnTapped);

        private ICommand _nextVoiceCardBtn;
        public ICommand NextVoiceCardBtn => _nextVoiceCardBtn ??= new DelegateCommand<MemoryCardModel>(OnNextVoiceCardBtnTapped);


        public MemoryGameViewModel(Page page) : base(page)
        {
            _gamesRepository = new GamesRepository();
            _memoryCardsCollection = _gamesRepository.GetAllMemoryCards();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Image1 = Image2 = Image3 = Image4  = "question_mark.png";
            CurrentCard = MemoryCardsCollection.First();
        }

        public async void OnUnvealCardsCommandAsync()
        {
            Image1 = CurrentCard.ImageSource1;
            Image2 = CurrentCard.ImageSource2;
            Image3 = CurrentCard.ImageSource3;
            Image4 = CurrentCard.ImageSource4;

            await Task.Delay(3000);

            Image1 = Image2 = Image3 = Image4 = "question_mark.png";
            IsUnvealCardsBtnVisible = false;
        }

        public async void OnImageCommand(string imageID)
        {
            if (IsUnvealCardsBtnVisible)
                return;

            if (imageID.Equals("1"))
            {
                Image1 = CurrentCard.ImageSource1;
                if (imageID.Equals(CurrentCard.CorrectImage))
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("yay.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image1 = "question_mark.png";
                }
                else
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("no.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image1 = "question_mark.png";
                }
            }
            else if (imageID.Equals("2"))
            {
                Image2 = CurrentCard.ImageSource2;
                if (imageID.Equals(CurrentCard.CorrectImage))
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("yay.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image2 = "question_mark.png";
                }
                else
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("no.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image2 = "question_mark.png";
                }
            }
            else if (imageID.Equals("3"))
            {
                Image3 = CurrentCard.ImageSource3;
                if (imageID.Equals(CurrentCard.CorrectImage))
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("yay.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image3 = "question_mark.png";
                }
                else
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("no.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image3 = "question_mark.png";
                }
            }
            else if (imageID.Equals("4"))
            {
                Image4 = CurrentCard.ImageSource4;
                if (imageID.Equals(CurrentCard.CorrectImage))
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("yay.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image4 = "question_mark.png";
                }
                else
                {
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    player.Load("no.mp3");
                    player.Play();
                    await Task.Delay(3000);
                    Image4 = "question_mark.png";
                }
            }
        }


        public void OnVoiceCommandTapped(MemoryCardModel currentCard)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(currentCard.SoundSource);
            player.Play();
        }

        public void OnPreviousVoiceCardBtnTapped(MemoryCardModel currentCards)
        {
            if (currentCards.ID == 1)
            {
                DisplayPopUps();
                return;
            }
            IsUnvealCardsBtnVisible = true;
            CurrentCard = MemoryCardsCollection.OrderByDescending(i => i.ID).Where(c => c.ID < currentCards.ID).FirstOrDefault();
        }

        public void OnNextVoiceCardBtnTapped(MemoryCardModel currentCards)
        {
            if (currentCards.ID == 10)
            {
                DisplayPopUps();
                return;
            }
            IsUnvealCardsBtnVisible = true;
            CurrentCard = MemoryCardsCollection.Where(c => c.ID > currentCards.ID).FirstOrDefault();
        }

        public async void DisplayPopUps()
        {
            if (CurrentCard.ID == 1)
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertCantGoBack,
                    AppResources.SharedAlertOk);
            }
            else if (CurrentCard.ID == 10)
            {
                var result = await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertPlayAgain,
                    AppResources.SharedAlertYes,
                    AppResources.SharedAlertNo);

                if (!result)
                    await page.Navigation.PopAsync();

                CurrentCard = MemoryCardsCollection.FirstOrDefault();
            }
        }

    }
}
