using DataAccess.DAO;
using DataAccess.ViewObjects;
using SalesWPFApp.AdminWindows;
using SalesWPFApp.MemberWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for ReportManagerWindow.xaml
    /// </summary>
    public partial class ReportManagerWindow : Window
    {
        private readonly LoginWindow.UserRole userRole;
        public ReportManagerWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            AdjustUIForUserRole();
        }

        int BtnClicked = 0;

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

        private void Form_Loaded(object sender, EventArgs e)
        {
            lblHeader.Visibility = Visibility.Hidden;
            lblTotalMoney.Visibility = Visibility.Hidden;
            dtgInfo.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BtnClicked % 2 == 0)
            {
                var DateFrom = DatePickerFrom.SelectedDate;
                if (DateFrom == null)
                {
                    MessageBox.Show("Must select From Date");
                    return;
                }

                var DateTo = DatePickerTo.SelectedDate;
                if (DateTo == null)
                {
                    MessageBox.Show("Must select To Date");
                    return;
                }
                DatePickerFrom.Visibility = Visibility.Hidden;
                DatePickerTo.Visibility = Visibility.Hidden;
                lblSubtract.Visibility = Visibility.Hidden;

                lblHeader.Visibility = Visibility.Visible;
                lblTotalMoney.Visibility = Visibility.Visible;
                dtgInfo.Visibility = Visibility.Visible;

                SearchBtn.Content = "Clear";

                OrderDAO dao = new OrderDAO();
                ObservableCollection < OrderReport > DataList = new(dao.GetOrderReport(DateFrom.Value, DateTo.Value));

                dtgInfo.Columns.Add(new DataGridTextColumn() { Header = "Order Date", Width= Width/4-1, Binding = new System.Windows.Data.Binding("OrderDate") });
                dtgInfo.Columns.Add(new DataGridTextColumn() { Header = "Shipped Date", Width = Width / 4-1, Binding = new System.Windows.Data.Binding("ShippedDate") });
                dtgInfo.Columns.Add(new DataGridTextColumn() { Header = "Revenue", Width = Width / 4-1, Binding = new System.Windows.Data.Binding("Revenue") });

                DataGridTemplateColumn detailsColumn = new DataGridTemplateColumn()
                {
                    Header = "Details",
                    CellTemplate = (DataTemplate)Resources["DetailsButtonTemplate"],
                    Width = Width / 4-1
                };
                dtgInfo.Columns.Add(detailsColumn);
                dtgInfo.ItemsSource = DataList;
                lblTotalMoney.Text = DataList.Sum(x => x.Revenue).ToString();
                BtnClicked++;
            }
            else
            {
                DatePickerFrom.Visibility = Visibility.Visible;
                DatePickerTo.Visibility = Visibility.Visible;
                lblSubtract.Visibility = Visibility.Visible;

                lblHeader.Visibility = Visibility.Hidden;
                lblTotalMoney.Visibility = Visibility.Hidden;
                dtgInfo.Visibility = Visibility.Hidden;
                SearchBtn.Content = "Search";
                BtnClicked++;
            }
        }
    }
}
