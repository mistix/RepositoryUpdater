using RepoUpdater.Abstract;
using RepoUpdater.Model;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using RepoUpdater.ViewModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using TinyMessenger;

namespace RepoUpdater.ViewModels
{
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged
    {
        #region Fields

        private readonly ITinyMessengerHub _messageBus;
        private readonly IRepositoryList _repositoryList;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IRepositoryUpdater _updater;

        private RelayCommand _closeMainWindow;
        private RelayCommand _addRepository;
        private RelayCommand _removeRepository;
        private RelayCommand _startUpdateRepositories;
        private RelayCommand _stopUpdateRepositories;

        #endregion

        #region Events

        public event EventHandler CloseWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public string FolderPath { get; set; }

        public ObservableCollection<RepositoryBase> Repositories
        {
            get { return _repositoryList.Repositories; }
        }

        public ICommand CloseMainWindow
        {
            get { return _closeMainWindow ?? (_closeMainWindow = new RelayCommand(param => CloseWindow.Invoke(this, null))); }
        }

        public ICommand AddRepository
        {
            get { return _addRepository ?? (_addRepository = new RelayCommand(param => AddNewRepository())); }
        }

        public ICommand RemoveRepository
        {
            get { return _removeRepository ?? (_removeRepository = new RelayCommand(parma => RemoveExistingRepository())); }
        }

        public ICommand StartUpdateRepositories
        {
            get { return _startUpdateRepositories ?? (_startUpdateRepositories = new RelayCommand(param => RunRepositoryUpdater())); }
        }

        public ICommand StopUpdateRepositories
        {
            get { return _stopUpdateRepositories ?? (_stopUpdateRepositories = new RelayCommand(param => StopRepositoryUpdate())); }
        }

        public IEnumerable<string> RepositoryTypes
        {
            get
            {
                var types = Enum.GetNames(typeof(RepositoryType));
                return types.Where(type => type != RepositoryType.Unknown.ToString());
            }
        }

        public int SelectedItemIndex { get; set; }

        public string SelectedRepository { get; set; }

        #endregion

        #region Public Methods

        public void Initialize()
        {
            RunRepositoryUpdater();
        }

        #endregion

        #region Private Methods

        private void StopRepositoryUpdate()
        {
            _updater.Stop();
        }

        private void RunRepositoryUpdater()
        {
            _updater.Run();
        }

        private void RemoveExistingRepository()
        {
            if (SelectedItemIndex < 0)
                return;

            _repositoryList.Remove(SelectedItemIndex);
            OnPropertyChanged("Repositories");
        }

        private void AddNewRepository()
        {
            if (_repositoryList.Repositories.Any(item => item.RepositoryPath == FolderPath))
                return;

            RepositoryType repositoryType = RepositoryType.Unknown;
            bool parseSuccess = Enum.TryParse(SelectedRepository, true, out repositoryType);

            if (!parseSuccess)
                return;

            var repository = _repositoryFactory.Create(repositoryType, FolderPath);
            _repositoryList.Add(repository);
            _repositoryList.Save();

            OnPropertyChanged("Repositories");
        }

        #endregion

        #region Constructors

        public MainViewModel(ITinyMessengerHub messageBus, IRepositoryList repositoryList, IRepositoryFactory repositoryFactory, IRepositoryUpdater updater)
        {
            _messageBus = messageBus;
            _repositoryList = repositoryList;
            _repositoryFactory = repositoryFactory;
            _updater = updater;
        }

        #endregion

        #region Methods

        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] != null) return;
            string msg = "Invalid property name: " + propertyName;
            throw new Exception(msg);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler == null) return;
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }

        #endregion
    }
}