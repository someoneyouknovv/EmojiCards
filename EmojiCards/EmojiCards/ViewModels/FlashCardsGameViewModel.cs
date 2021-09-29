using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Repository;
using EmojiCards.Resources;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class FlashCardsGameViewModel : BaseViewModel
    {
        private readonly IGamesRepository _gamesRepository;
        private Random _random = new Random();

        private CardGameModel _currentCard = new CardGameModel();
        public CardGameModel CurrentCard
        {
            get => _currentCard;
            set => SetProperty(ref _currentCard, value);
        }

        private bool _isEmojiNameVisible;
        public bool IsEmojiNameVisible
        {
            get => _isEmojiNameVisible;
            set => SetProperty(ref _isEmojiNameVisible, value);
        }

        private string _btnHelp;
        public string BtnHelp
        {
            get => _btnHelp;
            set => SetProperty(ref _btnHelp, value);
        }

        private bool _isHelpBtnVisible;
        public bool IsHelpBtnVisible
        {
            get => _isHelpBtnVisible;
            set => SetProperty(ref _isHelpBtnVisible, value);
        }

        private ObservableCollection<CardGameModel> _cardsCollection = new ObservableCollection<CardGameModel>();
        public ObservableCollection<CardGameModel> CardsCollection 
        {
            get => _cardsCollection;
            set => SetProperty(ref _cardsCollection, value);
        }

        private ICommand _questionMarkImageCommand;
        public ICommand QuestionMarkImageCommand => _questionMarkImageCommand ??= new DelegateCommand(OnQuestionMarkImageTapped);

        private ICommand _helpNeededCommand;
        public ICommand HelpNeededCommand => _helpNeededCommand ??= new DelegateCommand(OnHelpNeededCommand);

        private ICommand _voiceCommand;
        public ICommand VoiceCommand => _voiceCommand ??= new DelegateCommand<CardGameModel>(OnVoiceCommandTapped);

        public FlashCardsGameViewModel(Page page) : base(page)
        {
            _gamesRepository = new GamesRepository();
            CardsCollection = _gamesRepository.GetAllCards();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentCard.ImageSource = "question_mark.jpg";
            IsHelpBtnVisible = false;
            IsEmojiNameVisible = false;
        }

        public void OnQuestionMarkImageTapped()
        {
            var randomNumber = _random.Next(9) + 1;
            CurrentCard = CardsCollection.Where(c => c.ID == randomNumber).FirstOrDefault();
            IsHelpBtnVisible = true;
            IsEmojiNameVisible = false;
        }

        public void OnHelpNeededCommand()
        {
            IsHelpBtnVisible = false;
            IsEmojiNameVisible = true;
        }

        public void OnVoiceCommandTapped(CardGameModel currentCard)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(currentCard.SoundSource);
            player.Play();
        }
    }
}
