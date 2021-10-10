using EmojiCards.Models;
using EmojiCards.Resources;
using Firebase.Auth;
using Prism.Commands;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public string WebApiKey = "AIzaSyA5ssBLbQEyIo9pDUBomOweQYAD9hyoL94";

        private FirebaseUser _firebaseUser = new FirebaseUser();
        public FirebaseUser FirebaseUser
        {
            get => _firebaseUser;
            set => SetProperty(ref _firebaseUser, value);
        }

        private ICommand _signUpBtnClicked;
        public ICommand SignUpBtnClicked => _signUpBtnClicked ??= new DelegateCommand(OnSignUpBtnClicked);

        public SignUpViewModel(Page page) : base(page)
        {
        }

        public async void OnSignUpBtnClicked()
        {
            if(string.IsNullOrWhiteSpace(FirebaseUser.Username) || string.IsNullOrWhiteSpace(FirebaseUser.Password))
            {
                await page.DisplayAlert(
                    AppResources.SharedAlertAlert, 
                    AppResources.SharedAlertFIllBlanks, 
                    AppResources.SharedAlertOk);

                return;
            }
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(
                    FirebaseUser.Username, FirebaseUser.Password);
                string getToken = auth.FirebaseToken;
                await page.DisplayAlert(AppResources.SharedAlertAlert, 
                    AppResources.SharedAlertRegistrationSucceeded, 
                    AppResources.SharedAlertOk);

                await authProvider.SendEmailVerificationAsync(getToken);

                await page.Navigation.PopAsync();
            }
            catch (FirebaseAuthException e)
            {
                if (e.Reason == AuthErrorReason.InvalidEmailAddress)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                          AppResources.SignUpPageAlertInvalidCredentials,
                          AppResources.SharedAlertOk);
                }
                else if(e.Reason == AuthErrorReason.EmailExists)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.SignUpPageAlertEmailExists,
                        AppResources.SharedAlertOk);
                }
                else if(e.Reason == AuthErrorReason.WeakPassword)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.SignUpPageAlertWeakPassword,
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
    }
}
