using EmojiCards.Models;
using EmojiCards.Resources;
using EmojiCards.Views;
using Firebase.Auth;
using Firebase.Database;
using Mobile.Portable;
using MvvmHelpers;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        public string WebApiKey = "AIzaSyA5ssBLbQEyIo9pDUBomOweQYAD9hyoL94";

        private FirebaseUser _firebaseUser = new FirebaseUser();
        public FirebaseUser FirebaseUser
        {
            get => _firebaseUser;
            set => SetProperty(ref _firebaseUser, value);
        }

        private ICommand _logInBtnClicked;
        public ICommand LogInBtnClicked => _logInBtnClicked ??= new DelegateCommand(OnLogInBtnClicked);

        private ICommand _signUpNavigationPageCommand;
        public ICommand SignUpNavigationPageCommand => _signUpNavigationPageCommand ??= new DelegateCommand(OnSignUpNavigationPageCommand);

        private ICommand _resetPasswordCommand;
        public ICommand ResetPasswordCommand => _resetPasswordCommand ??= new DelegateCommand(OnResetPasswordCommand);

        public LogInViewModel(Page page) : base(page)
        {
        }

        public async void OnLogInBtnClicked()
        {
            if (string.IsNullOrWhiteSpace(FirebaseUser.Username) || string.IsNullOrWhiteSpace(FirebaseUser.Password))
            {
                await page.DisplayAlert(AppResources.SharedAlertAlert, 
                    AppResources.SharedAlertFIllBlanks, 
                    AppResources.SharedAlertOk);
                return;
            }


            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(
                    FirebaseUser.Username, FirebaseUser.Password);
                var content = await auth.GetFreshAuthAsync();

                if (!content.User.IsEmailVerified)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.LogInPageAlertVerifyEmail,
                        AppResources.SharedAlertOk);
                    return;
                }
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedContent);
                Singleton.Instance.CurrentFirebaseUser = FirebaseUser;
                await page.Navigation.PushAsync(new NotesPage());
            }
            catch (FirebaseAuthException e)
            {
                if(e.Reason == AuthErrorReason.InvalidEmailAddress)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.LogInPageAlertInvalidCredentials,
                        AppResources.SharedAlertOk);
                }
                else if (e.Reason == AuthErrorReason.WrongPassword)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.LogInPageAlertWrongPassword,
                        AppResources.SharedAlertOk);
                }
                else if(e.Reason == AuthErrorReason.UnknownEmailAddress)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.SharedAlertUnknownEmail,
                        AppResources.SharedAlertOk);
                }
                else
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.SharedAlertSomethingWentWrong,
                        AppResources.SharedAlertOk);
                }
            }
        }

        public async void OnSignUpNavigationPageCommand()
        {
            await page.Navigation.PushAsync(new SignUpPage());
        }

        public async void OnResetPasswordCommand()
        {
            await page.Navigation.PushAsync(new ResetPasswordPage());
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            FirebaseUser.Username = "";
            FirebaseUser.Password = "";
            base.OnNavigatedTo(parameters);
        }

    }
}
