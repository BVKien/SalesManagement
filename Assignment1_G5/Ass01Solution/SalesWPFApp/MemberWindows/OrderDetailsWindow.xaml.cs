using BusinessObject.Objects;
using DataAccess.DAO;
using DataAccess.DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
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
        private static eStoreContext context;
        private readonly IProductRepository productRepository;
        private readonly int _orderId;

        public ObservableCollection<Product> Products { get; private set; }

        public OrderDetailsWindow(int orderId)
        {
            InitializeComponent();
            orderDetailObject = new OrderDetailObject(new OrderDetailRepository());
            orderDetailRepository = new OrderDetailRepository();
            context = new eStoreContext();
            productRepository = new ProductRepository(context);
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

        // Bui Van Kien 
        // Get order detail object
        //private OrderDetail GetOrderDetailObject()
        //{
        //    OrderDetail orderDetail = null;
        //    try
        //    {
        //        orderDetail = new OrderDetail
        //        {
        //            ProductId = (int)cbProductId.SelectedValue,
        //            OrderId = _orderId,
        //            UnitPrice = int.Parse(txtUnitPrice.Text),
        //            Quantity = int.Parse(txtQuantity.Text),
        //            Discount = int.Parse(txtDiscount.Text),
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Get order");
        //    }
        //    return orderDetail;
        //}

        private OrderDetail GetOrderDetailObject()
        {
            OrderDetail orderDetail = null;
            try
            {
                int productId = 0;
                int unitPrice = 0;
                int quantity = 0;
                int discount = 0;

                if (cbProductId.SelectedValue != null && int.TryParse(cbProductId.SelectedValue.ToString(), out productId) &&
                    !string.IsNullOrEmpty(txtUnitPrice.Text) && int.TryParse(txtUnitPrice.Text, out unitPrice) &&
                    !string.IsNullOrEmpty(txtQuantity.Text) && int.TryParse(txtQuantity.Text, out quantity) &&
                    !string.IsNullOrEmpty(txtDiscount.Text) && int.TryParse(txtDiscount.Text, out discount))
                {
                    orderDetail = new OrderDetail
                    {
                        ProductId = (int)cbProductId.SelectedValue,
                        OrderId = _orderId,
                        UnitPrice = int.Parse(txtUnitPrice.Text),
                        Quantity = int.Parse(txtQuantity.Text),
                        Discount = int.Parse(txtDiscount.Text),
                    };
                }
                else
                {
                    MessageBox.Show("Please enter valid values for Product, Unit Price, Quantity, and Discount.");
                    orderDetail = null;
                }
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
            // Combobox 
            var products = context.Products.ToList();
            Products = new ObservableCollection<Product>(products);
            cbProductId.ItemsSource = Products;
            cbProductId.DisplayMemberPath = "ProductName";
            cbProductId.SelectedValuePath = "ProductId";
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
