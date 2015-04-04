using System.Collections.Generic;

namespace RepoUpdater.Model.Abstraction
{
    public interface IRepositoryListSerializer
    {
        void Save(IEnumerable<RepositoryBase> repositories, string path);
        IEnumerable<RepositoryBase> Load(string path);
    }
}