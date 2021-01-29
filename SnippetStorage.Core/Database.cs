namespace SnippetStorage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Schema;
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
        }
        
        /// <summary>
        /// Adds the provided record to the database
        /// </summary>
        /// <param name="record">the record to add to the database</param>
        /// /// <typeparam name="T">Table to create record in</typeparam>
        /// <returns></returns>
        public ReturnCode CreateRecord<T>(T record) where T : IRecord
        {
            Log.Info("Creating record . . .");

            try
            {
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);
                
                var collection = db.GetCollection<T>();

                collection.Insert(record);
                
                return ReturnCode.Success;
            }
            catch (Exception e)
            {
                Log.Error("Attempt to insert record failed . . .");

                return ReturnCode.Failure;
            }
        }
        
        /// <summary>
        /// Updates a record in the collection with a name matching that of
        /// the parameter record
        /// </summary>
        /// <param name="record">Record to update in collection</param>
        /// /// <typeparam name="T">Table of record to update</typeparam>
        /// <returns></returns>
        public ReturnCode UpdateRecord<T>(T record) where T : IRecord
        {
            Log.Info("Updating record . . .");

            try
            {
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);
                
                var collection = db.GetCollection<T>();

                collection.Update(record.Id, record);
                
                return ReturnCode.Success;
            }
            catch (Exception e)
            {
                Log.Error("Attempt to update record failed . . .");

                return ReturnCode.Failure;
            }
        }
        
       /// <summary>
       /// Delete a record with a provided name
       /// </summary>
       /// <param name="record">Record to delete from db</param>
       /// <typeparam name="T">Table to look for record in</typeparam>
       /// <returns></returns>
        public ReturnCode DeleteRecord<T>(IRecord record) where T : IRecord
        {
            Log.Info("Deleting record . . .");
            
            try
            {
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);

                var collection = db.GetCollection<T>();

                var result = collection.Delete(record.Id);

                return result ? ReturnCode.Success : ReturnCode.Failure;
            }
            catch (Exception e)
            {
                Log.Error("Attempt to delete record failed . . .");
                
                return ReturnCode.Failure;
            }
        }

        /// <summary>
        /// Retrieve all records from the collection of type T
        /// </summary>
        /// <typeparam name="T">Type of collection to retrieve records for</typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAllRecords<T>() where T : IRecord
        {
            Log.Info("Getting records . . .");
            
            try
            {
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);

                var collection = db.GetCollection<T>();

                var records = collection.Query();
                
                return records.ToList();
            }
            catch (Exception e)
            {
                Log.Error("Attempt to retrieve records failed . . .");
                
                return null;
            }
        }
    }
}