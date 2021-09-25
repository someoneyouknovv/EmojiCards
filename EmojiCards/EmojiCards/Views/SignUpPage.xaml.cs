using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private SignUpViewModel _vm;
        public SignUpPage()
        {
            _vm = new SignUpViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}