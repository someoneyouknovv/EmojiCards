using EmojiCards.Views;
using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class GamesMenuViewModel : BaseViewModel
    {
        private ICommand _soundCardsBtnCommand;
        public ICommand SoundCardsBtnCommand => _soundCardsBtnCommand ??= new DelegateCommand(OnSoundCardsBtnTappedCommand);

        private ICommand _flashCardsBtnCommand;
        public ICommand FlashCardsBtnCommand => _flashCardsBtnCommand ??= new DelegateCommand(OnFlashCardsBtnTappedCommand);

        private ICommand _guessMeBtnCommand;
        public ICommand GuessMeBtnCommand => _guessMeBtnCommand ??= new DelegateCommand(OnGuessMeBtnTappedCommand);

        public GamesMenuViewModel(Page page) : base(page)
        {
        }

        public async void OnSoundCardsBtnTappedCommand()
        {
            await page.Navigation.PushAsync(new SoundCardsGamePage());
        }

        public async void OnFlashCardsBtnTappedCommand()
        {
            await page.Navigation.PushAsync(new FlashCardsGamePage());
        }

        public async void OnGuessMeBtnTappedCommand()
        {
            await page.Navigation.PushAsync(new GuessMeGamePage());
        }
    }
}
