using SalesWPFApp.AdminWindows;
using SalesWPFApp.MemberWindows;
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

namespace SalesWPFApp.AdminWindow
{
    /// <summary>
    /// Interaction logic for ProductsManagerWindow.xaml
    /// </summary>
    public partial class ProductsManagerWindow : Window
    {
        private readonly LoginWindow.UserRole userRole;
        public ProductsManagerWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            AdjustUIForUserRole();
        }

        // Adjust UI for user roles 
        private void AdjustUIForUserRole()
        {
            if (userRole == LoginWindow.UserRole.Admin)
            {
                // For admin
                MenuItem dashboardMenu = new MenuItem { Header = "Dashboard", Background = Brushes.White };
                dashboardMenu.Click += (s, e) => HandleDashboardClick();

                MenuItem manageMenu = new MenuItem { Header = "Manage", Background = Brushes.White };
                manageMenu.Items.Add(new MenuItem { Header = "Members", Background = Brushes.White });
                manageMenu.Items.Add(new MenuItem { Header = "Products", Background = Brushes.White });
                manageMenu.Items.OfType<MenuItem>().First(item => item.Header.Equals("Members")).Click += (s, e) => HandleMembersClick();

                MenuItem reportMenu = new MenuItem { Header = "Report", Background = Brushes.White };
                reportMenu.Click += (s, e) => HandleReportClick();

                MenuItem logoutMenu = new MenuItem { Header = "Logout", Background = Brushes.White };
                logoutMenu.Click += (sender, e) => Logout();

                // Add to Menu bar
                menuBar.Items.Add(dashboardMenu);
                menuBar.Items.Add(manageMenu);
                menuBar.Items.Add(reportMenu);
                menuBar.Items.Add(logoutMenu);
            }
        }

        private void HandleDashboardClick()
        {
            MainWindow mainWindow = new MainWindow(LoginWindow.UserRole.Admin);
            this.Hide();
            mainWindow.Show();
        }

        private void HandleMembersClick()
        {
            MembersManagerWindow membersManagerWindow = new MembersManagerWindow();
            this.Hide();
            membersManagerWindow.Show();
        }

        private void HandleReportClick()
        {
            ReportManagerWindow reportManagerWindow = new ReportManagerWindow();
            this.Hide();
            reportManagerWindow.Show();
        }

        // Logout 
        private void Logout()
        {
            this.Hide(); // Hide the current window
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Closed += (s, args) =>
            {
                this.Close(); // Close the current window when the login window is closed 
            };
            loginWindow.Show();
        }

        // Close 
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Closed += (s, args) =>
            {
                e.Cancel = false;
            };
            this.Hide();
            loginWindow.Show();
        }

        // Mouse down 
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
