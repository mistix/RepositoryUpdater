using System;
using System.Collections.Generic;
using System.Windows.Input;
using RepoUpdater.Model.ModelView;

namespace RepoUpdater.ViewModels.Abstraction
{
    public interface IMainViewModel
    {
        IEnumerable<RepositoryItem> Repositories { get; }

        ICommand OpenNewItemWindow { get; }
        ICommand CloseMainWindow { get; }

        event EventHandler CloseWindow;
    }
}