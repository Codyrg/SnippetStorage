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
        /// Use to store a snippet, requires specifying Path option of snippet to store and a name to store it under
        /// </summary>
        [Option( "store", Required = false, HelpText = "Store a snippet at a provided path (-p) under name (-n)")]
        public bool Store { get; set; }
        
        /// <summary>
        /// Use to list data on all presently stored snippets
        /// </summary>
        [Option( "list", Required = false, HelpText = "List all snippets presently stored")]
        public bool List { get; set; }
        
        /// <summary>
        /// Use to show the contents of a specified snippet name, requires specify Name option of snippet to show
        /// </summary>
        [Option( "show", Required = false, HelpText = "Show a particular snippet; requires a name (-n)")]
        public bool Show { get; set; }
        
        /// <summary>
        /// Use to copy the contents of a specified snippet name, requires specify Name option of snippet to copy
        /// </summary>
        [Option( "copy", Required = false, HelpText = "Copy a named (-n) snippet to the clipboard")]
        public bool Copy { get; set; }
        
        /// <summary>
        /// Use to generate a file with the contents of a specified snippet name, requires specify Name option of snippet to copy
        /// and a path to a file in which the snippet should be generated in
        /// </summary>
        [Option( "generate", Required = false, HelpText = "Generates the named snippet in the provided path (-p)")]
        public bool Generate { get; set; }
        
        /// <summary>
        /// Use to delete a specified snippet by name
        /// </summary>
        [Option( "delete", Required = false, HelpText = "Delete a snippet, requires name (-n) of snippet to delete")]
        public bool Delete { get; set; }
        
        /// <summary>
        /// Used to export a snippet config to a specified path
        /// </summary>
        [Option( "export", Required = false, HelpText = "Export a snippet storage config file, requires path (-p) for where to store exported file")]
        public bool Export { get; set; }
        
        /// <summary>
        /// Used to import a snippet config from a specified path
        /// </summary>
        [Option( "import", Required = false, HelpText = "Import a snippet config from file, requires a path (-p) to the config file to import")]
        public bool Import { get; set; }

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