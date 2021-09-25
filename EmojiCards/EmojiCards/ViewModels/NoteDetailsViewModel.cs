using EmojiCards.Models;
using EmojiCards.Resources;
using EmojiCards.Services;
using Firebase.Auth;
using Mobile.Portable;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class NoteDetailsViewModel : BaseViewModel
    {
        public string WebApiKey = "AIzaSyA5ssBLbQEyIo9pDUBomOweQYAD9hyoL94";
        private DBFirebase _services;

        private FirebaseUser _currentFirebaseUser = new FirebaseUser();
        public FirebaseUser CurrentFirebaseUser
        {
            get => _currentFirebaseUser;
            set => SetProperty(ref _currentFirebaseUser, value);
        }

        private Note _currentNote = new Note();
        public Note CurrentNote
        {
            get => _currentNote;
            set => SetProperty(ref _currentNote, value);
        }

        private bool _isDeleteBtnVisible = false;
        public bool IsDeleteBtnVisible
        {
            get => _isDeleteBtnVisible;
            set => SetProperty(ref _isDeleteBtnVisible, value);
        }

        private ICommand _updateNoteBtnTappedCommand;
        public ICommand UpdateNoteBtnTappedCommand => _updateNoteBtnTappedCommand ??= new DelegateCommand(OnUpdateNoteBtnTappedCommand);

        private ICommand _deleteNoteBtnTappedCommand;
        public ICommand DeleteNoteBtnTappedCommand => _deleteNoteBtnTappedCommand ??= new DelegateCommand(OnDeleteNoteBtnTappedCommand);


        public NoteDetailsViewModel(Page page) : base(page)
        {
            _services = new DBFirebase();
        }

        public async void OnUpdateNoteBtnTappedCommand()
        {
            if (string.IsNullOrWhiteSpace(CurrentNote.Title) || string.IsNullOrWhiteSpace(CurrentNote.Title))
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.SharedAlertFIllBlanks,
                    AppResources.SharedAlertOk);
                return;
            }

            await _services.UpdateNote(CurrentFirebaseUser.Username, CurrentNote.ID, CurrentNote.Title, CurrentNote.Description);
            await page.Navigation.PopAsync();
        }

        public async void OnDeleteNoteBtnTappedCommand()
        {
            var result = await page.DisplayAlert(AppResources.SharedAlertAlert,
                AppResources.NoteDetailsPageAlertConfirmationDeleteNote,
                AppResources.SharedAlertYes,
                AppResources.SharedAlertNo);

            if (!result)
                return;

            await _services.DeleteNote(CurrentFirebaseUser.Username, CurrentNote.ID);
            await page.Navigation.PopAsync();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            CurrentNote = Singleton.Instance.CurrentNote;

            if(Singleton.Instance.CurrentNote != null)
            {
                IsDeleteBtnVisible = true;
            }

            CurrentFirebaseUser = Singleton.Instance.CurrentFirebaseUser;

            RefreshToken();
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
                await page.DisplayAlert(
                    AppResources.SharedAlertAlert,
                    AppResources.NotesPageAlertTokenExpired,
                    AppResources.SharedAlertOk);
            }
        }
    }
}
