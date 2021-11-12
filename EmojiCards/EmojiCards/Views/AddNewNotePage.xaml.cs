using EmojiCards.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewNotePage : ContentPage
    {
        private AddNewNoteViewModel _vm;
        public AddNewNotePage()
        {
            _vm = new AddNewNoteViewModel(this);
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