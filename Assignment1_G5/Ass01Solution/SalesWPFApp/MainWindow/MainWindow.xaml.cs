using SalesWPFApp.AdminWindow;
using SalesWPFApp.AdminWindows;
using SalesWPFApp.MemberWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string currentEmail = null;
        private readonly LoginWindow.UserRole userRole;
        //public int LoggedInMemberId { get; set; }
        public MainWindow(LoginWindow.UserRole userRole)
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            this.userRole = userRole;
            AdjustUIForUserRole();
        }

        // Adjust UI for user roles 
        private void AdjustUIForUserRole()
        {
            if (userRole == LoginWindow.UserRole.Admin)
            {
                // For admin
                MenuItem dashboardMenu = new MenuItem { Header = "Dashboard", Background = Brushes.White };

                MenuItem manageMenu = new MenuItem { Header = "Manage", Background = Brushes.White };
                manageMenu.Items.Add(new MenuItem { Header = "Members", Background = Brushes.White });
                manageMenu.Items.Add(new MenuItem { Header = "Products", Background = Brushes.White });
                manageMenu.Items.OfType<MenuItem>().First(item => item.Header.Equals("Members")).Click += (s, e) => HandleMembersClick();
                manageMenu.Items.OfType<MenuItem>().First(item => item.Header.Equals("Products")).Click += (s, e) => HandleProductsClick();

                MenuItem reportMenu = new MenuItem { Header = "Report", Background = Brushes.White };
                reportMenu.Click += (s, e) => HandleReportClick();

                MenuItem logoutMenu = new MenuItem { Header = "Logout", Background = Brushes.White };
                logoutMenu.Click += (sender, e) => Logout();

                // Add to Menu bar
                menuBar.Items.Add(dashboardMenu);
                menuBar.Items.Add(manageMenu);
                menuBar.Items.Add(reportMenu);
                menuBar.Items.Add(logoutMenu);

                // Insert TextBox
                Label textBox = new Label
                {
                    Content = "Welcome Admin",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 20,
                    IsEnabled= true,
                };
                // Add the TextBox to the UI
                gridLayout.Children.Add(textBox);
            }
            else
            {
                // For member
                MenuItem manageMenu = new MenuItem { Header = "Manage", Background = Brushes.White };
                manageMenu.Items.Add(new MenuItem { Header = "Profile", Background = Brushes.White });
                manageMenu.Items.Add(new MenuItem { Header = "Orders", Background = Brushes.White });
                manageMenu.Items.OfType<MenuItem>().First(item => item.Header.Equals("Profile")).Click += (s, e) => HandleProfileClick();
                manageMenu.Items.OfType<MenuItem>().First(item => item.Header.Equals("Orders")).Click += (s, e) => HandleOrdersClick();

                MenuItem logoutMenu = new MenuItem { Header = "Logout", Background = Brushes.White };
                logoutMenu.Click += (sender, e) => Logout();

                // Add to Menu bar 
                menuBar.Items.Add(manageMenu);
                menuBar.Items.Add(logoutMenu);

                // Insert TextBox
                TextBox textBox = new TextBox
                {
                    Text = "Welcome Member",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 20,
                    IsEnabled = true,
                };
                // Add the TextBox to the UI
                gridLayout.Children.Add(textBox);
            }
        }

        private void HandleMembersClick()
        {
            MembersManagerWindow membersManagerWindow = new MembersManagerWindow();
            this.Hide();
            membersManagerWindow.Show();
        }

        private void HandleProductsClick()
        {
            ProductsManagerWindow productsManagerWindow = new ProductsManagerWindow();
            this.Hide();
            productsManagerWindow.Show();
        }

        private void HandleReportClick()
        {
            ReportManagerWindow reportManagerWindow = new ReportManagerWindow();
            this.Hide();
            reportManagerWindow.Show();
        }

        private void HandleProfileClick()
        {
            UserProfileWindow userProfileWindow = new UserProfileWindow(currentEmail);
            this.Hide();
            userProfileWindow.Show();
        }

        private void HandleOrdersClick()
        {
            OrdersManagerWindow ordersManagerWindow = new OrdersManagerWindow(currentEmail);
            this.Hide();
            ordersManagerWindow.Show();
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
