using RepoUpdater.Abstract;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.ViewModels.Abstraction;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using TinyMessenger;

namespace RepoUpdater.ViewModels
{
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged, IDisposable
    {
        #region Fields

        private readonly ITinyMessengerHub _messageBus;
        private readonly INavigationManager _navigationManager;
        private readonly IRepositoryList _repositoryList;

        private RelayCommand _closeMainWindow;
        private RelayCommand _openNewItemWindow;
        private RelayCommand _openSettingsWindow;
        private RelayCommand _openAboutWindow;

        #endregion

        #region Events

        public event EventHandler CloseWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public ObservableCollection<RepositoryUpdaterBase> Repositories
        {
            get { return _repositoryList.Repositories; }
        }

        public ICommand OpenNewItemWindow
        {
            get
            {
                return _openNewItemWindow ??
                       (_openNewItemWindow = new RelayCommand(param => _navigationManager.OpenAddNewItemWindow()));
            }
        }

        public ICommand CloseMainWindow
        {
            get
            {
                return _closeMainWindow ?? (_closeMainWindow = new RelayCommand(param => CloseWindow.Invoke(this, null)));
            }
        }

        public ICommand OpenSettingsWindow
        {
            get
            {
                return _openSettingsWindow ??
                       (_openSettingsWindow = new RelayCommand(param => _navigationManager.OpenSettingsWindow()));
            }
        }

        public ICommand OpenInformationWindow
        {
            get
            {
                return _openAboutWindow ??
                       (_openAboutWindow = new RelayCommand(param => _navigationManager.OpenAboutInformations()));
            }
        }

        #endregion

        #region Constructors

        public MainViewModel(
            ITinyMessengerHub messageBus,
            INavigationManager navigationManager,
            IRepositoryList repositoryList)
        {
            _messageBus = messageBus;
            _navigationManager = navigationManager;
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