using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Repository;
using EmojiCards.Resources;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class SoundCardsGameViewModel : BaseViewModel
    {
        private readonly IGamesRepository _gamesRepository;

        private SoundCardsGameModel _currentCard = new SoundCardsGameModel();
        public SoundCardsGameModel CurrentCard
        {
            get => _currentCard;
            set => SetProperty(ref _currentCard, value);
        }

        private List<SoundCardsGameModel> _cardsList = new List<SoundCardsGameModel>();
        public List<SoundCardsGameModel> CardsList
        {
            get => _cardsList;
            set => SetProperty(ref _cardsList, value);
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
            CardsList = _gamesRepository.GetAllSoundCards();
        }

        public void OnVoiceCommandTapped(object obj)
        {
            var id = (int)obj;
            //DependencyService.Get<IAudio>().PlayAudioFile("srekjen.mp3");
        }

        public void OnPreviousVoiceCardBtnTapped(object obj)
        {
            if (CurrentCard.ID == 1)
            {
                DisplayPopUps();
                return;
            }
            CurrentCard = CardsList.OrderByDescending(i => i.ID).
                Where(c => c.ID > CurrentCard.ID).FirstOrDefault();
        }

        public void OnNextVoiceCardBtnTapped(object obj)
        {
            if(CurrentCard.ID == 10)
            {
                DisplayPopUps();
                return;
            }
            CurrentCard = CardsList.Where(c => c.ID > CurrentCard.ID).FirstOrDefault();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentCard = CardsList.FirstOrDefault();
        }

        public async void DisplayPopUps()
        {
            if(CurrentCard.ID == 1)
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SoundCardsGamePageAlertCantGoBack,
                    AppResources.SharedAlertOk);
            }
            else if(CurrentCard.ID == 10)
            {
                var result = await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SoundCardsGamePageAlertPlayAgain,
                    AppResources.SharedAlertYes,
                    AppResources.SharedAlertNo);

                if (!result)
                    await page.Navigation.PopAsync();
                CurrentCard = CardsList.FirstOrDefault();
            }
        }
    }
}
