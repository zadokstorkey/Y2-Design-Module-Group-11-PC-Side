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
    /// Interaction logic for ChannelConfigWindow.xaml
    /// </summary>
    public partial class SourceConfigWindow : Window
    {
        public SourceConfigWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ISourceConfigViewModel)DataContext).CancelChanges();
            }
            catch (ApplicationException ex)
            {

            }
        }

        private void Apply_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ISourceConfigViewModel)DataContext).ApplyChanges();
                this.Close();
            }
            catch (ApplicationException ex)
            {

            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (ApplicationException ex)
            {

            }
        }
    }
}
