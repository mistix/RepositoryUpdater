using TinyMessenger;

namespace RepoUpdater.Model.Abstraction
{
    public abstract class RepositoryUpdaterBase
    {
        private readonly string _path;
        protected readonly ICommandLine _command;
        protected readonly ITinyMessengerHub _eventBus;

        public virtual string RepositoryPath
        {
            get { return _path; }
        }

        protected RepositoryUpdaterBase(string path, ICommandLine command, ITinyMessengerHub eventBus)
        {
            _command = command;
            _eventBus = eventBus;
            _path = path;
        }

        public abstract void Update();
    }
}