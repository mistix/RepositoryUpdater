using RepoUpdater.ViewModels.Abstraction;
using System.Windows;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for AddNewItem.xaml
    /// </summary>
    public partial class AddNewItem : Window
    {
        public AddNewItem(IAddNewItemViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
            viewModel.CloseWindow += (sender, arguments) => Hide();
        }
    }
}
