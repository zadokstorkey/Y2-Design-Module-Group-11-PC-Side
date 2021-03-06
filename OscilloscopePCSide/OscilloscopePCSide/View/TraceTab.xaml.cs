﻿using AvalonDock.Layout;
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

        private void ProbeClicked(object sender, RoutedEventArgs e)
        {
            if ((sender as ListViewItem).IsSelected)
            {
                ((ITraceSourceViewModel)((ListViewItem)sender).DataContext).HandleToggleVisibility();

                // Wait for 50ms for the operation to finish and then unselect everything
                //  this is really hacky and should be replaced with something better at some point
                var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
                timer.Start();
                timer.Tick += (sender2, args) =>
                {
                    timer.Stop();
                    visibilityListView.UnselectAll();
                };
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.VoltageScale = viewModel.VoltageScale;
            viewModel.VoltageOffset = viewModel.VoltageOffset;
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.TraceHeight = (sender as Border).ActualHeight;
        }

        private void Border_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.TraceHeight = e.NewSize.Height;
        }

        private void IncreaseScaleButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.VoltageScale++;
        }

        private void DecreaseScaleButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.VoltageScale--;
        }

        private void IncreaseOffsetButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.VoltageOffset++;
        }

        private void DecreaseOffsetButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ITraceTabViewModel;
            viewModel.VoltageOffset--;
        }
    }
}
