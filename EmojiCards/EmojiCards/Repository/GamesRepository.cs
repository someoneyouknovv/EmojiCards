using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Resources;
using System.Collections.Generic;

namespace EmojiCards.Repository
{
    public class GamesRepository : IGamesRepository
    {
        public List<SoundCardsGameModel> SoundCardsCollection;

        public List<SoundCardsGameModel> GetAllSoundCards()
        {
            SoundCardsCollection = new List<SoundCardsGameModel>
            {
                new SoundCardsGameModel
                {
                    ID = 1,
                    EmojiName = AppResources.SharedModelHappy,
                    ImageSource = "happy.png"
                },

                new SoundCardsGameModel
                {
                    ID = 2,
                    EmojiName = AppResources.SharedModelSad,
                    ImageSource = "sad.png"
                },

                new SoundCardsGameModel
                {
                    ID = 3,
                    EmojiName = AppResources.SharedModelSmiling,
                    ImageSource = "smiling.png"
                },

                new SoundCardsGameModel
                {
                    ID = 4,
                    EmojiName = AppResources.SharedModelCry,
                    ImageSource = "crying.png"

                },

                new SoundCardsGameModel
                {
                    ID = 5,
                    EmojiName = AppResources.SharedModelConfused,
                    ImageSource = "confused.png"
                },

                new SoundCardsGameModel
                {
                    ID = 6,
                    EmojiName = AppResources.SharedModelSurprised,
                    ImageSource = "surprised.png"
                },

                new SoundCardsGameModel
                {
                    ID = 7,
                    EmojiName = AppResources.SharedModelThirsty,
                    ImageSource = "thirsty.png"
                },

                new SoundCardsGameModel
                {
                    ID = 8,
                    EmojiName = AppResources.SharedModelHungry,
                    ImageSource = "hungry.png"
                },

                new SoundCardsGameModel
                {
                    ID = 9,
                    EmojiName = AppResources.SharedModelAngry,
                    ImageSource = "angry.png"
                },

                new SoundCardsGameModel
                {
                    ID = 10,
                    EmojiName = AppResources.SharedModelShy,
                    ImageSource = "shy.png"
                }
            };
            return SoundCardsCollection;
        }
            
    }         
}
