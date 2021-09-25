using EmojiCards.Models;
using System.Collections.Generic;

namespace EmojiCards.Interfaces
{
    public interface IGamesRepository
    {
        List<SoundCardsGameModel> GetAllSoundCards();
    }
}
