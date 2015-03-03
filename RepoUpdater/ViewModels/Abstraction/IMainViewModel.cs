using RepoUpdater.Model.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace RepoUpdater.ViewModels.Abstraction
{
    public interface IMainViewModel
    {
        IEnumerable<RepositoryItem> Repositories { get; }

        ICommand OpenNewItemWindow { get; }
        ICommand CloseMainWindow { get; }
        ICommand OpenSettingsWindow { get; }
        ICommand OpenInformationWindow { get; }

        event EventHandler CloseWindow;
    }
}