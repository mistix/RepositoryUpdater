using System.Windows;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for AddNewItem.xaml
    /// </summary>
    public partial class AddNewItem : Window
    {
        private readonly INavigationManager _navigationManager;

        public AddNewItem(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            InitializeComponent();
        }
    }
}
