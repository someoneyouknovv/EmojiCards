using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPasswordPage : ContentPage
    {
        private ResetPasswordViewModel _vm;
        public ResetPasswordPage()
        {
            _vm = new ResetPasswordViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}