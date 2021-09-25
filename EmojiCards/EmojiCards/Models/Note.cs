using Prism.Mvvm;
using System;

namespace EmojiCards.Models
{
    public class Note : BindableBase
    {
        private string _id;
        public string ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}
