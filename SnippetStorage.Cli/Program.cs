namespace SnippetStorage.Cli
{
    using CommandLine;
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
                        return;
                    }
                    
                    if (option.List)
                    {
                        Log.Info("List command selected . . .");
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
                        return;
                    }
                    
                    if (option.Delete)
                    {
                        Log.Info("Delete command selected . . .");
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