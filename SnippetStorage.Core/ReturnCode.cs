namespace SnippetStorage.Core
{
    /// <summary>
    /// Codes for indicating the result of Db transactions
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// Operation was successful
        /// </summary>
        Success,
        
        /// <summary>
        /// Operation Failed
        /// </summary>
        Failure,
        
        /// <summary>
        /// Attempted to store an existing name
        /// </summary>
        NameExists
    }
}