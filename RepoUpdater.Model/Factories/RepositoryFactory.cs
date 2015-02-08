using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Strategies;
using System;

namespace RepoUpdater.Model.Factories
{
    public static class RepositoryFactory
    {
        public static RepositoryUpdaterBase Create(RepositoryType repositoryType, string repositoryPath)
        {
            switch (repositoryType)
            {
                case RepositoryType.Git:
                    return new GitRepository(repositoryPath);
                case RepositoryType.Tfs:
                    return new TfsRepository(repositoryPath);
                default:
                    throw new ArgumentOutOfRangeException("repositoryType");
            }
        }
    }
}