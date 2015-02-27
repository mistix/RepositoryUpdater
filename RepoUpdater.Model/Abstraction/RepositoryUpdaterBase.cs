using TinyMessenger;

namespace RepoUpdater.Model.Abstraction
{
    public abstract class RepositoryUpdaterBase
    {
        private readonly string _path;
        private readonly string _name;
        protected readonly ICommandLine _command;
        protected readonly ITinyMessengerHub _eventBus;

        public virtual string RepositoryPath
        {
            get { return _path; }
        }

        public virtual string Name
        {
            get { return _name; }
        }

        protected RepositoryUpdaterBase(string path, string name, ICommandLine command, ITinyMessengerHub eventBus)
        {
            _command = command;
            _eventBus = eventBus;
            _path = path;
            _name = name;
        }

        public abstract void Update();
    }
}