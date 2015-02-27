using System.Collections.Generic;

namespace RepoUpdater.Model.Abstraction
{
    public interface IRepositoryListSerializer
    {
        void Save(IEnumerable<RepositoryUpdaterBase> repositories, string path);
        IEnumerable<RepositoryUpdaterBase> Load(string path);
    }
}