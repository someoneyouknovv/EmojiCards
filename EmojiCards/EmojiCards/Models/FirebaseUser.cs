using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmojiCards.Models
{
    public class FirebaseUser : BindableBase
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
    }
}
