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

        ObservableCollection<RepositoryUpdaterBase> Repositories { get; }

        ICommand CloseMainWindow { get; }
        ICommand AddRepository { get; }
        ICommand RemoveRepository { get; }

        IEnumerable<string> RepositoryTypes { get; }
        string SelectedRepository { get; set; }
        string FolderPath { get; set; }

        #endregion

        #region Events

        event EventHandler CloseWindow;

        #endregion

    }
}