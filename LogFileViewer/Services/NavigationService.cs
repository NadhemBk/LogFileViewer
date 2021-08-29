using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogFileViewer.Services
{
    public class NavigationService : INavigationService
    {
        public void NavigateToMain()
        {
            var loginView = Application.Current.Windows.OfType<Views.LoginView>().SingleOrDefault();
            Application.Current.Dispatcher.Invoke(() => { ShowLogListView(); });
            loginView.Close();
        }

        private void ShowLogListView()
        {
            var logListView = Application.Current.Windows.OfType<Views.LogListView>().SingleOrDefault();

            if (logListView == null)
            {
                logListView = new Views.LogListView();
            }

            logListView.Show();
        }
    }
}
