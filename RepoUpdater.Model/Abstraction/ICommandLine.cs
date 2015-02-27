namespace RepoUpdater.Model.Abstraction
{
    public interface ICommandLine
    {
        string Execute(string executable, string arguments, bool standardOutput = false, bool standardError = false, bool throwOnError = false);
    }
}