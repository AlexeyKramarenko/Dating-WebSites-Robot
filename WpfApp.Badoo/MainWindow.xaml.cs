using Infrastructure;
using Infrastructure.Files;
using Infrastructure.Models;
using System;
using System.Windows;

namespace WpfApp.Badoo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new DialogViewModel();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = (DialogViewModel)DataContext;

            var dialogResult = new DialogResult(
                                        vm.SelectedSex,
                                        vm.IsFree.IsChecked,
                                        vm.DoesntHaveKids.IsChecked,
                                        vm.IsNonSmoker.IsChecked,
                                        vm.SelectedSearchLocation);
            try
            {
                var loginData = new LoginData("https://badoo.com/signin/", ConfigReader.Credentials);

                var executor = new HandlersExecutor();

                executor.RunBadooHandler(dialogResult, loginData);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
