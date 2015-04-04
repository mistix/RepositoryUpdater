using System.Collections.ObjectModel;

namespace RepoUpdater.Model.Abstraction
{
    public interface IRepositoryList
    {
        #region Properties

        ObservableCollection<RepositoryUpdaterBase> Repositories { get; }

        #endregion


        #region Methodsj

        void Add(RepositoryUpdaterBase repository);
        void Remove(RepositoryUpdaterBase repository);
        void Remove(int index);
        void UpdateAll();
        void Clear();

        void Save();
        void Load();

        #endregion
    }
}