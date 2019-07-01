using Infrastructure;
using Infrastructure.Models;
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

            var loginData = new LoginData(signInUrl: "https://badoo.com/signin/",
                                          email: "***",
                                          password: "***");

            var executor = new HandlersExecutor();

            executor.RunBadooHandler(dialogResult, loginData);
        }
    }
}
