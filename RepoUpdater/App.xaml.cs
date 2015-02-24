using Ninject;
using RepoUpdater.Model.Factories;
using RepoUpdater.ViewModels;
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

            _container.Bind<AddNewItem>().ToSelf().InSingletonScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = _container.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
