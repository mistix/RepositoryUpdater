using System.Collections.Generic;

namespace RepoUpdater.Model.Abstraction
{
    public interface IRepositoryList
    {
        IEnumerable<RepositoryUpdaterBase> Repositories { get; }

        void Add(RepositoryUpdaterBase repository);
        void Remove(RepositoryUpdaterBase repository);
        void UpdateAll();
        void Clear();

        void Save();
        void Load();
    }
}