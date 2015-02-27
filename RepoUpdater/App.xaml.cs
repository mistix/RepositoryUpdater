using Ninject;
using RepoUpdater.Model;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using RepoUpdater.ViewModels;
using RepoUpdater.ViewModels.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TinyMessenger;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureContainer();
            ComposeObjects();

            base.OnStartup(e);
        }

        private void ConfigureContainer()
        {
            _container = new StandardKernel();

            _container.Bind<IMainViewModel>().To<MainViewModel>().InTransientScope();
            _container.Bind<INavigationManager>().To<NavigationManager>().InTransientScope();
            _container.Bind<IRepositoryFactory>().To<RepositoryFactory>().InTransientScope();
            _container.Bind<ITinyMessengerHub>().To<TinyMessengerHub>().InTransientScope();
            _container.Bind<IRepositoryList>().To<RepositoryList>().InSingletonScope();
            _container.Bind<IRepositoryListSerializer>().To<RepositoryXMLSerializer>();

            _container.Bind<AddNewItem>().ToSelf().InSingletonScope();
        }

        private void ComposeObjects()
        {
            _container.Get<IRepositoryList>().Load("C:\\somepath.xml");
            Current.MainWindow = _container.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }

    internal class RepositoryXMLSerializer : IRepositoryListSerializer
    {
        public void Save(IEnumerable<RepositoryUpdaterBase> repositories, string path)
        {
        }

        public IEnumerable<RepositoryUpdaterBase> Load(string path)
        {
            return Enumerable.Empty<RepositoryUpdaterBase>();
        }
    }
}
