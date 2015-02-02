using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Strategies;
using System;

namespace RepoUpdater.Model.Factories
{
    public static class RepositoryFactory
    {
        public static IRepositoryUpdaterStrategy Create(RepositoryType repositoryType, string repositoryPath)
        {
            switch (repositoryType)
            {
                case RepositoryType.Git:
                    return new GitRepository();
                case RepositoryType.Tfs:
                    return new TfsRepository();
                default:
                    throw new ArgumentOutOfRangeException("repositoryType");
            }
        }
    }
}