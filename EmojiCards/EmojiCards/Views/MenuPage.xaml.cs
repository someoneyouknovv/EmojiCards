using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private MenuViewModel _vm;
        public MenuPage()
        {
            _vm = new MenuViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}