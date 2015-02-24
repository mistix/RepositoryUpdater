using RepoUpdater.Model.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace RepoUpdater.ViewModels
{
    public interface IMainViewModel
    {
        IEnumerable<RepositoryItem> Repositories { get; set; }

        ICommand OpenNewItemWindow { get; }
        ICommand CloseMainWindow { get; }

        event EventHandler CloseWindow;
    }
}