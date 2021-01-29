namespace SnippetStorage.Core
{
    using System;
    using System.IO;

    /// <summary>
    /// A POCO for snippet data
    /// </summary>
    public class SnippetRecord : IRecord
    {
        /// <inheritdoc/>
        public int Id { get; set; }
        
        /// <summary>
        /// The name that identifies this snippet
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The snippet content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Creates a snippet with a given name and the path of the snippet
        ///
        /// returns null on error
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SnippetRecord Create(string name, string path)
        {
            try
            {
                var content = File.ReadAllText(path);

                return new SnippetRecord
                {
                    Name = name,
                    Content = content
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}