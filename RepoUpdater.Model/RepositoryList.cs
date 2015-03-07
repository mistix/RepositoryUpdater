using RepoUpdater.Model.Abstraction;
using System;
using System.Collections.Generic;

namespace RepoUpdater.Model
{
    public class RepositoryList : IRepositoryList
    {
        #region Fields

        private readonly IRepositoryListSerializer _serializer;
        private readonly IApplicationSettings _applicationSettings;
        private readonly List<RepositoryUpdaterBase> _repositoryUpdaterStrategies;

        #endregion

        #region Constructors

        public RepositoryList(IRepositoryListSerializer serializer, IApplicationSettings applicationSettings)
        {
            _serializer = serializer;
            _applicationSettings = applicationSettings;
            _repositoryUpdaterStrategies = new List<RepositoryUpdaterBase>();
        }

        #endregion

        #region Properties

        public IEnumerable<RepositoryUpdaterBase> Repositories
        {
            get { return _repositoryUpdaterStrategies; }
        }

        #endregion

        #region Methods

        public void Add(RepositoryUpdaterBase repository)
        {
            if (repository == null)
                throw new ArgumentException("Repository cannot be null");

            if (_repositoryUpdaterStrategies.Contains(repository))
                return;

            _repositoryUpdaterStrategies.Add(repository);
        }

        public void Remove(RepositoryUpdaterBase repository)
        {
            if (_repositoryUpdaterStrategies.Contains(repository))
                _repositoryUpdaterStrategies.Remove(repository);
        }

        public void UpdateAll()
        {
            _repositoryUpdaterStrategies.ForEach(item => item.Update());
        }

        public void Clear()
        {
            _repositoryUpdaterStrategies.Clear();
        }

        public void Save()
        {
            _serializer.Save(_repositoryUpdaterStrategies, _applicationSettings.DefaultConfigFile);
        }

        public void Load()
        {
            Clear();
            _repositoryUpdaterStrategies.AddRange(_serializer.Load(_applicationSettings.DefaultConfigFile));
        }

        #endregion
    }
}