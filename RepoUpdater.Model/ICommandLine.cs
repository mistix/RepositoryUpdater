namespace RepoUpdater.Model
{
    public interface ICommandLine
    {
        string Execute(string executable, string arguments, string workingDirectory, bool standardOutput = false, bool standardError = false, bool throwOnError = false);
    }
}