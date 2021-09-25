using EmojiCards.Resources;
using EmojiCards.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class WelcomePageViewModel : BaseViewModel
    {
        private ICommand _continueBtnTappedCommand;
        public ICommand ContinueBtnTappedCommand => _continueBtnTappedCommand ??= new DelegateCommand(OnContinueBtnTappedCommand);

        private ICommand _changeLangBtnTappedCommand;
        public ICommand ChangeLangBtnTappedCommand => _changeLangBtnTappedCommand ??= new DelegateCommand(OnChangeLangBtnTappedCommand);

        public WelcomePageViewModel(Page page) : base(page)
        {
        }
        public async void OnContinueBtnTappedCommand()
        {
            await page.Navigation.PushAsync(new MenuPage());
        }

        public async void OnChangeLangBtnTappedCommand()
        {
            await page.Navigation.PushAsync(new ChangeLanguagePage());
        }

    }
}
