using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private MenuPageViewModel _vm;
        public MenuPage()
        {
            _vm = new MenuPageViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}