using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;

namespace MSIextractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }        

        private void msiSelect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "MSI files (*.msi)|*.msi|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if(openFileDialog.ShowDialog() == true)
            {
                txtMSIPath.Text = openFileDialog.FileName;
            }
        }

        private void ResetControls()
        {
            txtMSIPath.IsEnabled = false;
            txtSaveFolder.IsEnabled = false;
        }

        private void saveFolderSelect_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;


            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                txtSaveFolder.Text = folderBrowserDialog.SelectedPath;
            }


        }

        private void convert_Click(object sender, RoutedEventArgs e)
        {
            ResetControls();
            string exeString = "msiexec";
            string argString = $"/a \"{txtMSIPath.Text}\" /qb TARGETDIR=\"{txtSaveFolder.Text}\"";
            Process.Start(exeString, argString);
        }
    }

    
}
