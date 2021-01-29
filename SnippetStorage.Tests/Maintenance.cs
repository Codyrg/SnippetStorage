namespace SnippetStorage.Tests
{
    using System;
    using System.IO;
    using Core;

    /// <summary>
    /// Utility class for Testing
    /// </summary>
    public static class Maintenance
    {
        /// <summary>
        /// Generates a test database
        /// </summary>
        /// <returns>Location of the test database</returns>
        public static string GenerateTestDb()
        {
            var name = Path.GetRandomFileName();
            var collection = "test";
            
            Library.Init(name);

            return Library.InternalDatabaseLocation;
        }

        /// <summary>
        /// Deletes the test database at the provided path
        /// </summary>
        /// <param name="dbPath">the path of the database to clean up</param>
        public static void CleanUpTestDb(string dbPath)
        {
            File.Delete(dbPath);
        }
    }
}