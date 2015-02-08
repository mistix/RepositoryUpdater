using RepoUpdater.Model.Abstraction;
using System;
using System.Collections.Generic;

namespace RepoUpdater.Model
{
    public class RepositoryList
    {
        private readonly List<RepositoryUpdaterBase> _repositoryUpdaterStrategies;

        public RepositoryList()
        {
            _repositoryUpdaterStrategies = new List<RepositoryUpdaterBase>();
        }

        public IEnumerable<RepositoryUpdaterBase> Repositories
        {
            get { return _repositoryUpdaterStrategies; }
        }

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
    }
}