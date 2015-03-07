using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace RepoUpdater.UserControls
{
    /// <summary>
    /// Interaction logic for FolderPicker.xaml
    /// </summary>
    public partial class FolderPicker : UserControl
    {
        #region Dependency properties

        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FolderPicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(FolderPicker), new PropertyMetadata(null));

        #endregion

        #region Properties

        public string Text
        {
            get { return GetValue(TextProperty) as string; }
            set { SetValue(TextProperty, value); }
        }

        public string Description
        {
            get { return GetValue(DescriptionProperty) as string; }
            set { SetValue(DescriptionProperty, value); }
        }

        #endregion

        #region Constructors

        public FolderPicker()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void BrowseFolder(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = Description;
                dialog.SelectedPath = Text;
                dialog.ShowNewFolderButton = true;
                DialogResult result = dialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                Text = dialog.SelectedPath;
                BindingExpression bindingExpression = GetBindingExpression(TextProperty);
                if (bindingExpression != null)
                    bindingExpression.UpdateSource();
            }
        }

        #endregion
    }
}
