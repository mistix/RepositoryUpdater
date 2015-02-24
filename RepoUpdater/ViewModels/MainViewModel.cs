using Ninject;
using RepoUpdater.Model.Factories;
using RepoUpdater.Model.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using TinyMessenger;

namespace RepoUpdater.ViewModels
{
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged, IDisposable
    {
        #region Fields

        private readonly IKernel _kernel;
        private readonly ITinyMessengerHub _messageBus;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly INavigationManager _navigationManager;

        private RelayCommand _closeMainWindow;
        private RelayCommand _openNewItemWindow;

        #endregion

        #region Events

        public event EventHandler CloseWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public IEnumerable<RepositoryItem> Repositories { get; set; }

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

        #endregion

        #region Constructors

        public MainViewModel(IKernel kernel, ITinyMessengerHub messageBus, IRepositoryFactory repositoryFactory,
            INavigationManager navigationManager)
        {
            _kernel = kernel;
            _messageBus = messageBus;
            _repositoryFactory = repositoryFactory;
            _navigationManager = navigationManager;
        }

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler == null) return;
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }

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

        #endregion
    }
}