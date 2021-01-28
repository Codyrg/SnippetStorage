﻿namespace SnippetStorage.Core
{
    using System;
    using System.Collections.Generic;
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
        /// <returns></returns>
        public ReturnCode CreateRecord(SnippetRecord record)
        {
            Log.Info("Creating record . . .");
            // TODO: enforce unique name insertions/overwrite
            try
            {
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);
                
                var collection = db.GetCollection<SnippetRecord>(Library.CollectionName);
                
                var result = collection.Insert(record);
                
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
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);

                var collection = db.GetCollection<SnippetRecord>(Library.CollectionName);

                var toRemove = collection.Query()
                    .Where(x => x.Name == name);

                var result = collection.Delete(toRemove.First().Id);

                return result ? ReturnCode.Success : ReturnCode.Failure;
            }
            catch (Exception e)
            {
                return ReturnCode.Failure;
            }
        }

        /// <summary>
        /// Returns a SnippetRecord with a name equal to the input parameter
        /// </summary>
        /// <param name="name">the name of the record to retrieve</param>
        /// <returns></returns>
       public SnippetRecord GetRecord(string name)
        {
            try
            {
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);

                var collection = db.GetCollection<SnippetRecord>(Library.CollectionName);

                var record = collection.Query()
                    .Where(x => x.Name == name);

                var result = record.FirstOrDefault();

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieve all records from the snippets collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SnippetRecord> GetAllRecords()
        {
            try
            {
                using var db = new LiteDatabase(Library.InternalDatabaseLocation);

                var collection = db.GetCollection<SnippetRecord>(Library.CollectionName);

                var records = collection.Query();
                
                return records.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}