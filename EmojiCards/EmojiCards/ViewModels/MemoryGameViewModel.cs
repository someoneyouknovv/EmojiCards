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
        private ObservableCollection<MemoryCardModel> _memoryCardsCollection = new ObservableCollection<MemoryCardModel>();

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

        private bool _areNavigationButtonsEnabled = true;
        public bool AreNavigationButtonsEnabled
        {
            get => _areNavigationButtonsEnabled;
            set => SetProperty(ref _areNavigationButtonsEnabled, value);
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
            _memoryCardsCollection.Shuffle();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Image1 = Image2 = Image3 = Image4  = "question_mark.png";
            CurrentCard = _memoryCardsCollection.First();
        }

        public async void OnUnvealCardsCommandAsync()
        {
            AreNavigationButtonsEnabled =  false;
            Image1 = CurrentCard.ImageSource1;
            Image2 = CurrentCard.ImageSource2;
            Image3 = CurrentCard.ImageSource3;
            Image4 = CurrentCard.ImageSource4;

            await Task.Delay(3000);

            Image1 = Image2 = Image3 = Image4 = "question_mark.png";
            AreNavigationButtonsEnabled =  true;
            IsUnvealCardsBtnVisible = false;
        }

        public async void OnImageCommand(string imageID)
        {
            if (IsUnvealCardsBtnVisible)
                return;

            AreNavigationButtonsEnabled = false;
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
            AreNavigationButtonsEnabled = true;
        }

        public void OnVoiceCommandTapped(MemoryCardModel currentCard)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(currentCard.SoundSource);
            player.Play();
        }

        public void OnPreviousVoiceCardBtnTapped(MemoryCardModel currentCard)
        {
            var currentId = currentCard.ID;
            var currentIndex = GetCurrentIndex(currentId);
            if (currentIndex == 0)
            {
                DisplayPopUps(currentIndex);
                return;
            }
            IsUnvealCardsBtnVisible = true;
            if (currentIndex > 0)
                CurrentCard = _memoryCardsCollection[currentIndex - 1];
        }

        public void OnNextVoiceCardBtnTapped(MemoryCardModel currentCard)
        {
            var currentId = currentCard.ID;
            var currentIndex = GetCurrentIndex(currentId);
            if (currentIndex == _memoryCardsCollection.Count - 1)
            {
                DisplayPopUps(currentIndex);
                return;
            }
            IsUnvealCardsBtnVisible = true;
            if (currentIndex < _memoryCardsCollection.Count - 1)
                CurrentCard = _memoryCardsCollection[currentIndex + 1];
        }

        public async void DisplayPopUps(int index)
        {
            if (index == 0)
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertCantGoBack,
                    AppResources.SharedAlertOk);
            }
            else if (index == _memoryCardsCollection.Count - 1)
            {
                var result = await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertPlayAgain,
                    AppResources.SharedAlertYes,
                    AppResources.SharedAlertNo);

                if (!result)
                    await page.Navigation.PopAsync();

                _memoryCardsCollection.Shuffle();
                CurrentCard = _memoryCardsCollection.FirstOrDefault();
            }
        }

        public int GetCurrentIndex(int currentCardID)
        {
            var currentIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                if (currentCardID == _memoryCardsCollection[i].ID)
                {
                    currentIndex = i;
                    break;
                }
            }
            return currentIndex;
        }
    }
}
