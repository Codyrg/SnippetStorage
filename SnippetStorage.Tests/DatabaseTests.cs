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
            var record = SnippetRecord.Create("test", "test1.txt");
            
            Database.Instance.CreateRecord(record);

            var records = Database.Instance.GetAllRecords<SnippetRecord>();
            
            Assert.NotEmpty(records);

            Database.Instance.DeleteRecord<SnippetRecord>(record);
            
            records = Database.Instance.GetAllRecords<SnippetRecord>();
            
            Assert.Empty(records);
        }

        /// <summary>
        /// Makes sure it is not possible to add records with redundant names
        /// </summary>
        [Fact]
        public void AddRedundantNameTest()
        {
            var record = SnippetRecord.Create("test", "test1.txt");
            Database.Instance.CreateRecord(record);
            Database.Instance.CreateRecord(record);
            
            var records = Database.Instance.GetAllRecords<SnippetRecord>();

            Assert.Single(records);
        }

        /// <summary>
        /// Tests the ability to retrieve all records
        /// </summary>
        [Fact]
        public void RetrieveAllRecordsTest()
        {
            var first = SnippetRecord.Create("test1", "test1.txt");
            var second = SnippetRecord.Create("test2", "test1.txt");
            var third = SnippetRecord.Create("test3", "test1.txt");
                
            Database.Instance.CreateRecord(first);
            Database.Instance.CreateRecord(second);
            Database.Instance.CreateRecord(third);

            var records = Database.Instance.GetAllRecords<SnippetRecord>();
            
            Assert.Equal(3, records.Count());
        }

        /// <summary>
        /// Tests the ability to update records
        /// </summary>
        [Fact]
        public void UpdateRecordTest()
        {
            var record = SnippetRecord.Create("test", "test1.txt");
            
            Database.Instance.CreateRecord(record);

            var before = Database.Instance.GetAllRecords<SnippetRecord>()
                .FirstOrDefault(x => x.Name == "test")
                ?.Content;
            
            Assert.Equal("123", before);

            record.Content = "xyz";
            
            Database.Instance.UpdateRecord(record);
            
            var after = Database.Instance.GetAllRecords<SnippetRecord>()
                .FirstOrDefault(x => x.Name == "test")
                ?.Content;
            
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