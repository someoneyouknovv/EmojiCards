using EmojiCards.Resources;
using EmojiCards.Views;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmojiCards
{
    public partial class App : Application
    {
        public App()
        {
            LocalizationResourceManager.Current.PropertyChanged += (_, _)
                => AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

            //Device.SetFlags(new string[] { "MediaElement_Experimental" });
            InitializeComponent();
            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
