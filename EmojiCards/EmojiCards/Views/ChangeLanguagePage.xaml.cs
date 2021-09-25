using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeLanguagePage : ContentPage
    {
        private ChangeLanguageViewModel _vm;
        public ChangeLanguagePage()
        {
            _vm = new ChangeLanguageViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}