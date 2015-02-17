using RepoUpdater.Model.Factories;
using RepoUpdater.Model.ModelView;
using System.Collections.Generic;
using TinyMessenger;

namespace RepoUpdater.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private readonly ITinyMessengerHub _messageBus;
        private readonly RepositoryFactory _repositoryFactory;

        public IEnumerable<RepositoryItem> Repositories { get; set; }

        public MainPresenter()
        {
            _messageBus = new TinyMessengerHub();
            _repositoryFactory = new RepositoryFactory(_messageBus);
        }
    }
}