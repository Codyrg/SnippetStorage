namespace SnippetStorage.Core
{
    using System;
    using System.IO;
    using LiteDB;
    using NLog;

    /// <summary>
    /// Singleton for providing LiteDb access
    /// </summary>
    public class Database
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        
        private static Database _instance;
        private static readonly object Mutex = new object();

        /// <summary>
        /// Path where internal database is stored
        /// </summary>
        public static string InternalDatabaseFolder { get; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Snippet Storage");
        
        /// <summary>
        /// File path of internal database
        /// </summary>
        public static string InternalDatabaseLocation { get; } = Path.Combine(InternalDatabaseFolder, "snippets.db");

        /// <summary>
        /// Name of the collection that snippets are stored in
        /// </summary>
        public static string CollectionName { get; } = "snippets";
        
        /// <summary>
        /// Returns database instancee
        /// </summary>
        public static Database Instance
        {
            get
            {
                lock (Mutex)
                {
                    if (_instance is null)
                    {
                        Instance = new Database();
                    }

                    return _instance;
                }
            }
            
            private set
            {
                lock (Mutex)
                {
                    _instance = value;
                }
            }
        }
        
        private Database()
        {
            Log.Info($"InternalDatabaseLocation={InternalDatabaseLocation}");
        }
        
        /// <summary>
        /// Adds the provided record to the database
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public ReturnCode CreateRecord(SnippetRecord record)
        {
            Log.Info("Creating record . . .");
            // TODO: enforce unique name insertions/overwrite
            try
            {
                using var db = new LiteDatabase(InternalDatabaseLocation);
                
                var collection = db.GetCollection<SnippetRecord>(CollectionName);
                
                collection.Insert(record);
                
                var result = db.Commit();

                return ReturnCode.Success;
            }
            catch (Exception e)
            {
                Log.Error("Attempt to insert record failed . . .");

                return ReturnCode.Failure;
            }
        }
        
       /// <summary>
       /// Delete a record with a provided name
       /// </summary>
       /// <param name="name">name of the record to delete</param>
       /// <returns></returns>
        public ReturnCode DeleteRecord(string name)
        {
            try
            {
                using var db = new LiteDatabase(InternalDatabaseLocation);

                var collection = db.GetCollection<SnippetRecord>(CollectionName);

                var record = collection.Query()
                    .Where(x => x.Name == name)
                    .GetPlan();

                collection.Delete(record);

                return ReturnCode.Success;
            }
            catch (Exception e)
            {
                return ReturnCode.Failure;
            }
        }

        // TODO: read a single record
        
        // TODO: read all records
    }
}