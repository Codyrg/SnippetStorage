namespace SnippetStorage.Cli
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CommandLine;
    using Core;
    using NLog;

    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Log.Error("No arguments supplied");
                return;
            }

            var remaining = args.Skip(1);
            
            
            Parser.Default.ParseArguments<Options>(remaining)
                .WithParsed(option =>
                {
                    
                    // peel off the primary command
                    switch (args[0])
                    {
                        case "store":
                            Store(option.Name, option.Path);
                            break;
                        case "list":
                            List();
                            break;
                        case "copy":
                            Copy(option.Name);
                            break;
                        case "generate":
                            Generate(option.Name, option.Path);
                            break;
                        case "delete":
                            Delete(option.Name);
                            break;
                        case "import":
                            Import(option.Name);
                            break;
                        case "export":
                            Export(option.Name);
                            break;
                        default:
                            Log.Error("Invalid primary option selected.");
                            break;
                    }
                });
        }

        /// <summary>
        /// Use to store a snippet, requires specifying Path option of snippet to store and a name to store it under
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        public static void Store(string name, string path)
        {
            Database.Instance.CreateRecord(SnippetRecord.Create(name, path));
        }
        
        /// <summary>
        /// Use to list data on a snippet, if no name is specified, data on all snippets will be listed
        /// </summary>
        public static void List()
        {
            // TODO: format in a nice looking table w/ size displayed, a description,
            // maybe a preview of the text
            Log.Info("List command selected . . .");
            var records = Database.Instance.GetAllRecords();

            foreach (var snippetRecord in records)
            {
                Log.Info(snippetRecord.Name);
            }
        }
        
        /// <summary>
        /// Use to copy the contents of a specified snippet name, requires specify Name option of snippet to copy
        /// </summary>
        /// <param name="name"></param>
        public static void Copy(string name)
        {
            // TODO: implement command for copying a snippet to the clipboard
            Log.Info("Copy command selected . . .");
        }
        
        /// <summary>
        /// Use to generate a file with the contents of a specified snippet name, requires specify Name option of snippet to copy
        /// and a path to a file in which the snippet should be generated in
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        public static void Generate(string name, string path)
        {
            Log.Info("Generate command selected . . .");
                        
            try
            {
                var snippet = Database.Instance.GetRecord(name);
                            
                File.WriteAllText(path, snippet.Content);
                            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        /// <summary>
        /// Use to delete a specified snippet by name
        /// </summary>
        /// <param name="name"></param>
        public static void Delete(string name)
        {
            Database.Instance.DeleteRecord(name);
        }
        
        /// <summary>
        /// Used to import a snippet config from a specified path
        /// </summary>
        /// <param name="path"></param>
        public static void Import(string path)
        {
            // TODO: implement commmand for importing SnippetStorage configuration
            Log.Info("Import command selected . . .");
        }
        
        /// <summary>
        /// Used to export a snippet config to a specified path
        /// </summary>
        /// <param name="path"></param>
        public static void Export(string path)
        {
            // TODO: implement command for exporting SnippetStorage configuration
            Log.Info("Export command selected . . .");
        }
    }
}