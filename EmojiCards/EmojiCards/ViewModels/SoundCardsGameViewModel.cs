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

        private CardGameModel _currentCard = new CardGameModel();
        public CardGameModel CurrentCard
        {
            get => _currentCard;
            set => SetProperty(ref _currentCard, value);
        }

        private ObservableCollection<CardGameModel> _cardsCollection = new ObservableCollection<CardGameModel>();
        public ObservableCollection<CardGameModel> CardsCollection
        {
            get => _cardsCollection;
            set => SetProperty(ref _cardsCollection, value);
        }

        private ICommand _voiceCommand;
        public ICommand VoiceCommand => _voiceCommand ??= new DelegateCommand<object>(OnVoiceCommandTapped);

        private ICommand _previousVoiceCardBtn;
        public ICommand PreviousVoiceCardBtn => _previousVoiceCardBtn ??= new DelegateCommand<object>(OnPreviousVoiceCardBtnTapped);

        private ICommand _nextVoiceCardBtn;
        public ICommand NextVoiceCardBtn => _nextVoiceCardBtn ??= new DelegateCommand<object>(OnNextVoiceCardBtnTapped);

        public SoundCardsGameViewModel(Page page) : base(page)
        {

            _gamesRepository = new GamesRepository();
            CardsCollection = _gamesRepository.GetAllCards();
        }

        public void OnVoiceCommandTapped(object obj)
        {
            var id = (int)obj;
            //DependencyService.Get<IAudio>().PlayAudioFile("srekjen.mp3");
        }

        public void OnPreviousVoiceCardBtnTapped(object obj)
        {
            var currInt = (int)obj;
            if (currInt == 1)
            {
                DisplayPopUps();
                return;
            }
            CurrentCard = CardsCollection.OrderByDescending(i => i.ID).Where(c => c.ID < currInt).FirstOrDefault();
        }

        public void OnNextVoiceCardBtnTapped(object obj)
        {
            var currInt = (int)obj;
            if (currInt == 10)
            {
                DisplayPopUps();
                return;
            }
            CurrentCard = CardsCollection.Where(c => c.ID > currInt).FirstOrDefault();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentCard = CardsCollection.FirstOrDefault();
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

                CurrentCard = CardsCollection.FirstOrDefault();
            }
        }
    }
}
