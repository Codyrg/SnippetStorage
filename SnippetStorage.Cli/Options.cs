namespace SnippetStorage.Cli
{
    using System.Collections.Generic;
    using CommandLine;

    /// <summary>
    /// Class containing command line options as properties
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Name of snippet to perform an action on
        /// </summary>
        [Option( 'n', "name", Required = false, HelpText = "Name of snippet to perform action on")]
        public string Name { get; set; }
        
        /// <summary>
        /// Path of file to perform an action on
        /// </summary>
        [Option( 'p',"path", Required = false, HelpText = "Path of snippet")]
        public string Path { get; set; }
        
        /// <summary>
        /// Tags to assign a snippet
        /// </summary>
        [Option( 't',"tags", Required = false, HelpText = "Comma separated tags without spaces")]
        public IEnumerable<string> Tags { get; set; }
    }
}