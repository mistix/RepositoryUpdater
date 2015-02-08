using RepoUpdater.Model.Abstraction;
using System;

namespace RepoUpdater.Model.Strategies
{
    public class TfsRepository : RepositoryUpdaterBase
    {
        public TfsRepository(string path)
            : base(path)
        {
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}