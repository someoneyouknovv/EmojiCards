﻿using EmojiCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteDetailsPage : ContentPage
    {
        private NoteDetailsViewModel _vm;
        public NoteDetailsPage()
        {
            _vm = new NoteDetailsViewModel(this);
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