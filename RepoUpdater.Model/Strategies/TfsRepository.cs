using RepoUpdater.Model.Abstraction;
using System;

namespace RepoUpdater.Model.Strategies
{
    public class TfsRepository : IRepositoryUpdaterStrategy
    {
        public void Update()
        {
            throw new NotImplementedException();
        }

        public string Path { get; private set; }
    }
}