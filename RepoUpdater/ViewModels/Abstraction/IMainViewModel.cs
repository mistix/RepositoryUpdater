using RepoUpdater.Model.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RepoUpdater.ViewModels.Abstraction
{
    public interface IMainViewModel
    {
        #region Properties

        ObservableCollection<RepositoryBase> Repositories { get; }

        ICommand CloseMainWindow { get; }
        ICommand AddRepository { get; }
        ICommand RemoveRepository { get; }
        ICommand StartUpdateRepositories { get; }
        ICommand StopUpdateRepositories { get; }

        IEnumerable<string> RepositoryTypes { get; }
        int SelectedItemIndex { get; set; }
        string SelectedRepository { get; set; }
        string FolderPath { get; set; }

        #endregion

        #region Events

        event EventHandler CloseWindow;

        #endregion

        #region Methods

        void Initialize();

        #endregion
    }
}