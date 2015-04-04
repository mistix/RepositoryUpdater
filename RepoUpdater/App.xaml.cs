using Ninject;
using RepoUpdater.Abstract;
using RepoUpdater.Helper;
using RepoUpdater.Model;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using RepoUpdater.ViewModels;
using RepoUpdater.ViewModels.Abstraction;
using System.Windows;
using TinyMessenger;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private IKernel _container;

        #endregion

        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureContainer();
            ComposeObjects();

            base.OnStartup(e);
        }

        private void ConfigureContainer()
        {
            _container = new StandardKernel();

            _container.Bind<IMainViewModel>().To<MainViewModel>();
            _container.Bind<INavigationManager>().To<NavigationManager>();
            _container.Bind<IRepositoryFactory>().To<RepositoryFactory>();
            _container.Bind<ITinyMessengerHub>().To<TinyMessengerHub>();
            _container.Bind<IApplicationSettings>().To<ApplicationSettings>();
            _container.Bind<IRepositoryListSerializer>().To<RepositoryXMLSerializer>();
            _container.Bind<IAddNewItemViewModel>().To<AddNewItemViewModel>();
            _container.Bind<IDispatcherTimer>().To<DispatcherTimerTimerRepository>();
            _container.Bind<IRepositoryUpdater>().To<RepositoryUpdater>();

            _container.Bind<IRepositoryList>().To<RepositoryList>().InSingletonScope();
        }

        private void ComposeObjects()
        {
            _container.Get<IRepositoryList>().Load();

            Current.MainWindow = _container.Get<MainWindow>();
            Current.MainWindow.Show();
        }

        #endregion
    }
}
