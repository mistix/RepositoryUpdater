using RepoUpdater.Model;
using RepoUpdater.Model.ModelView;
using System.Collections.Generic;

namespace RepoUpdater.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        public IEnumerable<RepositoryItem> Repositories { get; set; }

        public MainPresenter()
        {
            Repositories = new List<RepositoryItem>()
            {
                new RepositoryItem()
                {
                    Path = "test",
                    Recursive = false,
                    RepositoryType = RepositoryType.Git
                }
            };
        }
    }
}