using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public string WebApiKey = "AIzaSyA5ssBLbQEyIo9pDUBomOweQYAD9hyoL94";

        private LogInViewModel _vm;
        public LogInPage()
        {
            _vm = new LogInViewModel(this);
            InitializeComponent();

            BindingContext = _vm;
        }
        protected override void OnAppearing()
        {
            _vm.OnNavigatedTo(null);
            base.OnAppearing();
        }
    }
}