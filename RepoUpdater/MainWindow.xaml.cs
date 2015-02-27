using RepoUpdater.ViewModels.Abstraction;
using System.Windows;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IMainViewModel mainViewModel)
        {
            InitializeComponent();

            DataContext = mainViewModel;

            mainViewModel.CloseWindow += (sender, arguments) => Close();
        }
    }
}
