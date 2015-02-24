using Ninject;

namespace RepoUpdater
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
                window.Show();
        }
    }

    public interface INavigationManager
    {
        void OpenAddNewItemWindow();
    }
}