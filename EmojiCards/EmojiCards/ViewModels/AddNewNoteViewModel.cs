﻿using EmojiCards.Models;
using EmojiCards.Resources;
using EmojiCards.Services;
using Firebase.Auth;
using Mobile.Portable;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class AddNewNoteViewModel : BaseViewModel
    {
        private DBFirebase _services;
        public string WebApiKey = "AIzaSyA5ssBLbQEyIo9pDUBomOweQYAD9hyoL94";

        private Note _currentNote = new Note();
        public Note CurrentNote
        {
            get => _currentNote;
            set => SetProperty(ref _currentNote, value);
        }

        private FirebaseUser _currentFirebaseUser = new FirebaseUser();
        public FirebaseUser CurrentFirebaseUser
        {
            get => _currentFirebaseUser;
            set => SetProperty(ref _currentFirebaseUser, value);
        }

        private ICommand _addNoteBtnTappedCommand;
        public ICommand AddNoteBtnTappedCommand => _addNoteBtnTappedCommand ??= new DelegateCommand<Note>(OnAddNoteBtnTappedCommand);

        public AddNewNoteViewModel(Page page) : base(page)
        {
            _services = new DBFirebase();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentFirebaseUser = Singleton.Instance.CurrentFirebaseUser;
            RefreshToken();
        }

        public async void OnAddNoteBtnTappedCommand(Note newNote)
        {
            CurrentNote = newNote;
            if (string.IsNullOrWhiteSpace(CurrentNote.Title) || string.IsNullOrWhiteSpace(CurrentNote.Title))
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertFIllBlanks,
                    AppResources.SharedAlertOk);
                return;
            }
            await _services.AddNote(CurrentFirebaseUser.Username, CurrentNote.Title, CurrentNote.Description);
            await page.Navigation.PopAsync();
        }

        public async void RefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var savedFirebaseAuth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>
                    (Preferences.Get("MyFirebaseRefreshToken", ""));
                var refreshedContent = await authProvider.RefreshAuthAsync(savedFirebaseAuth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(refreshedContent));
            }
            catch (Exception)
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert, 
                    AppResources.SharedAlertSomethingWentWrong,
                    AppResources.SharedAlertOk);
            }
        }
    }
}
