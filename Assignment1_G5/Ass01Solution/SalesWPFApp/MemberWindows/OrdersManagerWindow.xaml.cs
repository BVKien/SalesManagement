using BusinessObject.Objects;
using DataAccess.DAO;
using DataAccess.DataAccess;
using DataAccess.Repository;
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
        private readonly OrderObject orderObject;
        private readonly int loggedInMemberId = 1; // Đang hardcode 
        IOrderRepository orderRepository;
        // public OrdersManagerWindow();
        public OrdersManagerWindow(string email)
        {
            InitializeComponent();
            orderObject = new OrderObject(new OrderRepository());
            orderRepository = new OrderRepository();
            Closing += MainWindow_Closing;
            currentEmail= email;
            AdjustUIForUserRole();
            LoadOrderList();
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

        // Bui Van Kien
        // Load order list 
        public void LoadOrderList()
        {
            //dgOrderList.ItemsSource = orderRepository.GetOrderList();
            dgOrderList.ItemsSource = orderRepository.GetOrderListByMemberId(Session.memberSession.MemberId);
        }

        // Bui Van Kien 
        // Get order object
        private Order GetOrderObject()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = dpOrderDate.SelectedDate ?? DateTime.MinValue,
                    RequiredDate = dpRequiredDate.SelectedDate,
                    ShippedDate = dpShippedDate.SelectedDate ?? DateTime.MinValue,
                    Freight = string.IsNullOrEmpty(txtFreight.Text) ? (int?)null : int.Parse(txtFreight.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return order;
        }

        // Bui Van Kien 
        // Add new order button 
        private void btnInsertOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetOrderObject();
                orderRepository.InsertOrder(order);
                LoadOrderList();
                MessageBox.Show("Insert new order successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert order");
            }
        }

        // Bui Van Kien 
        // Update order button 
        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetOrderObject();
                Order existingOrder = orderRepository.GetOrderById(int.Parse(txtOrderId.Text));

                existingOrder.OrderDate = order.OrderDate;
                existingOrder.RequiredDate = order.RequiredDate;
                existingOrder.ShippedDate = order.ShippedDate;
                existingOrder.Freight = order.Freight;
                
                orderRepository.UpdateOrder(existingOrder);
                LoadOrderList();
                MessageBox.Show("Update order successfully!");
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Update order");
            }
        }

        // Bui Van Kien 
        // Delete order button 
        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetOrderObject();
                Order existingOrder = orderRepository.GetOrderById(int.Parse(txtOrderId.Text));

                orderRepository.DeleteOrder(existingOrder);
                LoadOrderList();
                MessageBox.Show("Delete order successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order");
            }
        }
        
        // Bui Van Kien 
        // View order detail button 
        private void btnViewOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order existingOrder = orderRepository.GetOrderById(int.Parse(txtOrderId.Text));
                OrderDetailsWindow orderDetailsWindow = new OrderDetailsWindow(existingOrder.OrderId);
                orderDetailsWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "View Order Details");
            }
        }
    }
}
