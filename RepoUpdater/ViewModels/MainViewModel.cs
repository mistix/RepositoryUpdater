using RepoUpdater.Model;
using RepoUpdater.Model.Abstraction;
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
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged, IDisposable
    {
        #region Fields

        private readonly ITinyMessengerHub _messageBus;
        private readonly IRepositoryList _repositoryList;

        private RelayCommand _closeMainWindow;
        private RelayCommand _addRepository;
        private RelayCommand _removeRepository;

        #endregion

        #region Events

        public string FolderPath { get; set; }
        public event EventHandler CloseWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public ObservableCollection<RepositoryUpdaterBase> Repositories
        {
            get
            {
                return _repositoryList.Repositories;
            }
        }

        public ICommand CloseMainWindow
        {
            get
            {
                return _closeMainWindow ?? (_closeMainWindow = new RelayCommand(param => CloseWindow.Invoke(this, null)));
            }
        }

        public ICommand AddRepository
        {
            get { return _addRepository ?? (_addRepository = new RelayCommand(param => AddNewRepository())); }
        }

        public ICommand RemoveRepository
        {
            get { return _removeRepository ?? (_removeRepository = new RelayCommand(parma => RemoveExistingRepository())); }
        }

        public IEnumerable<string> RepositoryTypes
        {
            get
            {
                var types = Enum.GetNames(typeof(RepositoryType));
                return types.Where(type => type != RepositoryType.Unknown.ToString());
            }
        }

        public string SelectedRepository { get; set; }

        #endregion

        #region Private Methods

        private void RemoveExistingRepository()
        {
            throw new NotImplementedException();
        }


        private void AddNewRepository()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Constructors

        public MainViewModel(
            ITinyMessengerHub messageBus,
            IRepositoryList repositoryList)
        {
            _messageBus = messageBus;
            _repositoryList = repositoryList;
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

        public void Dispose()
        {
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