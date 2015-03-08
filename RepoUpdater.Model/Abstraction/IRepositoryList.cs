using System.Collections.ObjectModel;

namespace RepoUpdater.Model.Abstraction
{
    public interface IRepositoryList
    {
        ObservableCollection<RepositoryUpdaterBase> Repositories { get; }

        void Add(RepositoryUpdaterBase repository);
        void Remove(RepositoryUpdaterBase repository);
        void UpdateAll();
        void Clear();

        void Save();
        void Load();
    }
}