namespace SnippetStorage.Cli.Options
{
    using CommandLine;

    /// <summary>
    /// Options for the delete command
    /// </summary>
    public class DeleteOptions
    {
        /// <summary>
        /// Name of snippet to delete
        /// </summary>
        [Option( 'n', "name", Required = true, HelpText = "Name of snippet to delete")]
        public string Name { get; set; }
    }
}