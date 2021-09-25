using Prism.Mvvm;

namespace EmojiCards.Models
{
    public class MyLanguage : BindableBase
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _ci;
        public string CI
        {
            get => _ci;
            set => SetProperty(ref _ci, value);
        }

        public MyLanguage(string name, string ci)
        {
            Name = name;
            CI = ci;
        }
    }
}
