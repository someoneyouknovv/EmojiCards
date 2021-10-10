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
            var currInt = (int)obj;
            if (currInt == 1)
            {
                DisplayPopUps();
                return;
            }
            CurrentCard = _cardsCollection.OrderByDescending(i => i.ID).Where(c => c.ID < currInt).FirstOrDefault();
        }

        public void OnNextVoiceCardBtnTapped(object obj)
        {
            var currInt = (int)obj;
            if (currInt == 10)
            {
                DisplayPopUps();
                return;
            }
            CurrentCard = _cardsCollection.Where(c => c.ID > currInt).FirstOrDefault();
        }

        public async void DisplayPopUps()
        {
            if(CurrentCard.ID == 1)
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertCantGoBack,
                    AppResources.SharedAlertOk);
            }
            else if(CurrentCard.ID == 10)
            {
                var result = await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertPlayAgain,
                    AppResources.SharedAlertYes,
                    AppResources.SharedAlertNo);

                if (!result)
                    await page.Navigation.PopAsync();

                CurrentCard = _cardsCollection.FirstOrDefault();
            }
        }
    }
}
