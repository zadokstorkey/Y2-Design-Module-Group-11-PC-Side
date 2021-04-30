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
using System.Windows.Shapes;

namespace OscilloscopePCSide.View
{
    /// <summary>
    /// Interaction logic for DerivedSourcesTab.xaml
    /// </summary>
    public partial class DerivedSourcesTab : ContentControl
    {
        public DerivedSourcesTab()
        {
            InitializeComponent();
        }

        private void DerivedSourceListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var derivedSourceConfigWindow = new DerivedSourceConfigWindow();
            derivedSourceConfigWindow.DataContext = ((ListViewItem)sender).DataContext;
            derivedSourceConfigWindow.ShowDialog();
        }

        private void AddNewDerivedSourceListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((ListViewItem)sender).IsSelected = false;
            (this.DataContext as ISourcesTabViewModel).AddNewDerivedSource();
        }
    }
}
