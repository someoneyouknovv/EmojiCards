using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Repository;
using EmojiCards.Resources;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class GuessMeGameViewModel : BaseViewModel
    {
        private readonly IGamesRepository _gamesRepository;
        private ObservableCollection<GuessMeCardModel> _guessMeCardsCollection;

        private GuessMeCardModel _currentCard = new GuessMeCardModel();
        public GuessMeCardModel CurrentCard
        {
            get => _currentCard;
            set => SetProperty(ref _currentCard, value);
        }

        private ICommand _voiceCommand;
        public ICommand VoiceCommand => _voiceCommand ??= new DelegateCommand<GuessMeCardModel>(OnVoiceCommandTapped);

        private ICommand _previousVoiceCardBtn;
        public ICommand PreviousVoiceCardBtn => _previousVoiceCardBtn ??= new DelegateCommand<object>(OnPreviousVoiceCardBtnTapped);

        private ICommand _nextVoiceCardBtn;
        public ICommand NextVoiceCardBtn => _nextVoiceCardBtn ??= new DelegateCommand<object>(OnNextVoiceCardBtnTapped);

        private ICommand _correctEmojiCommand;
        public ICommand CorrectEmojiCommand => _correctEmojiCommand ??= new DelegateCommand(OnCorrectEmojiCommand);

        private ICommand _wrongEmojiCommand;
        public ICommand WrongEmojiCommand => _wrongEmojiCommand ??= new DelegateCommand(OnWrongEmojiCommand);

        public GuessMeGameViewModel(Page page) : base(page)
        {
            _gamesRepository = new GamesRepository();
            _guessMeCardsCollection = _gamesRepository.GetAllGuessMeCards();
            _guessMeCardsCollection.Shuffle();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentCard = _guessMeCardsCollection.FirstOrDefault();
        }

        public void OnVoiceCommandTapped(GuessMeCardModel currentCard)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(currentCard.SoundSource);
            player.Play();
        }

        public void OnPreviousVoiceCardBtnTapped(object obj)
        {
            var currentId = (int)obj;
            var currentIndex = GetCurrentIndex(currentId);
            if (currentIndex == 0)
            {
                DisplayPopUps(currentIndex);
                return;
            }
            if (currentIndex > 0)
                CurrentCard = _guessMeCardsCollection[currentIndex - 1];
        }

        public void OnNextVoiceCardBtnTapped(object obj)
        {
            var currentId = (int)obj;
            var currentIndex = GetCurrentIndex(currentId);
            if (currentIndex == _guessMeCardsCollection.Count - 1)
            {
                DisplayPopUps(currentIndex);
                return;
            }
            if (currentIndex < _guessMeCardsCollection.Count - 1)
                CurrentCard = _guessMeCardsCollection[currentIndex + 1];
        }

        public async void DisplayPopUps(int index)
        {
            if (index == 0)
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertCantGoBack,
                    AppResources.SharedAlertOk);
            }
            else if (index == _guessMeCardsCollection.Count - 1)
            {
                var result = await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertPlayAgain,
                    AppResources.SharedAlertYes,
                    AppResources.SharedAlertNo);

                if (!result)
                    await page.Navigation.PopAsync();

                _guessMeCardsCollection.Shuffle();
                CurrentCard = _guessMeCardsCollection.FirstOrDefault();
            }
        }

        public void OnCorrectEmojiCommand()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("yay.mp3");
            player.Play();
        }

        public void OnWrongEmojiCommand()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("no.mp3");
            player.Play();
        }
        public int GetCurrentIndex(int currentCardID)
        {
            var currentIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                if (currentCardID == _guessMeCardsCollection[i].ID)
                {
                    currentIndex = i;
                    break;
                }
            }
            return currentIndex;
        }
    }
}
