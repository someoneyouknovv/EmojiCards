using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoundCardsGamePage : ContentPage
    {
        private SoundCardsGamePageViewModel _vm;
        public SoundCardsGamePage()
        {
            _vm = new SoundCardsGamePageViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
        protected override void OnAppearing()
        {
            _vm.OnNavigatedTo(null);
            base.OnAppearing();
        }
    }
}