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

namespace SalesWPFApp.MemberWindows
{
    /// <summary>
    /// Interaction logic for OrdersManagerWindow.xaml
    /// </summary>
    public partial class OrdersManagerWindow : Window
    {
        public string currentEmail = null;
        private readonly LoginWindow.UserRole userRole;
        public OrdersManagerWindow(string email)
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            currentEmail= email;
            AdjustUIForUserRole();
        }

        // Adjust UI for user roles 
        private void AdjustUIForUserRole()
        {
            // For member
            MenuItem manageMenu = new MenuItem { Header = "Manage", Background = Brushes.White };
            manageMenu.Items.Add(new MenuItem { Header = "Profile", Background = Brushes.White });
            manageMenu.Items.Add(new MenuItem { Header = "Orders", Background = Brushes.White });
                manageMenu.Items.OfType<MenuItem>().First(item => item.Header.Equals("Profile")).Click += (s, e) => HandleProfileClick();

            MenuItem logoutMenu = new MenuItem { Header = "Logout", Background = Brushes.White };
            logoutMenu.Click += (sender, e) => Logout();

            // Add to Menu bar 
            menuBar.Items.Add(manageMenu);
            menuBar.Items.Add(logoutMenu);
        }

        private void HandleProfileClick()
        {
            UserProfileWindow userProfileWindow = new UserProfileWindow(currentEmail);
            this.Hide();
            userProfileWindow.Show();
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
