using RepoUpdater.Presenters;
using System.Windows;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainPresenter();
        }
    }
}
