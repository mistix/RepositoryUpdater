using System;
using TinyMessenger;

namespace RepoUpdater.Model.Strategies
{
    public class GitTfsRepository : GitRepository
    {
        protected new const string PullArgument = "--git-dir={0}\\.git --work-tree={0} tfs pull";

        public GitTfsRepository(string path, ICommandLine commandLine, ITinyMessengerHub eventBus)
            : base(path, commandLine, eventBus)
        {
        }

        public override void Update()
        {
            try
            {
                var executionArguments = string.Format(PullArgument, RepositoryPath);
                var output = _command.Execute(Settings.GitPath, executionArguments, true, true, true);

                var message = new GenericTinyMessage<string>(this, string.Format("Git TFS updated: {0}", output));
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