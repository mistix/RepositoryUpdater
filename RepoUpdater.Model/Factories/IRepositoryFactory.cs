using RepoUpdater.Model.Abstraction;

namespace RepoUpdater.Model.Factories
{
    public interface IRepositoryFactory
    {
        RepositoryUpdaterBase Create(RepositoryType repositoryType, string repositoryPath);
    }
}