namespace SnippetStorage.Cli.Options
{
    using CommandLine;

    /// <summary>
    /// Options for the generate command
    /// </summary>
    public class GenerateOptions
    {
        /// <summary>
        /// Name of snippet to generate
        /// </summary>
        [Option( 'n', "name", Required = true, HelpText = "Name of snippet to generate")]
        public string Name { get; set; }
        
        /// <summary>
        /// Path of file to generate
        /// </summary>
        [Option( 'p',"path", Required = true, HelpText = "Path to generate snippet at")]
        public string Path { get; set; }
    }
}