using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Resources;
using System.Collections.ObjectModel;

namespace EmojiCards.Repository
{
    public class GamesRepository : IGamesRepository
    {
        public ObservableCollection<CardGameModel> CardsCollection;

        public ObservableCollection<CardGameModel> GetAllCards()
        {
            CardsCollection = new ObservableCollection<CardGameModel>
            {
                new CardGameModel
                {
                    ID = 1,
                    EmojiName = AppResources.SharedModelHappy,
                    ImageSource = "happy.png"
                },

                new CardGameModel
                {
                    ID = 2,
                    EmojiName = AppResources.SharedModelSad,
                    ImageSource = "sad.png"
                },

                new CardGameModel
                {
                    ID = 3,
                    EmojiName = AppResources.SharedModelSmiling,
                    ImageSource = "smiling.png"
                },

                new CardGameModel
                {
                    ID = 4,
                    EmojiName = AppResources.SharedModelCry,
                    ImageSource = "cry.png"

                },

                new CardGameModel
                {
                    ID = 5,
                    EmojiName = AppResources.SharedModelConfused,
                    ImageSource = "confused.png"
                },

                new CardGameModel
                {
                    ID = 6,
                    EmojiName = AppResources.SharedModelSurprised,
                    ImageSource = "surprised.png"
                },

                new CardGameModel
                {
                    ID = 7,
                    EmojiName = AppResources.SharedModelThirsty,
                    ImageSource = "thirsty.png"
                },

                new CardGameModel
                {
                    ID = 8,
                    EmojiName = AppResources.SharedModelHungry,
                    ImageSource = "hungry.png"
                },

                new CardGameModel
                {
                    ID = 9,
                    EmojiName = AppResources.SharedModelAngry,
                    ImageSource = "angry.png"
                },

                new CardGameModel
                {
                    ID = 10,
                    EmojiName = AppResources.SharedModelShy,
                    ImageSource = "shy.png"
                }
            };
            return CardsCollection;
        }      
    }         
}
