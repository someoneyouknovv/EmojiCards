using EmojiCards.Views;
using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private ICommand _continueBtnTappedCommand;
        public ICommand ContinueBtnTappedCommand => _continueBtnTappedCommand ??= new DelegateCommand(OnContinueBtnTappedCommand);

        private ICommand _changeLangBtnTappedCommand;
        public ICommand ChangeLangBtnTappedCommand => _changeLangBtnTappedCommand ??= new DelegateCommand(OnChangeLangBtnTappedCommand);

        public WelcomeViewModel(Page page) : base(page)
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
