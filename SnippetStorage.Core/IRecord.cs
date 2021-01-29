namespace SnippetStorage.Core
{
    /// <summary>
    /// Defines a record stored in a collection
    /// </summary>
    public interface IRecord
    {
        /// <summary>
        /// Id of record
        /// </summary>
        public int Id { get; set; }
    }
}