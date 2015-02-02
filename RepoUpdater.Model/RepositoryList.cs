using RepoUpdater.Model.Abstraction;
using System.Collections.Generic;

namespace RepoUpdater.Model
{
    public class RepositoryList
    {
        public IEnumerable<IRepositoryUpdaterStrategy> Repositories
        {
            get { return null; }
        }

        public void Add(IRepositoryUpdaterStrategy repository)
        {
        }

        public void Remove(IRepositoryUpdaterStrategy repository)
        {
        }

        public void UpdateAll()
        {
        }

        public void Clean()
        {
            throw new System.NotImplementedException();
        }
    }
}