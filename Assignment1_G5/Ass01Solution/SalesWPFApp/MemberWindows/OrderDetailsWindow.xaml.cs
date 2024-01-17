using BusinessObject.Objects;
using DataAccess.DAO;
using DataAccess.DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderDetailsWindow.xaml
    /// </summary>
    public partial class OrderDetailsWindow : Window
    {
        private readonly LoginWindow.UserRole userRole;
        private readonly OrderDetailObject orderDetailObject;
        IOrderDetailRepository orderDetailRepository;
        private readonly int _orderId;
        public OrderDetailsWindow(int orderId)
        {
            InitializeComponent();
            orderDetailObject = new OrderDetailObject(new OrderDetailRepository());
            orderDetailRepository = new OrderDetailRepository();
            Closing += MainWindow_Closing;
            this._orderId = orderId;
            LoadOrderDetailsList(_orderId);
        }

        // Close 
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        // Mouse down 
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            //    DragMove();
            //}
        }

        public void load_Data()
        {
            var products = context.Products.Include(p => p.Category).ToList();
            lvProd.ItemsSource = products;
            var categories = context.Categories.ToList();
            Categories = new ObservableCollection<Category>(categories);
            cbCateId.ItemsSource = Categories;
            cbCateId.DisplayMemberPath = "CategoryName";
            cbCateId.SelectedValuePath = "CategoryId";
        }

        // Bui Van Kien 
        // Get order detail object
        private OrderDetail GetOrderDetailObject()
        {
            OrderDetail orderDetail = null;
            try
            {
                orderDetail = new OrderDetail
                {
                    ProductId = int.Parse(txtProductId.Text),
                    OrderId = int.Parse(txtOrderId.Text),
                    UnitPrice = int.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = int.Parse(txtDiscount.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return orderDetail;
        }

        // Bui Van Kien 
        // Load order list by order id 
        private void LoadOrderDetailsList(int orderId)
        {
            dgOrderDetailList.ItemsSource = orderDetailRepository.GetOrderDetailListByOrderId(orderId);
        }

        // Bui Van Kien 
        // Add order detail button 
        private void btnInsertOd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailObject();
                orderDetailRepository.InsertOrderDetail(orderDetail);
                LoadOrderDetailsList(_orderId);
                MessageBox.Show("Insert new order detail successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert order detail");
            }
        }

        // Bui Van Kien 
        // Update order detail button 
        private void btnUpdateOd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailObject();
                OrderDetail existingOrderDetail = orderDetailRepository.GetOrderDetailById(int.Parse(txtOrderDetailId.Text));

                existingOrderDetail.ProductId = orderDetail.ProductId;
                existingOrderDetail.UnitPrice = orderDetail.UnitPrice;
                existingOrderDetail.Quantity = orderDetail.Quantity;
                existingOrderDetail.Discount = orderDetail.Discount;

                orderDetailRepository.UpdateOrderDetail(existingOrderDetail);
                LoadOrderDetailsList(_orderId);
                MessageBox.Show("Update order detail successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update order detail");
            }
        }

        // Bui Van Kien 
        // Delete order detail button 
        private void btnDeleteOd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailObject();
                OrderDetail existingOrderDetail = orderDetailRepository.GetOrderDetailById(int.Parse(txtOrderDetailId.Text));

                orderDetailRepository.DeleteOrderDetail(existingOrderDetail);
                LoadOrderDetailsList(_orderId);
                MessageBox.Show("Delete order detail successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order detail");
            }
        }

        // Bui Van Kien 
        // Close button 
        private void btnClose_Click(object sender, RoutedEventArgs e) => this.Hide();
    }
}
