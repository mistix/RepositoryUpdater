using RepoUpdater.Model.Abstraction;
using System;
using TinyMessenger;

namespace RepoUpdater.Model.Strategies
{
    public class GitRepository : RepositoryUpdaterBase
    {
        private const string PullArgument = "--git-dir={0}\\.git --work-tree={0} pull";

        public GitRepository(string path, ICommandLine commandLine, ITinyMessengerHub eventBus)
            : base(path, commandLine, eventBus)
        {
        }

        public override void Update()
        {
            try
            {
                var executionArguments = string.Format(PullArgument, RepositoryPath);
                var output = _command.Execute(Settings.GitPath, executionArguments, true, true, true);

                var message = new GenericTinyMessage<string>(this, string.Format("Updated: {0}", output));
                _eventBus.Publish(message);
            }
            catch (Exception exception)
            {
                var message = new GenericTinyMessage<Exception>(this, exception);
                _eventBus.Publish(message);
            }
        }
    }
}