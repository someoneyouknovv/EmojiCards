using EmojiCards.Interfaces;
using EmojiCards.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmojiCards.Services
{
    public class DBFirebase : IDBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://emojicardsmobilexf-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<Note> GetNotesCollection(string username)
        {
            var user = GetFormattedUsername(username);

            var getNotes = client
                .Child(user)
                .AsObservable<Note>()
                .AsObservableCollection();
            return getNotes;
        }

        public async Task AddNote(string username, string title, string description)
        {
            var user = GetFormattedUsername(username);
            Note newNote = new Note()
            {
                ID = Guid.NewGuid().ToString(),
                Title = title,
                Description = description
            };
            await client.Child(user).PostAsync(newNote);
        }

        public async Task UpdateNote(string username, string id, string title, string description)
        {
            var user = GetFormattedUsername(username);

            var updateNote = (await client
                .Child(user)
                .OnceAsync<Note>())
                .FirstOrDefault(n => n.Object.ID == id );

            Note newNote = new Note()
            {
                Title = title,
                Description = description,
            };
            await client
                .Child(user)
                .Child(updateNote.Key)
                .PutAsync(newNote);

        }

        public async Task DeleteNote(string username, string id)
        {
            var user = GetFormattedUsername(username);

            var deleteNote = (await client
                .Child(user)
                .OnceAsync<Note>())
                .FirstOrDefault(n => n.Object.ID == id);
            await client
                .Child(user).Child(deleteNote.Key)
                .DeleteAsync();
        }

        public string GetFormattedUsername(string username)
        {
            MailAddress adr = new MailAddress(username);
            var user = adr.User + adr.Host.Substring(0, adr.Host.Length - 4);

            return user;
        }
    }
}
