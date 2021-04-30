using AvalonDock.Layout;
using OscilloscopePCSide.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace OscilloscopePCSide.View
{
    /// <summary>
    /// Interaction logic for SourcesPane.xaml
    /// </summary>
    public partial class SourcesTab : ContentControl
    {
        public SourcesTab()
        {
            InitializeComponent();
        }


        private void SourceListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var sourceConfigWindow = new SourceConfigWindow();
            sourceConfigWindow.DataContext = ((ListViewItem)sender).DataContext;
            sourceConfigWindow.ShowDialog();
        }

        private void DerivedSourceListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var derivedSourceConfigWindow = new DerivedSourceConfigWindow();
            derivedSourceConfigWindow.DataContext = ((ListViewItem)sender).DataContext;
            derivedSourceConfigWindow.ShowDialog();
        }

        private void AddNewSourceListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((ListViewItem)sender).IsSelected = false;
            (this.DataContext as ISourcesTabViewModel).AddNewSource();
        }

        private void AddNewDerivedSourceListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((ListViewItem)sender).IsSelected = false;
            (this.DataContext as ISourcesTabViewModel).AddNewDerivedSource();
        }
    }
}
