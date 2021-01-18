namespace SnippetStorage.Cli
{
    using System;
    using System.IO;
    using CommandLine;
    using Core;
    using NLog;

    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(option =>
                {
                    if (option.Store)
                    {
                        Log.Info("Store command selected . . .");
                        Log.Info($"Name={option.Name}, Path={option.Path}");
                        Database.Instance.CreateRecord(SnippetRecord.Create(option.Name, option.Path));
                        return;
                    }
                    
                    if (option.List)
                    {
                        // TODO: format in a nice looking table w/ size displayed, a description,
                        // maybe a preview of the text
                        Log.Info("List command selected . . .");
                        var records = Database.Instance.GetAllRecords();

                        foreach (var snippetRecord in records)
                        {
                            Log.Info(snippetRecord.Name);
                        }
                        return;
                    }

                    if (option.Copy)
                    {
                        Log.Info("Copy command selected . . .");
                        return;
                    }
                    
                    if (option.Generate)
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
                        
                        return;
                    }
                    
                    if (option.Delete)
                    {
                        Log.Info("Delete command selected . . .");
                        Log.Info($"Name={option.Name}");
                        Database.Instance.DeleteRecord(option.Name);
                        return;
                    }
                    
                    if (option.Import)
                    {
                        Log.Info("Import command selected . . .");
                        return;
                    }
                    
                    if (option.Export)
                    {
                        Log.Info("Export command selected . . .");
                        return;
                    }
                    
                    Log.Debug("No command selected");
                });
        }
    }
}