using EmojiCards.Views;
using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        private ICommand _gamesBtnTappedCommand;
        public ICommand GamesBtnTappedCommand => _gamesBtnTappedCommand ??= new DelegateCommand(OnGamesBtnTappedCommand);

        private ICommand _notesBtnTappedCommand;
        public ICommand NotesBtnTappedCommand => _notesBtnTappedCommand ??= new DelegateCommand(OnNotesBtnTappedCommand);

        private ICommand _aboutBtnTappedCommand;
        public ICommand AboutBtnTappedCommand => _aboutBtnTappedCommand ??= new DelegateCommand(OnAboutBtnTappedCommand);

        public MenuPageViewModel(Page page) : base(page)
        {
        }

        public async void OnGamesBtnTappedCommand()
        {
            await page.Navigation.PushAsync(new GamesMenuPage());
        }

        public async void OnNotesBtnTappedCommand()
        {
            await page.Navigation.PushAsync(new LogInPage());
        }

        public void OnAboutBtnTappedCommand()
        {

        }
    }
}
