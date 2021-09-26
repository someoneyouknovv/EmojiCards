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

        private string _imageSource;
        public string ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        private string _helper;
        public string Helper
        {
            get => _helper;
            set => SetProperty(ref _helper, value);
        }

        private bool _isHelperVisible;
        public bool IsHelperVisible
        {
            get => _isHelperVisible;
            set => SetProperty(ref _isHelperVisible, value);
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

        public FlashCardsGameViewModel(Page page) : base(page)
        {
            _gamesRepository = new GamesRepository();
            CardsCollection = _gamesRepository.GetAllCards();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            ImageSource = "question_mark.jpg";
            Helper = AppResources.FlashCardsGamePageLabelHelper;
            IsHelpBtnVisible = false;
            IsHelperVisible = true;
        }

        public void OnQuestionMarkImageTapped()
        {
            var randomNumber = _random.Next(9) + 1;
            ImageSource = CardsCollection.Where(c => c.ID == randomNumber).FirstOrDefault().ImageSource;
            Helper = CardsCollection.Where(c => c.ID == randomNumber).FirstOrDefault().EmojiName;
            IsHelpBtnVisible = true;
            IsHelperVisible = false;
        }

        public void OnHelpNeededCommand()
        {
            IsHelpBtnVisible = false;
            IsHelperVisible = true;
        }
    }
}
