namespace SnippetStorage.Core
{
    /// <summary>
    /// Class for managing user profiles
    /// </summary>
    public class ProfileManager
    {
        /// <summary>
        /// Imports a profile from the provided path
        /// </summary>
        /// <param name="path"></param>
        public void ImportProfile(string path)
        {
            // TODO: implement
        }
        
        /// <summary>
        /// Exports profile with the provided name to the optional path.
        /// If no path is provided, the profile is exported to the working directory.
        /// </summary>
        /// <param name="name">name of profile to export</param>
        /// <param name="path">optional location to export to</param>
        public void ExportProfile(string name, string path = null)
        {
            // TODO: implement
        }
        
        /// <summary>
        /// Switch to profile with the provided name
        /// </summary>
        /// <param name="name">name of profile to switch to</param>
        public void SwitchProfile(string name)
        {
            // TODO: implement
        }

        /// <summary>
        /// Deletes profile with the provided name
        /// </summary>
        /// <param name="name">name of the profile to delete</param>
        public void DeleteProfile(string name)
        {
            // TODO: implement
        }

        /// <summary>
        /// Merges branch profile name into the source profile name
        /// </summary>
        /// <param name="source">name of profile to merge into</param>
        /// <param name="branch">name of profile to merge from</param>
        public void MergeProfiles(string source, string branch)
        {
            // TODO: implement
        }
        
        /// <summary>
        /// Lists all currently stored profiles. Provided a valid name of a profile,
        /// lists the details for that specific profile.
        /// </summary>
        /// <param name="name">name of specific profile to list</param>
        public void ListProfiles(string name = null)
        {
            // TODO: implement
        }
        
        /// <summary>
        /// Retrieves the currently active profile
        /// </summary>
        private void GetActiveProfile()
        {
            // TODO: implement
        }
    }
}