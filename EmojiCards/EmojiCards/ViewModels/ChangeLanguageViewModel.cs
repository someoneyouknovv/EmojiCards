using EmojiCards.Models;
using EmojiCards.Resources;
using EmojiCards.Views;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace EmojiCards.ViewModels
{
    public class ChangeLanguageViewModel : BaseViewModel
    {
        private ObservableCollection<MyLanguage> _langNames = new ObservableCollection<MyLanguage>();
        public ObservableCollection<MyLanguage> LangNames
        {
            get => _langNames;
            set => SetProperty(ref _langNames, value);
        }

        private MyLanguage _selectedLang;
        public MyLanguage SelectedLanguage
        {
            get => _selectedLang;
            set => SetProperty(ref _selectedLang, value);
        }

        private ICommand _langSelectedCommand;
        public ICommand LangSelectedCommand => _langSelectedCommand ??= new DelegateCommand<object>(OnLangSelectedCommand);

        private ICommand _onUpdateLangugeBtnClicked;
        public ICommand UpdateLangugeBtnClicked => _onUpdateLangugeBtnClicked ??= new DelegateCommand(OnUpdateLangugeBtnClicked);

        public ChangeLanguageViewModel(Page page) : base(page)
        {
            MyLanguage en = new MyLanguage("English", "en");
            LangNames.Add(en);
            MyLanguage mkd = new MyLanguage("Macedonian", "mk");
            LangNames.Add(mkd);

            //SelectedLanguage = LangNames.FirstOrDefault(pro => pro.CI == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
        }

        public void OnLangSelectedCommand(object obj)
        {
            var selectedLang = obj as MyLanguage;
            LocalizationResourceManager.Current.SetCulture(CultureInfo.GetCultureInfo(selectedLang.CI));
        }

        public async void OnUpdateLangugeBtnClicked()
        {
            //CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture | CultureTypes.SpecificCultures);
            //var getLanguage = System.Globalization.CultureInfo.CurrentCulture.Name;
            await page.Navigation.PopAsync();
        }
    }
}
