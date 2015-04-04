using TinyMessenger;

namespace RepoUpdater.Model.Abstraction
{
    public abstract class RepositoryBase
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

        protected RepositoryBase(string path, string name, ICommandLine command, ITinyMessengerHub eventBus)
        {
            _command = command;
            _eventBus = eventBus;
            _path = path;
            _name = name;
        }

        public abstract void Update();
    }
}