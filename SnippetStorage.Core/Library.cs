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
        /// File name of internal database
        /// File name of internal database
        /// </summary>
        public static string InternalDatabaseName { get; private set; } = "snippets.db";
        
        /// <summary>
        /// File path of internal database
        /// </summary>
        public static string InternalDatabaseLocation => Path.Combine(InternalDatabaseFolder, InternalDatabaseName);

        /// <summary>
        /// Initializes the snippet storage library
        /// </summary>
        /// <param name="alternateDbName">An alternate location for storing the database</param>
        public static void Init(string alternateDbName = null)
        {
            lock (InitLock)
            {
                if (_initialized)
                {
                    return;
                }

                if (alternateDbName != null)
                {
                    InternalDatabaseName = alternateDbName;
                }

                _initialized = true;
            }
        }
    }
}