using Ninject;
using RepoUpdater.Model.Factories;
using RepoUpdater.Model.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TinyMessenger;

namespace RepoUpdater.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        private readonly IKernel _kernel;
        private readonly ITinyMessengerHub _messageBus;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly INavigationManager _navigationManager;

        private RelayCommand _closeMainWindow;

        public IEnumerable<RepositoryItem> Repositories { get; set; }

        public ICommand OpenNewItemWindow
        {
            get { return null; }
        }

        public ICommand CloseMainWindow
        {
            get
            {
                return _closeMainWindow ?? (_closeMainWindow = new RelayCommand(param => CloseWindow.Invoke(this, null)));
            }
        }

        public event EventHandler CloseWindow;

        public MainViewModel(IKernel kernel, ITinyMessengerHub messageBus, IRepositoryFactory repositoryFactory, INavigationManager navigationManager)
        {
            _kernel = kernel;
            _messageBus = messageBus;
            _repositoryFactory = repositoryFactory;
            _navigationManager = navigationManager;
        }
    }
}