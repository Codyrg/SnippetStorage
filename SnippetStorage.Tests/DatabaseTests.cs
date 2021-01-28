namespace SnippetStorage.Tests
{
    using System;
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
        public void AddRedundantName()
        {
            Database.Instance.CreateRecord(SnippetRecord.Create("test", "test1.txt"));
            Database.Instance.CreateRecord(SnippetRecord.Create("test", "test1.txt"));
            
            var records = Database.Instance.GetAllRecords();

            Assert.Single(records);
        }

        
        /// <inheritdoc/>
        public void Dispose()
        {
            Maintenance.CleanUpTestDb(DbLocation);
        }
    }
}