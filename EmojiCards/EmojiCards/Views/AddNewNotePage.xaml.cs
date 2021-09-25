using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewNotePage : ContentPage
    {
        private AddNewNotePageViewModel _vm;
        public AddNewNotePage()
        {
            _vm = new AddNewNotePageViewModel(this);
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