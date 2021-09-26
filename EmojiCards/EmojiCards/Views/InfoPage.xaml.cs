using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        private InfoViewModel _vm;
        public InfoPage()
        {
            _vm = new InfoViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}