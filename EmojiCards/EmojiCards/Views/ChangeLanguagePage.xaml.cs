using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeLanguagePage : ContentPage
    {
        private ChangeLanguagePageViewModel _vm;
        public ChangeLanguagePage()
        {
            _vm = new ChangeLanguagePageViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}