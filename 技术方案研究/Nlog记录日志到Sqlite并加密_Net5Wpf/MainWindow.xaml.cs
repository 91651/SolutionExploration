using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nlog记录日志到Sqlite并加密_Net5Wpf.Data;

namespace Nlog记录日志到Sqlite并加密_Net5Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger _logger;
        public MainWindow()
        {
            _logger = App.Container.GetService<ILogger<MainWindow>>();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _logger.LogInformation(DateTime.Now.ToString());
            // _logger.LogInformation(new Customer() { Id = 1, Name = "A1" });
        }
    }
}
