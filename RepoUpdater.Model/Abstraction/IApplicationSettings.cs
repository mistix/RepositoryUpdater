namespace RepoUpdater.Model.Abstraction
{
    public interface IApplicationSettings
    {
        #region Properties

        string DefaultConfigFile { get; }

        string GitExecPath { get; }

        string TfsExecPath { get; }

        #endregion
    }
}