using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Unity;
using Prism.Commands;


namespace EmojiCards.ViewModels
{
    public class BaseViewModel : BindableBase, INavigatedAware
    {
        protected INavigation PageNavigation { get; }

        internal Page page;

        public BaseViewModel(Page page)
        {
            this.page = page;
            PageNavigation = page.Navigation;

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        { 
        }
    }
}

