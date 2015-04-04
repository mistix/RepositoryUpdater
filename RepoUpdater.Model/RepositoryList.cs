using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Annotations;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RepoUpdater.Model
{
    public class RepositoryList : IRepositoryList, INotifyPropertyChanged
    {
        #region Fields

        private readonly IRepositoryListSerializer _serializer;
        private readonly IApplicationSettings _applicationSettings;
        private readonly ObservableCollection<RepositoryUpdaterBase> _repositoryUpdaterStrategies;

        #endregion

        #region Constructors

        public RepositoryList(IRepositoryListSerializer serializer, IApplicationSettings applicationSettings)
        {
            _serializer = serializer;
            _applicationSettings = applicationSettings;
            _repositoryUpdaterStrategies = new ObservableCollection<RepositoryUpdaterBase>();
        }

        #endregion

        #region Properties

        public ObservableCollection<RepositoryUpdaterBase> Repositories
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
            foreach (RepositoryUpdaterBase item in _repositoryUpdaterStrategies)
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
            foreach (RepositoryUpdaterBase item in storedRepositories)
                _repositoryUpdaterStrategies.Add(item);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}