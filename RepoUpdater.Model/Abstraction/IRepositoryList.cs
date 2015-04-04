using System.Collections.ObjectModel;

namespace RepoUpdater.Model.Abstraction
{
    public interface IRepositoryList
    {
        #region Properties

        ObservableCollection<RepositoryBase> Repositories { get; }

        #endregion


        #region Methodsj

        void Add(RepositoryBase repository);
        void Remove(RepositoryBase repository);
        void Remove(int index);
        void UpdateAll();
        void Clear();

        void Save();
        void Load();

        #endregion
    }
}