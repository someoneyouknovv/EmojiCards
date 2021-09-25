using EmojiCards.Models;
using EmojiCards.Resources;
using EmojiCards.Services;
using EmojiCards.Views;
using Firebase.Auth;
using Mobile.Portable;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class NotesPageViewModel : BaseViewModel
    {
        private DBFirebase _services;
        public string WebApiKey = "AIzaSyA5ssBLbQEyIo9pDUBomOweQYAD9hyoL94";

        private FirebaseUser _currentFirebaseUser = new FirebaseUser();
        public FirebaseUser CurrentFirebaseUser
        {
            get => _currentFirebaseUser;
            set => SetProperty(ref _currentFirebaseUser, value);
        }

        private ObservableCollection<Note> _notesCollection = new ObservableCollection<Note>();
        public ObservableCollection<Note> NotesCollection
        {
            get => _notesCollection;
            set => SetProperty(ref _notesCollection, value);
        }

        private ICommand _logOutBtnClicked;
        public ICommand LogOutBtnClicked => _logOutBtnClicked ??= new DelegateCommand(OnLogOutBtnClicked);

        private ICommand _singleNoteTappedCommand;
        public ICommand SingleNoteTappedCommand => _singleNoteTappedCommand ??= new DelegateCommand<object>(OnSingleNoteTappedCommand);

        private ICommand _addNoteBtnTappedCommand;
        public ICommand AddNoteBtnTappedCommand => _addNoteBtnTappedCommand ??= new DelegateCommand(OnAddNoteBtnTappedCommand);

        public NotesPageViewModel(Page page) : base(page)
        {
            _services = new DBFirebase();
        }

        public async void OnLogOutBtnClicked()
        {
            var answer = await page.DisplayAlert
                (AppResources.SharedAlertAlert,
                AppResources.NotesPageAlertSureToLogOut,
                AppResources.SharedAlertYes,
                AppResources.SharedAlertNo);

            if (!answer)
                return;
            Preferences.Remove("MyFirebaseRefreshToken");
            await page.Navigation.PopAsync();
        }

        public async void OnSingleNoteTappedCommand(object itemTapped)
        {
            var currNote = itemTapped as Note;
            Singleton.Instance.CurrentNote = currNote;
            Singleton.Instance.CurrentFirebaseUser = CurrentFirebaseUser;
            await page.Navigation.PushAsync(new NoteDetailsPage());
        }

        public async void OnAddNoteBtnTappedCommand()
        {
            Singleton.Instance.CurrentFirebaseUser = CurrentFirebaseUser;
            await page.Navigation.PushAsync(new AddNewNotePage());
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            CurrentFirebaseUser = Singleton.Instance.CurrentFirebaseUser;

            RefreshToken();
            NotesCollection.Clear();
            NotesCollection = _services.GetNotesCollection(CurrentFirebaseUser.Username);
        }

        public async void RefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var savedFirebaseAuth = JsonConvert.DeserializeObject<FirebaseAuth>
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
