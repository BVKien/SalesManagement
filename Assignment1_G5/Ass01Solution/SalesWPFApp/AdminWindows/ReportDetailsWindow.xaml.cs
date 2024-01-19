//using BusinessObject.Objects;
//using DataAccess.DataAccess;
//using DataAccess.Repository;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;


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

namespace SalesWPFApp.AdminWindows
{
    /// <summary>
    /// Interaction logic for ReportDetailsWindow.xaml
    /// </summary>
    public partial class ReportDetailsWindow : Window
    {
        private readonly LoginWindow.UserRole userRole;
        private readonly OrderDetailObject orderDetailObject;
        IOrderDetailRepository orderDetailRepository;
        private static eStoreContext context;
        private readonly IProductRepository productRepository;
        private readonly int _orderId;

        public ObservableCollection<Product> Products { get; set; }

        public ReportDetailsWindow(int orderId)
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

        public ReportDetailsWindow()
        {
            InitializeComponent();
            orderDetailObject = new OrderDetailObject(new OrderDetailRepository());
            orderDetailRepository = new OrderDetailRepository();
            context = new eStoreContext();
            productRepository = new ProductRepository(context);
            Closing += MainWindow_Closing;
        }

        // Bui Van Kien 
        // Load order list by order id 
        private void LoadOrderDetailsList(int orderId)
        {
            dgOrderDetailList.ItemsSource = orderDetailRepository.GetOrderDetailListByOrderId(orderId);
        }

        // Close 
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        // Bui Van Kien 
        // Close button 
        private void btnClose_Click(object sender, RoutedEventArgs e) => this.Hide();
    }
}
