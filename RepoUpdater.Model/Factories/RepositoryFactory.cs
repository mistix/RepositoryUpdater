using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Strategies;
using System;
using TinyMessenger;

namespace RepoUpdater.Model.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        #region Fields

        private readonly ITinyMessengerHub _eventBus;

        #endregion

        #region Constructors

        public RepositoryFactory(ITinyMessengerHub eventBus)
        {
            _eventBus = eventBus;
        }

        #endregion

        #region Methods

        public RepositoryBase Create(RepositoryType repositoryType, string repositoryPath)
        {
            var command = new CommandLine();

            switch (repositoryType)
            {
                case RepositoryType.Git:
                    return new GitRepository(repositoryPath, command, _eventBus);
                case RepositoryType.Tfs:
                    return new TfsRepository(repositoryPath, command, _eventBus);
                case RepositoryType.GitTfs:
                    return new GitTfsRepository(repositoryPath, command, _eventBus);
                default:
                    throw new ArgumentOutOfRangeException("repositoryType");
            }
        }

        public RepositoryBase Create(string repositoryType, string repositoryPath)
        {
            RepositoryType type = (RepositoryType)Enum.Parse(typeof(RepositoryType), repositoryType, true);

            return Create(type, repositoryPath);
        }

        #endregion
    }
}