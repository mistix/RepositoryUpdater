using Ninject;
using RepoUpdater.Abstract;
using RepoUpdater.Model;
using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.Factories;
using RepoUpdater.ViewModels;
using RepoUpdater.ViewModels.Abstraction;
using System.Configuration;
using System.Windows;
using TinyMessenger;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Constants

        private const string DefaultConfigurationFile = "DefaultConfigurationFile";
        private const string DefaultGitExecPath = "DefaultGitExecPath";
        private const string DefaultTfsExecPath = "DefaultTfsExecPath";

        #endregion

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
            _container.Get<IRepositoryList>().Load(ConfigurationManager.AppSettings[DefaultConfigurationFile]);
            Settings.GitPath = ConfigurationManager.AppSettings[DefaultGitExecPath];
            Settings.TFSPath = ConfigurationManager.AppSettings[DefaultTfsExecPath];

            Current.MainWindow = _container.Get<MainWindow>();
            Current.MainWindow.Show();
        }

        #endregion
    }
}
