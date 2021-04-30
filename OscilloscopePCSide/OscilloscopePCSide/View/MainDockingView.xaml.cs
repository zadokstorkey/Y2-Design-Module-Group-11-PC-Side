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
    /// Interaction logic for MailDockingView.xaml
    /// </summary>
    public partial class MainDockingView : ContentControl
    {
        public MainDockingView()
        {
            InitializeComponent();
        }

        private void NewTraceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ((TopLevelViewModel)this.DataContext).AddTraceTabViewModel();
        }

        private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
