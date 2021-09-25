using EmojiCards.Resources;
using Firebase.Auth;
using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        public string WebApiKey = "AIzaSyA5ssBLbQEyIo9pDUBomOweQYAD9hyoL94";

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private ICommand _resetPasswordCommand;
        public ICommand ResetPasswordBtnCommand => _resetPasswordCommand ??= new DelegateCommand(OnResetPasswordBtnCommand);
        public ResetPasswordViewModel(Page page) : base(page)
        {
        }

        public async void OnResetPasswordBtnCommand()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                await authProvider.SendPasswordResetEmailAsync(Email);

                await page.DisplayAlert(AppResources.SharedAlertAlert,
                    AppResources.ResetPasswordPageAlertCheckEmail,
                    AppResources.SharedAlertOk);

                await page.Navigation.PopAsync();
            }
            catch(FirebaseAuthException e)
            {
                if(e.Reason == AuthErrorReason.MissingEmail)
                {
                    await page.DisplayAlert(AppResources.SharedAlertAlert,
                        AppResources.SharedAlertFIllBlanks,
                        AppResources.SharedAlertOk);
                    return;
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
    }
}
