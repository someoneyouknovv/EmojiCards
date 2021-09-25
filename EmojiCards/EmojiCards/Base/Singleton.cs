

using EmojiCards.Models;

namespace Mobile.Portable
{
    public sealed class Singleton
    {
        private static volatile Singleton instance;
        private static readonly object syncRoot = new object();
        
        public FirebaseUser CurrentFirebaseUser { get; set; }
        public Note CurrentNote { get; set; }

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }
    }
}