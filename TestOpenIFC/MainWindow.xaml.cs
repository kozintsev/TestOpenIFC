using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

using Xbim.IO;

namespace TestOpenIFC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Xbim модели, открытые для теста и для мержа
        private XbimModel testModel;
        private XbimModel firsModel;
        private XbimModel secondModel;
        // в переменную передаётся полный путь к файлу, который был открыт
        private string ifcFilename;

        public MainWindow()
        {
            InitializeComponent();
        }

        private XbimModel GetXbimModelByFileName(string ifcFilename)
        {
            //tempModel = GetXbimModelByFileName(dlg.FileName);           
            var model = new XbimModel();
            try
            {
                string _temporaryXbimFileName = Path.GetTempFileName();
                //SetOpenedModelFileName(ifcFilename);
                model.CreateFrom(ifcFilename, _temporaryXbimFileName, null, true);
                labelDBname.Content = model.IfcProject.Name.ToString();
                labelGeometriesCount.Content = model.IfcProject.Phase.ToString();
                if (model != null)
                {
                    lCanEdit.Content = model.CanEdit.ToString();
                    lResult.Content = "IFC Correct.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
                model = null;
            }
            return model;
        }

        private string CreateOpenFileDialog()
        {
            string filename = String.Empty;
            var dlg = new OpenFileDialog();
            dlg.Filter = "IFC Files|;*.ifc;*.ifcxml;*.ifczip"; // Filter files by extension
            dlg.FileOk += delegate (object sender, System.ComponentModel.CancelEventArgs e)
            {
                //var dlg = sender as OpenFileDialog;
                if (dlg != null)
                {
                    filename = dlg.FileName;          
                }
            };
            //Dlg_FileOk;
            dlg.ShowDialog(this);
            return filename;
        }
           
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            testModel = GetXbimModelByFileName(CreateOpenFileDialog());

        }

        private void btnOpenIFCOne_Click(object sender, RoutedEventArgs e)
        {
            firsModel = GetXbimModelByFileName(CreateOpenFileDialog());
        }

        private void btnOpenIFCTwo_Click(object sender, RoutedEventArgs e)
        {
            secondModel = GetXbimModelByFileName(CreateOpenFileDialog());
        }

        private void btnMerge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            fileListBox.Items.Add(CreateOpenFileDialog());
        }
    }
}
