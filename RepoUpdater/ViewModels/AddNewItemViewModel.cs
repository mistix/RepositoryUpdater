using RepoUpdater.Model;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using RepoUpdater.ViewModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace RepoUpdater.ViewModels
{
    public class AddNewItemViewModel : IAddNewItemViewModel, INotifyPropertyChanged
    {
        private readonly IRepositoryList _repositoryList;
        private readonly IRepositoryFactory _repositoryFactory;

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CloseWindow;

        #endregion

        #region Fields

        private RelayCommand _acceptCommand;
        private RelayCommand _cancelCommand;

        #endregion

        #region Properties

        public ICommand AcceptCommand
        {
            get { return _acceptCommand ?? (_acceptCommand = new RelayCommand(param => AddRepository())); }
        }

        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(param => CloseWindow.Invoke(this, null)));
            }
        }

        public IEnumerable<string> RepositorieTypes
        {
            get
            {
                var types = Enum.GetNames(typeof(RepositoryType));
                return types.Where(type => type != RepositoryType.Unknown.ToString());
            }
        }

        public string SelectedRepository { get; set; }

        public string FolderPath { get; set; }

        #endregion

        #region Constructors

        public AddNewItemViewModel(IRepositoryList repositoryList, IRepositoryFactory repositoryFactory)
        {
            _repositoryList = repositoryList;
            _repositoryFactory = repositoryFactory;
        }

        #endregion

        #region Methods

        private void AddRepository()
        {
            if (_repositoryList.Repositories.Any(item => item.RepositoryPath == FolderPath))
                return;

            RepositoryType repositorType = RepositoryType.Unknown;
            bool parseSuccess = Enum.TryParse(SelectedRepository, true, out repositorType);

            if (!parseSuccess)
                return;

            var repository = _repositoryFactory.Create(repositorType, FolderPath);
            _repositoryList.Add(repository);

            CloseWindow.Invoke(this, null);
        }

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