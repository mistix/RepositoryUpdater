using RepoUpdater.Model.Abstraction;
using System;

namespace RepoUpdater.Model.Strategies
{
    public class GitRepository : IRepositoryUpdaterStrategy
    {
        public void Update()
        {
            throw new NotImplementedException();
        }

        public string Path { get; private set; }
    }
}