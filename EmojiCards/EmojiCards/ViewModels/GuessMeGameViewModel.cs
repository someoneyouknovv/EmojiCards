﻿using EmojiCards.Interfaces;
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
        public ObservableCollection<GuessMeCardModel> GuessMeCardsCollection
        {
            get => _guessMeCardsCollection;
            set => SetProperty(ref _guessMeCardsCollection, value);
        }

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
            GuessMeCardsCollection = _gamesRepository.GetAllGuessMeCards();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentCard = GuessMeCardsCollection.FirstOrDefault();
        }

        public void OnVoiceCommandTapped(GuessMeCardModel currentCard)
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
            CurrentCard = GuessMeCardsCollection.OrderByDescending(i => i.ID).Where(c => c.ID < currInt).FirstOrDefault();   
        }

        public void OnNextVoiceCardBtnTapped(object obj)
        {
            var currInt = (int)obj;
            if (currInt== 10)
            {
                DisplayPopUps();
                return;
            }
            CurrentCard = GuessMeCardsCollection.Where(c => c.ID > currInt).FirstOrDefault();
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

                CurrentCard = GuessMeCardsCollection.FirstOrDefault();
            }
        }

        public async void OnCorrectEmojiCommand()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("yay.mp3");
            player.Play();
        }

        public async void OnWrongEmojiCommand()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("no.mp3");
            player.Play();
        }
    }
}
