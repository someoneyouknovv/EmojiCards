using EmojiCards.Models;
using System.Collections.ObjectModel;

namespace EmojiCards.Interfaces
{
    public interface IGamesRepository
    {
        ObservableCollection<CardGameModel> GetAllCards();

        ObservableCollection<GuessMeCardModel> GetAllGuessMeCards();

    }
}
