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
    public class SoundCardsGameViewModel : BaseViewModel
    {
        private readonly IGamesRepository _gamesRepository;
        private ObservableCollection<CardGameModel> _cardsCollection = new ObservableCollection<CardGameModel>();

        private CardGameModel _currentCard = new CardGameModel();
        public CardGameModel CurrentCard
        {
            get => _currentCard;
            set => SetProperty(ref _currentCard, value);
        }

        private ICommand _voiceCommand;
        public ICommand VoiceCommand => _voiceCommand ??= new DelegateCommand<CardGameModel>(OnVoiceCommandTapped);

        private ICommand _previousVoiceCardBtn;
        public ICommand PreviousVoiceCardBtn => _previousVoiceCardBtn ??= new DelegateCommand<object>(OnPreviousVoiceCardBtnTapped);

        private ICommand _nextVoiceCardBtn;
        public ICommand NextVoiceCardBtn => _nextVoiceCardBtn ??= new DelegateCommand<object>(OnNextVoiceCardBtnTapped);

        public SoundCardsGameViewModel(Page page) : base(page)
        {
            _gamesRepository = new GamesRepository();
            _cardsCollection = _gamesRepository.GetAllCards();
            _cardsCollection.Shuffle();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentCard = _cardsCollection.FirstOrDefault();
        }

        public void OnVoiceCommandTapped(CardGameModel currentCard)
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
                CurrentCard = _cardsCollection[currentIndex - 1];
        }

        public void OnNextVoiceCardBtnTapped(object obj)
        {
            var currentId = (int)obj;
            var currentIndex = GetCurrentIndex(currentId);
            if (currentIndex == _cardsCollection.Count - 1)
            {
                DisplayPopUps(currentIndex);
                return;
            }
            if (currentIndex < _cardsCollection.Count - 1)
                CurrentCard = _cardsCollection[currentIndex + 1];
        }

        public async void DisplayPopUps(int index)
        {
            if(index  == 0)
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertCantGoBack,
                    AppResources.SharedAlertOk);
            }
            else if(index == _cardsCollection.Count - 1)
            {
                var result = await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertPlayAgain,
                    AppResources.SharedAlertYes,
                    AppResources.SharedAlertNo);

                if (!result)
                    await page.Navigation.PopAsync();

                _cardsCollection.Shuffle();
                CurrentCard = _cardsCollection.FirstOrDefault();
            }
        }

        public int GetCurrentIndex(int currentCardID)
        {
            var currentIndex = 0;
            for(int i = 0; i < 10; i ++)
            {
                if (currentCardID == _cardsCollection[i].ID)
                {
                    currentIndex = i;
                    break;
                }
            }
            return currentIndex;
        }
    }
}
