﻿using RepoUpdater.Model.Abstraction;
using System;
using System.Collections.ObjectModel;

namespace RepoUpdater.Model
{
    public class RepositoryList : IRepositoryList
    {
        #region Fields

        private readonly IRepositoryListSerializer _serializer;
        private readonly IApplicationSettings _applicationSettings;
        private readonly ObservableCollection<RepositoryBase> _repositoryUpdaterStrategies;

        #endregion

        #region Constructors

        public RepositoryList(IRepositoryListSerializer serializer, IApplicationSettings applicationSettings)
        {
            _serializer = serializer;
            _applicationSettings = applicationSettings;
            _repositoryUpdaterStrategies = new ObservableCollection<RepositoryBase>();
        }

        #endregion

        #region Properties

        public ObservableCollection<RepositoryBase> Repositories
        {
            get { return _repositoryUpdaterStrategies; }
        }

        #endregion

        #region Methods

        public void Add(RepositoryBase repository)
        {
            if (repository == null)
                throw new ArgumentException("Repository cannot be null");

            if (_repositoryUpdaterStrategies.Contains(repository))
                return;

            _repositoryUpdaterStrategies.Add(repository);
        }

        public void Remove(RepositoryBase repository)
        {
            if (_repositoryUpdaterStrategies.Contains(repository))
                _repositoryUpdaterStrategies.Remove(repository);
        }

        public void Remove(int index)
        {
            if (index < 0 || index > _repositoryUpdaterStrategies.Count)
                throw new ArgumentOutOfRangeException("index");

            _repositoryUpdaterStrategies.RemoveAt(index);
        }

        public void UpdateAll()
        {
            foreach (RepositoryBase item in _repositoryUpdaterStrategies)
                item.Update();
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
            var storedRepositories = _serializer.Load(_applicationSettings.DefaultConfigFile);
            foreach (RepositoryBase item in storedRepositories)
                _repositoryUpdaterStrategies.Add(item);

        }

        #endregion
    }
}