using RepoUpdater.Model.Abstraction;
using System;
using TinyMessenger;

namespace RepoUpdater.Model.Strategies
{
    public class TfsRepository : RepositoryBase
    {
        public TfsRepository(string path, ICommandLine commandLine, ITinyMessengerHub eventBus)
            : base(path, "TFS", commandLine, eventBus)
        {
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}