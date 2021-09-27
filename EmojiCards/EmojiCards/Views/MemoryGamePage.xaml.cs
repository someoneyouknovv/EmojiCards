using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoryGamePage : ContentPage
    {
        private MemoryGameViewModel _vm;
        public MemoryGamePage()
        {
            _vm = new MemoryGameViewModel(this);
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