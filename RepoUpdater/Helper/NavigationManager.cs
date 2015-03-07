using Ninject;
using RepoUpdater.Abstract;

namespace RepoUpdater.Helper
{
    public class NavigationManager : INavigationManager
    {
        private readonly IKernel _ninjectKernel;

        public NavigationManager(IKernel ninjectKernel)
        {
            _ninjectKernel = ninjectKernel;
        }

        public void OpenAddNewItemWindow()
        {
            var window = _ninjectKernel.Get<AddNewItem>();

            if (!window.IsVisible)
                window.ShowDialog();
        }

        public void OpenSettingsWindow()
        {
            throw new System.NotImplementedException();
        }

        public void OpenAboutInformations()
        {
            throw new System.NotImplementedException();
        }
    }
}