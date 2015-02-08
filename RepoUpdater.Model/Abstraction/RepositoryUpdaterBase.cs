namespace RepoUpdater.Model.Abstraction
{
    public abstract class RepositoryUpdaterBase
    {
        private readonly string _path;

        public virtual string Path
        {
            get { return _path; }
        }

        protected RepositoryUpdaterBase(string path)
        {
            _path = path;
        }

        public abstract void Update();
    }
}