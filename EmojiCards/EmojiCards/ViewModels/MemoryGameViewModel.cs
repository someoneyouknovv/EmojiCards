using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Repository;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class MemoryGameViewModel : BaseViewModel
    {
        private readonly IGamesRepository _gamesRepository;

        private ObservableCollection<CardGameModel> _cardsCollection = new ObservableCollection<CardGameModel>();

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

        private string _image5;
        public string Image5
        {
            get => _image5;
            set => SetProperty(ref _image5, value);
        }

        private string _image6;
        public string Image6
        {
            get => _image6;
            set => SetProperty(ref _image6, value);
        }

        private string _firstCard;
        public string FirstCard
        {
            get => _firstCard;
            set => SetProperty(ref _firstCard, value);
        }

        private string _secondCard;
        public string SecondCard
        {
            get => _secondCard;
            set => SetProperty(ref _secondCard, value);
        }

        public ObservableCollection<CardGameModel> CardsCollection
        {
            get => _cardsCollection;
            set => SetProperty(ref _cardsCollection, value);
        }

        private bool _isVisibleImage1 = true;
        public bool IsVisibleImage1
        {
            get => _isVisibleImage1;
            set => SetProperty(ref _isVisibleImage1, value);
        }

        private bool _isVisibleImage2 = true;
        public bool IsVisibleImage2
        {
            get => _isVisibleImage2;
            set => SetProperty(ref _isVisibleImage2, value);
        }

        private ICommand _image1Command;
        public ICommand Image1Command => _image1Command ??= new DelegateCommand(OnImage1Command);

        private ICommand _image2Command;
        public ICommand Image2Command => _image2Command ??= new DelegateCommand(OnImage2Command);

        private ICommand _image3Command;
        public ICommand Image3Command => _image3Command ??= new DelegateCommand(OnImage3Command);

        private ICommand _image4Command;
        public ICommand Image4Command => _image4Command ??= new DelegateCommand(OnImage4Command);

        private ICommand _image5Command;
        public ICommand Image5Command => _image5Command ??= new DelegateCommand(OnImage5Command);

        private ICommand _image6Command;
        public ICommand Image6Command => _image6Command ??= new DelegateCommand(OnImage6Command);

        public MemoryGameViewModel(Page page) : base(page)
        {
            _gamesRepository = new GamesRepository();
            CardsCollection = _gamesRepository.GetAllCards();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Image1 = Image2 = Image3 = Image4 = Image5 = Image6 = "question_mark.png";
        }


        public void OnImage1Command()
        {
            Image1 = "happy.png";
            CheckIfEqual();
        }
        public void OnImage2Command()
        {
            Image2 = "sad.png";
            CheckIfEqual();
        }
        public void OnImage3Command()
        {

        }
        public void OnImage4Command()
        {

        }
        public void OnImage5Command()
        {

        }
        public void OnImage6Command()
        {

        }

        public async void CheckIfEqual()
        {
            if(Image1 == Image2)
            {
                await Task.Delay(1000);
                IsVisibleImage1 = false;
                IsVisibleImage2 = false;
            }
            else
            {
                await Task.Delay(1000);
                Image1 = "question_mark.png";
                Image2 = "question_mark.png";
            }
        }
    }
}
