using RepoUpdater.Model.Abstraction;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RepoUpdater.ViewModels.Abstraction
{
    public interface IMainViewModel
    {
        ObservableCollection<RepositoryUpdaterBase> Repositories { get; }

        ICommand OpenNewItemWindow { get; }
        ICommand CloseMainWindow { get; }
        ICommand OpenSettingsWindow { get; }
        ICommand OpenInformationWindow { get; }

        event EventHandler CloseWindow;
    }
}