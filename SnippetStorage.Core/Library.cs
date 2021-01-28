namespace SnippetStorage.Core
{
    using System;
    using System.IO;

    /// <summary>
    /// SnippetStorage.Core Library
    /// </summary>
    public static class Library
    {
        private static readonly object InitLock = new object();
        private static bool _initialized;


        static Library()
        {
            
        }

        /// <summary>
        /// Path where internal database is stored
        /// </summary>
        public static string InternalDatabaseFolder { get; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Snippet Storage");
        
        /// <summary>
        /// File path of internal database
        /// </summary>
        public static string InternalDatabaseLocation { get; private set; } = Path.Combine(InternalDatabaseFolder, "snippets.db");
        
        /// <summary>
        /// Name of the collection that snippets are stored in
        /// </summary>
        public static string CollectionName { get; private set; } = "snippets";

        /// <summary>
        /// Initializes the snippet storage library
        /// </summary>
        /// <param name="alternateLocation">An alternate location for storing the database</param>
        /// <param name="alternateCollectionName">An alternate name for the collection to store documents in</param>
        public static void Init(string alternateLocation = null, string alternateCollectionName = null)
        {
            lock (InitLock)
            {
                if (_initialized)
                {
                    return;
                }

                if (alternateLocation != null)
                {
                    InternalDatabaseLocation = alternateLocation;
                }
                
                if (alternateCollectionName != null)
                {
                    CollectionName = alternateCollectionName;
                }
                
                _initialized = true;
            }
        }
    }
}