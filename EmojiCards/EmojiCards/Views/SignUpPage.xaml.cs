using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private SignUpPageViewModel _vm;
        public SignUpPage()
        {
            _vm = new SignUpPageViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}