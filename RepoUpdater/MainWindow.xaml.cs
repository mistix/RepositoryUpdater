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
        #region Fields

        private IMainViewModel _mainViewModel;

        #endregion

        #region Construcotrs

        public MainWindow(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
            _mainViewModel = mainViewModel;

            mainViewModel.CloseWindow += (sender, arguments) => Close();
        }

        #endregion

        #region Methods

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            _mainViewModel.Initialize();
        }

        #endregion
    }
}
