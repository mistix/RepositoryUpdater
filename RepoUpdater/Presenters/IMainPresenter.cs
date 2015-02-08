using RepoUpdater.Model.ModelView;
using System.Collections.Generic;

namespace RepoUpdater.Presenters
{
    public interface IMainPresenter
    {
        IEnumerable<RepositoryItem> Repositories { get; set; }
    }
}