namespace SnippetStorage.Core
{
    /// <summary>
    /// Profile containing a user's snippets
    /// </summary>
    public class ProfileRecord : IRecord
    {
        /// <summary>
        /// Creates a Profile
        /// </summary>
        /// <param name="name"></param>
        public ProfileRecord(string name)
        {
            Name = name;
        }
        
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Name of user's profile
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Name of snippet collection where the user's snippers are stored
        /// </summary>
        public string SnippetCollectionName => $"{Name}_snippets";
    }
}