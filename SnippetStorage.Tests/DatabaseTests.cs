namespace SnippetStorage.Tests
{
    using System;
    using System.Linq;
    using Core;
    using Xunit;
    
    /// <summary>
    /// Tests for basic database operations
    /// </summary>
    public class DatabaseTests : IDisposable
    {
        
        /// <summary>
        /// Location of the database used for testing
        /// </summary>
        public string DbLocation { get; }
        
        /// <summary>
        /// Sets up a test database
        /// </summary>
        public DatabaseTests()
        {
            // TODO: Remove test files and generate at runtime
            DbLocation = Maintenance.GenerateTestDb();
        }
        
        /// <summary>
        /// Tests the create and delete database methods
        /// </summary>
        [Fact]
        public void AddAndRemoveTest()
        {
            Database.Instance.CreateRecord(SnippetRecord.Create("test", "test1.txt"));

            var records = Database.Instance.GetAllRecords();
            
            Assert.NotEmpty(records);

            Database.Instance.DeleteRecord("test");
            
            records = Database.Instance.GetAllRecords();
            
            Assert.Empty(records);
        }

        /// <summary>
        /// Makes sure it is not possible to add records with redundant names
        /// </summary>
        [Fact]
        public void AddRedundantNameTest()
        {
            Database.Instance.CreateRecord(SnippetRecord.Create("test", "test1.txt"));
            Database.Instance.CreateRecord(SnippetRecord.Create("test", "test1.txt"));
            
            var records = Database.Instance.GetAllRecords();

            Assert.Single(records);
        }

        /// <summary>
        /// Tests the ability to retrieve all records
        /// </summary>
        [Fact]
        public void RetrieveAllRecordsTest()
        {
            Database.Instance.CreateRecord(SnippetRecord.Create("test1", "test1.txt"));
            Database.Instance.CreateRecord(SnippetRecord.Create("test2", "test1.txt"));
            Database.Instance.CreateRecord(SnippetRecord.Create("test3", "test1.txt"));

            var records = Database.Instance.GetAllRecords();
            
            Assert.Equal(3, records.Count());
        }

        /// <summary>
        /// Tests the ability to update records
        /// </summary>
        [Fact]
        public void UpdateRecordTest()
        {
            Database.Instance.CreateRecord(SnippetRecord.Create("test", "test1.txt"));

            var before = Database.Instance.GetRecord("test")?.Content;
            
            Assert.Equal("123", before);

            Database.Instance.UpdateRecord(SnippetRecord.Create("test", "test2.txt"));
            
            var after = Database.Instance.GetRecord("test")?.Content;
            
            Assert.Equal("xyz", after);

        }
        
        // TODO: test to limit storage size
        // TODO: test to limit number of records

        /// <inheritdoc/>
        public void Dispose()
        {
            Maintenance.CleanUpTestDb(DbLocation);
        }
    }
}