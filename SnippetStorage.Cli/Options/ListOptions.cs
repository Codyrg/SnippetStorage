namespace SnippetStorage.Cli.Options
{
    using CommandLine;

    /// <summary>
    /// Options for the list command
    /// </summary>
    public class ListOptions
    {
        /// <summary>
        /// Name of a specific snippet to list
        /// </summary>
        [Option( 'n', "name", Required = false, HelpText = "Name of a specific snippet to list")]
        public string Name { get; set; }
    }
}