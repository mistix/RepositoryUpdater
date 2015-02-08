namespace RepoUpdater.Model.ModelView
{
    public class RepositoryItem
    {
        public string Path { get; set; }

        public bool Recursive { get; set; }

        public RepositoryType RepositoryType { get; set; }
    }
}