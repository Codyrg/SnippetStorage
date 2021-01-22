namespace SnippetStorage.Cli.Options
{
    using CommandLine;

    /// <summary>
    /// Options for the store command
    /// </summary>
    public class StoreOptions
    {
        /// <summary>
        /// Name of snippet to store
        /// </summary>
        [Option( 'n', "name", Required = true, HelpText = "Name of snippet to store")]
        public string Name { get; set; }
        
        /// <summary>
        /// Path of file to store
        /// </summary>
        [Option( 'p',"path", Required = true, HelpText = "Path of snippet to store")]
        public string Path { get; set; }
    }
}