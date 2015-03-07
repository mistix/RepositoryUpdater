using RepoUpdater.Model.Abstraction;
using System.Configuration;

namespace RepoUpdater.Model
{
    public class ApplicationSettings : IApplicationSettings
    {
        #region Constants

        private const string DefaultConfigurationFile = "DefaultConfigurationFile";
        private const string DefaultGitExecPath = "DefaultGitExecPath";
        private const string DefaultTfsExecPath = "DefaultTfsExecPath";

        #endregion

        #region Properties

        public string DefaultConfigFile
        {
            get { return ConfigurationManager.AppSettings[DefaultConfigurationFile]; }
        }

        public string GitExecPath
        {
            get { return ConfigurationManager.AppSettings[DefaultGitExecPath]; }
        }

        public string TfsExecPath
        {
            get { return ConfigurationManager.AppSettings[DefaultTfsExecPath]; }
        }

        #endregion


    }
}