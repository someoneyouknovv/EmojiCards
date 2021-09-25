using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Repository;
using EmojiCards.Resources;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class SoundCardsGamePageViewModel : BaseViewModel
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

        public SoundCardsGamePageViewModel(Page page) : base(page)
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
            DisplayPopUps();

        }

        public void OnNextVoiceCardBtnTapped(object obj)
        {
            if(CurrentCard.ID == 10)
            {
                DisplayPopUps();
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
                await page.DisplayAlert("alert", "nema kade da odis nazad", "ok");
                return;
            }
            else if(CurrentCard.ID == 10)
            {
                var result = await page.DisplayAlert("Alert", "sakas li od pocetok?", "yes", "no");
                if (!result)
                    await page.Navigation.PopAsync();
                CurrentCard = CardsList.FirstOrDefault();
            }

        }
    }
}
