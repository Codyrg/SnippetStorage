namespace SnippetStorage.Cli.Options
{
    using CommandLine;

    /// <summary>
    /// Options for the copy command
    /// </summary>
    public class CopyOptions
    {
        /// <summary>
        /// Name of snippet to copy to the clipboard
        /// </summary>
        [Option( 'n', "name", Required = true, HelpText = "Name of snippet to copy to clipboard")]
        public string Name { get; set; }
    }
}