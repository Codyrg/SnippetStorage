namespace SnippetStorage.Cli
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CommandLine;
    using Core;
    using NLog;
    using Options;

    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            if (args is null || args.Length == 0)
            {
                return;
            }
            
            var subOptions = args.Skip(1);
            
            // peel off the primary command
            switch (args[0])
            {
                    case "store":
                        Store(subOptions);
                        break;
                    case "list":
                        List(subOptions);
                        break;
                    case "copy":
                        break;
                    case "generate":
                        break;
                    case "delete":
                    break;
                default:
                    Log.Error("Invalid primary option selected.");
                    Log.Error("Please supply one of the following primary arguments:\n" +
                             "store\n" +
                             "list\n" +
                             "copy\n" +
                             "generate\n" +
                             "delete\n" +
                             "import\n" +
                             "export");
                    break;
            }
        }

        /// <summary>
        /// Use to store a snippet, requires specifying Path option of snippet to store and a name to store it under
        /// </summary>
        /// <param name="args">sub command arguments</param>
        public static void Store(IEnumerable<string> args)
        {
            Parser.Default.ParseArguments<StoreOptions>(args)
                .WithParsed(option =>
                {
                    Database.Instance.CreateRecord(SnippetRecord.Create(option.Name, option.Path));
                });
        }
        
        /// <summary>
        /// Use to list data on a snippet, if no name is specified, data on all snippets will be listed
        /// </summary>
        /// <param name="args">sub command arguments</param>
        public static void List(IEnumerable<string> args)
        {
            Parser.Default.ParseArguments<ListOptions>(args)
                .WithParsed(option =>
                {
                    // if name is specified, print content
                    if (option.Name != null)
                    {
                        var record = Database.Instance.GetRecord(option.Name);
                        
                        Log.Info(record.Content);

                        return;
                    }
                    
                    // TODO: format in a nice looking table w/ size displayed, a description,
                    // maybe a preview of the text
                    Log.Info("List command selected . . .");
                    var records = Database.Instance.GetAllRecords();

                    foreach (var snippetRecord in records)
                    {
                        Log.Info(snippetRecord.Name);
                    }
                });
        }
        
        /// <summary>
        /// Use to copy the contents of a specified snippet name, requires specify Name option of snippet to copy
        /// </summary>
        /// <param name="args">sub command arguments</param>
        public static void Copy(IEnumerable<string> args)
        {
            Parser.Default.ParseArguments<CopyOptions>(args)
                .WithParsed(option =>
                {
                    // TODO: implement command for copying a snippet to the clipboard
                    Log.Info("Copy command selected . . .");
                });
        }
        
        /// <summary>
        /// Use to generate a file with the contents of a specified snippet name, requires specify Name option of snippet to copy
        /// and a path to a file in which the snippet should be generated in
        /// </summary>
        /// <param name="args">sub command arguments</param>
        public static void Generate(IEnumerable<string> args)
        {
            Parser.Default.ParseArguments<GenerateOptions>(args)
                .WithParsed(option =>
                {
                    Log.Info("Generate command selected . . .");
                        
                    try
                    {
                        var snippet = Database.Instance.GetRecord(option.Name);
                            
                        File.WriteAllText(option.Path, snippet.Content);
                            
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                });
        }
        
        /// <summary>
        /// Use to delete a specified snippet by name
        /// </summary>
        /// <param name="args">sub command arguments</param>
        public static void Delete(IEnumerable<string> args)
        {
            Parser.Default.ParseArguments<DeleteOptions>(args)
                .WithParsed(option =>
                {
                    Database.Instance.DeleteRecord(option.Name);

                });
        }
    }
}