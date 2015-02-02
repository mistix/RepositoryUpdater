namespace RepoUpdater.Model.Abstraction
{
    public interface IRepositoryUpdaterStrategy
    {
        void Update();
        string Path { get; }
    }
}