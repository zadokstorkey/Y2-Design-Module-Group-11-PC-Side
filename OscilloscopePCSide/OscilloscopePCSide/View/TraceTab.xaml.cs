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
using System.Windows.Threading;

namespace OscilloscopePCSide.View
{
    /// <summary>
    /// Interaction logic for TracePane.xaml
    /// </summary>
    public partial class TraceTab : ContentControl
    {

        public TraceTab()
        {
            InitializeComponent();
        }

        private void Probe1Clicked(object sender, RoutedEventArgs e)
        {
            if ((sender as ListViewItem).IsSelected)
            {
                (this.DataContext as ITraceTabViewModel).HandleProbe1Clicked();

                // Wait for 50ms for the operation to finish and then unselect everything
                //  this is really hacky and should be replaced with something better at some point
                var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
                timer.Start();
                timer.Tick += (sender2, args) =>
                {
                    timer.Stop();
                    ((sender as ListViewItem).Parent as ListView).UnselectAll();
                };
            }
        }

        private void Probe2Clicked(object sender, RoutedEventArgs e)
        {
            if ((sender as ListViewItem).IsSelected)
            {
                (this.DataContext as ITraceTabViewModel).HandleProbe2Clicked();

                // Wait for 50ms for the operation to finish and then unselect everything
                //  this is really hacky and should be replaced with something better at some point
                var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
                timer.Start();
                timer.Tick += (sender2, args) =>
                {
                    timer.Stop();
                    ((sender as ListViewItem).Parent as ListView).UnselectAll();
                };
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.VoltageScale = viewModel.VoltageScale;
        }
    }
}
