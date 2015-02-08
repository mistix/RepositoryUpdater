using RepoUpdater.Model.Abstraction;
using System;

namespace RepoUpdater.Model.Strategies
{
    public class GitRepository : RepositoryUpdaterBase
    {
        public GitRepository(string path)
            : base(path)
        {
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}