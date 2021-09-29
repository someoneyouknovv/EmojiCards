using EmojiCards.Interfaces;
using EmojiCards.Models;
using EmojiCards.Resources;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.CommunityToolkit.Helpers;

namespace EmojiCards.Repository
{
    public class GamesRepository : IGamesRepository
    {
        public ObservableCollection<CardGameModel> CardsCollection;
        public ObservableCollection<GuessMeCardModel> GuessMeCardsCollection;
        public ObservableCollection<MemoryCardModel> MemoryCardsCollection;

        public ObservableCollection<CardGameModel> GetAllCards()
        {
            CardsCollection = new ObservableCollection<CardGameModel>
            {
                new CardGameModel
                {
                    ID = 1,
                    EmojiName = AppResources.SharedModelHappy,
                    ImageSource = "happy.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-happy.mp3" 
                    : "en-happy.mp3"
                },

                new CardGameModel
                {
                    ID = 2,
                    EmojiName = AppResources.SharedModelSad,
                    ImageSource = "sad.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-sad.mp3" 
                    : "en-sad.mp3"
                },

                new CardGameModel
                {
                    ID = 3,
                    EmojiName = AppResources.SharedModelSmiling,
                    ImageSource = "smiling.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-smiling.mp3" 
                    : "en-smiling.mp3"
                },

                new CardGameModel
                {
                    ID = 4,
                    EmojiName = AppResources.SharedModelCry,
                    ImageSource = "cry.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-cry.mp3" 
                    : "en-cry.mp3"

                },

                new CardGameModel
                {
                    ID = 5,
                    EmojiName = AppResources.SharedModelConfused,
                    ImageSource = "confused.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-confused.mp3" 
                    : "en-confused.mp3"
                },

                new CardGameModel
                {
                    ID = 6,
                    EmojiName = AppResources.SharedModelSurprised,
                    ImageSource = "surprised.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-surprised.mp3" 
                    : "en-surprised.mp3"
                },

                new CardGameModel
                {
                    ID = 7,
                    EmojiName = AppResources.SharedModelThirsty,
                    ImageSource = "thirsty.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-thirsty.mp3" 
                    : "en-thirsty.mp3"
                },

                new CardGameModel
                {
                    ID = 8,
                    EmojiName = AppResources.SharedModelHungry,
                    ImageSource = "hungry.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-hungry.mp3" 
                    : "en-hungry.mp3"
                },

                new CardGameModel
                {
                    ID = 9,
                    EmojiName = AppResources.SharedModelAngry,
                    ImageSource = "angry.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-angry.mp3" 
                    : "en-angry.mp3"
                },

                new CardGameModel
                {
                    ID = 10,
                    EmojiName = AppResources.SharedModelShy,
                    ImageSource = "shy.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk") 
                    ? "mk-shy.mp3" 
                    : "en-shy.mp3"
                }
            };
            return CardsCollection;
        }

        public ObservableCollection<GuessMeCardModel> GetAllGuessMeCards()
        {
            GuessMeCardsCollection = new ObservableCollection<GuessMeCardModel>
            {
                new GuessMeCardModel
                {
                    ID = 1,
                    EmojiName = AppResources.SharedModelHappy,
                    CorrectEmoji = "happy.png",
                    WrongEmoji = "sad.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-happy.mp3"
                    : "en-happy.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 2,
                    EmojiName = AppResources.SharedModelAngry,
                    CorrectEmoji = "angry.png",
                    WrongEmoji = "shy.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-angry.mp3"
                    : "en-angry.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 3,
                    EmojiName = AppResources.SharedModelConfused,
                    CorrectEmoji = "confused.png",
                    WrongEmoji = "smiling.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-confused.mp3"
                    : "en-confused.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 4,
                    EmojiName = AppResources.SharedModelCry,
                    CorrectEmoji = "cry.png",
                    WrongEmoji = "happy.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-cry.mp3"
                    : "en-cry.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 5,
                    EmojiName = AppResources.SharedModelHungry,
                    CorrectEmoji = "hungry.png",
                    WrongEmoji = "thirsty.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-hungry.mp3"
                    : "en-hungry.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 6,
                    EmojiName = AppResources.SharedModelSurprised,
                    CorrectEmoji = "surprised.png",
                    WrongEmoji = "hungry.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-surprised.mp3"
                    : "en-surprised.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 7,
                    EmojiName = AppResources.SharedModelThirsty,
                    CorrectEmoji = "thirsty.png",
                    WrongEmoji = "sad.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-thirsty.mp3"
                    : "en-thirsty.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 8,
                    EmojiName = AppResources.SharedModelSmiling,
                    CorrectEmoji = "smiling.png",
                    WrongEmoji = "cry.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-smiling.mp3"
                    : "en-smiling.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 9,
                    EmojiName = AppResources.SharedModelSad,
                    CorrectEmoji = "sad.png",
                    WrongEmoji = "smiling.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-sad.mp3"
                    : "en-sad.mp3"
                },
                new GuessMeCardModel
                {
                    ID = 10,
                    EmojiName = AppResources.SharedModelShy,
                    CorrectEmoji = "shy.png",
                    WrongEmoji = "thirsty.png",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-shy.mp3"
                    : "en-shy.mp3"
                }
            };
            return GuessMeCardsCollection;
        }

        public ObservableCollection<MemoryCardModel> GetAllMemoryCards()
        {
            MemoryCardsCollection = new ObservableCollection<MemoryCardModel>
            {
                new MemoryCardModel
                {
                    ID = 1,
                    EmojiName = AppResources.SharedModelHappy,
                    ImageSource1="hungry.png",
                    ImageSource2 ="cry.png",
                    ImageSource3 = "happy.png",
                    ImageSource4 = "sad.png",
                    CorrectImage="3",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-happy.mp3"
                    : "en-happy.mp3"
                },
                new MemoryCardModel
                {
                    ID = 2,
                    EmojiName = AppResources.SharedModelAngry,
                    ImageSource1="hungry.png",
                    ImageSource2 ="thirsty.png",
                    ImageSource3 = "happy.png",
                    ImageSource4 = "angry.png",
                    CorrectImage="4",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-angry.mp3"
                    : "en-angry.mp3"
                },
                new MemoryCardModel
                {
                    ID = 3,
                    EmojiName = AppResources.SharedModelConfused,
                    ImageSource1="hungry.png",
                    ImageSource2 ="confused.png",
                    ImageSource3 = "happy.png",
                    ImageSource4 = "sad.png",
                    CorrectImage="2",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-confused.mp3"
                    : "en-confused.mp3"
                },
                new MemoryCardModel
                {
                    ID = 4,
                    EmojiName = AppResources.SharedModelCry,
                    ImageSource1="hungry.png",
                    ImageSource2 ="cry.png",
                    ImageSource3 = "happy.png",
                    ImageSource4 = "shy.png",
                    CorrectImage="2",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-cry.mp3"
                    : "en-cry.mp3"
                },
                new MemoryCardModel
                {
                    ID = 5,
                    EmojiName = AppResources.SharedModelHungry,
                    ImageSource1="hungry.png",
                    ImageSource2 ="cry.png",
                    ImageSource3 = "shy.png",
                    ImageSource4 = "sad.png",
                    CorrectImage="1",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-hungry.mp3"
                    : "en-hungry.mp3"
                },
                new MemoryCardModel
                {
                    ID = 6,
                    EmojiName = AppResources.SharedModelSurprised,
                    ImageSource1="shy.png",
                    ImageSource2 ="cry.png",
                    ImageSource3 = "happy.png",
                    ImageSource4 = "surprised.png",
                    CorrectImage="4",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-surprised.mp3"
                    : "en-surprised.mp3"
                },
                new MemoryCardModel
                {
                    ID = 7,
                    EmojiName = AppResources.SharedModelThirsty,
                    ImageSource1="hungry.png",
                    ImageSource2 ="cry.png",
                    ImageSource3 = "thirsty.png",
                    ImageSource4 = "surprised.png",
                    CorrectImage="3",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-thirsty.mp3"
                    : "en-thirsty.mp3"
                },
                new MemoryCardModel
                {
                    ID = 8,
                    EmojiName = AppResources.SharedModelSmiling,
                    ImageSource1="hungry.png",
                    ImageSource2 ="thirsty.png",
                    ImageSource3 = "smiling.png",
                    ImageSource4 = "sad.png",
                    CorrectImage="3",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-smiling.mp3"
                    : "en-smiling.mp3"
                },
                new MemoryCardModel
                {
                    ID = 9,
                    EmojiName = AppResources.SharedModelSad,
                    ImageSource1="hungry.png",
                    ImageSource2 ="shy.png",
                    ImageSource3 = "happy.png",
                    ImageSource4 = "sad.png",
                    CorrectImage="4",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-sad.mp3"
                    : "en-sad.mp3"
                },
                new MemoryCardModel
                {
                    ID = 10,
                    EmojiName = AppResources.SharedModelShy,
                    ImageSource1="surprised.png",
                    ImageSource2 ="shy.png",
                    ImageSource3 = "happy.png",
                    ImageSource4 = "sad.png",
                    CorrectImage="2",
                    SoundSource = LocalizationResourceManager.Current.CurrentCulture.Name.Equals("mk")
                    ? "mk-shy.mp3"
                    : "en-shy.mp3"
                }
            };
            return MemoryCardsCollection;

        }
    }         
}
