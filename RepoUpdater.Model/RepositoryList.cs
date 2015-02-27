using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using System;
using System.Collections.Generic;

namespace RepoUpdater.Model
{
    public class RepositoryList : IRepositoryList
    {
        #region Fields

        private readonly IRepositoryListSerializer _serializer;
        private readonly List<RepositoryUpdaterBase> _repositoryUpdaterStrategies;

        #endregion

        #region Constructors

        public RepositoryList(IRepositoryListSerializer serializer)
        {
            _serializer = serializer;

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

        public void Save(string path)
        {
            _serializer.Save(_repositoryUpdaterStrategies, path);
        }

        public void Load(string path)
        {
            Clear();
            _repositoryUpdaterStrategies.AddRange(_serializer.Load(path));
        }

        #endregion
    }
}