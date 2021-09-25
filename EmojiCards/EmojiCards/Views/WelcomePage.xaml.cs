using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        private WelcomeViewModel _vm;
        public WelcomePage()
        {
            _vm = new WelcomeViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}