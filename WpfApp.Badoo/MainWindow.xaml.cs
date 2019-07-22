using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Logging;
using Infrastructure.Logging.Implementation;
using Infrastructure.Models;
using System;
using System.IO;
using System.Windows;

namespace WpfApp.Badoo
{
    public partial class MainWindow
    {
        private ILogger Logger { get; }

        public MainWindow()
        {
            InitializeComponent();

            this.Logger = new Logger();
            this.DataContext = new DialogViewModel();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

            //var vm = DataContext as DialogViewModel;

            //if (vm != null)
            //{
            //    var dialogResult = new DialogResult(
            //                            vm.SelectedSex,
            //                            vm.IsFree.IsChecked,
            //                            vm.DoesntHaveKids.IsChecked,
            //                            vm.IsNonSmoker.IsChecked,
            //                            vm.SelectedSearchLocation);
            //    try
            //    {
            //        var loginData = new LoginData("https://badoo.com/signin/", ConfigReader.Credentials);

            //        var executor = new HandlersExecutor(Logger);

            //        executor.RunBadooHandler(dialogResult, loginData);
            //    }
            //    catch (FileNotFoundException ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Log(ex.Message);

            //        DisplayErrorMessage();
            //    }
            //}
            //else
            //{
            //    Logger.Log($"Cannot cast viewmodel into '{nameof(DialogViewModel)}' type.");

            //    DisplayErrorMessage();
            //}
        }

        private static void DisplayErrorMessage()
        {
            MessageBox.Show("There was a problem with this application. Please contact support.");
        }
    }
}
