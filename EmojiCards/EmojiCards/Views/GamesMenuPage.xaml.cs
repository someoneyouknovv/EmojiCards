using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamesMenuPage : ContentPage
    {
        private GamesMenuViewModel _vm;
        public GamesMenuPage()
        {
            _vm = new GamesMenuViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
    }
}