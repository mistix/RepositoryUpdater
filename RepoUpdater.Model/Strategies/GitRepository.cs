using RepoUpdater.Model.Abstraction;
using System;
using TinyMessenger;

namespace RepoUpdater.Model.Strategies
{
    public class GitRepository : RepositoryUpdaterBase
    {
        private const string PullArgument = "pull";

        public GitRepository(string path, ICommandLine commandLine, ITinyMessengerHub eventBus)
            : base(path, commandLine, eventBus)
        {
        }

        public override void Update()
        {
            try
            {
                var output = _command.Execute(Settings.GitPath, RepositoryPath, PullArgument, true, true, true);

                var message = new GenericTinyMessage<string>(this, string.Format("Updated: {0}", output));
                _eventBus.Publish(message);
            }
            catch (Exception exception)
            {
                var message = new GenericTinyMessage<string>(this, exception.Message);
                _eventBus.Publish(message);
            }
        }
    }
}