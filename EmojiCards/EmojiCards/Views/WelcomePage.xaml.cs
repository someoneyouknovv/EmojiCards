using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        private WelcomePageViewModel _vm;
        public WelcomePage()
        {
            _vm = new WelcomePageViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}