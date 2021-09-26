using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardsGamePage : ContentPage
    {
        private FlashCardsGameViewModel _vm;
        public FlashCardsGamePage()
        {
            _vm = new FlashCardsGameViewModel(this);
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