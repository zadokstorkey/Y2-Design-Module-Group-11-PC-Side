using OscilloscopePCSide.ViewModel.ViewModelFactories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OscilloscopePCSide
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the top level view and its children
            var mainWindow = new MainWindow();

            // Create the top level viewmodel and its children
            var topLevelViewModelFactory = new TopLevelViewModelFactory();
            var topLevelViewModel = topLevelViewModelFactory.Create();

            // Bind the viewModel to the view
            mainWindow.DataContext = topLevelViewModel;

            // Show the window
            mainWindow.Show();
		}
	}
}
