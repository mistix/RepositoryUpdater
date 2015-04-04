using RepoUpdater.ViewModels.Abstraction;
using System;
using System.Windows;

namespace RepoUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Construcotrs

        public MainWindow(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;

            mainViewModel.CloseWindow += (sender, arguments) => Close();
            mainViewModel.ShowHideWindow += MainViewModelOnShowHideWindow;

            mainViewModel.Initialize();
        }

        #endregion

        #region Private Methods

        private void MainViewModelOnShowHideWindow(object sender, EventArgs eventArgs)
        {
            Visibility = Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        #endregion
    }
}
