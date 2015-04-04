using RepoUpdater.Model.Abstraction;

namespace RepoUpdater.Model.Factories
{
    public interface IRepositoryFactory
    {
        RepositoryBase Create(RepositoryType repositoryType, string repositoryPath);
        RepositoryBase Create(string repositoryType, string repositoryPath);
    }
}