using EmojiCards.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EmojiCards.Interfaces
{
    public interface IDBFirebase
    {
        ObservableCollection<Note> GetNotesCollection(string username);
        Task AddNote(string username, string title, string description);
        Task UpdateNote(string username, string id, string title, string description);
        Task DeleteNote(string username, string id);
    }
}
