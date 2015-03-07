using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace RepoUpdater.ViewModels.Abstraction
{
    public interface IAddNewItemViewModel
    {
        event EventHandler CloseWindow;

        ICommand AcceptCommand { get; }
        ICommand CancelCommand { get; }

        IEnumerable<string> RepositorieTypes { get; }
        string SelectedRepository { get; set; }
        string FolderPath { get; set; }
    }
}