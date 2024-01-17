using DataAccess.DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using SalesWPFApp.AdminWindows;
using SalesWPFApp.MemberWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

    public partial class ProductsManagerWindow : Window
    {
        private readonly IProductRepository productRepository;
        public ObservableCollection<Category> Categories { get; set; }
        private static eStoreContext context;
        private readonly LoginWindow.UserRole userRole;
        public ProductsManagerWindow()
        {
            context = new eStoreContext();
            productRepository = new ProductRepository(context);
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

        public Product GetProductFromUI()
        {
            Product product = new Product();

            if (cbCateId.SelectedValue != null)
            {
                product.CategoryId = (int)cbCateId.SelectedValue;
            }
            else
            {
                product.CategoryId = 0;
            }

            product.ProductName = tbProdName.Text;
            product.Weight = string.IsNullOrWhiteSpace(tbWeight.Text) ? (float?)null : float.Parse(tbWeight.Text);

            if (int.TryParse(tbPrice.Text, out int unitPrice))
            {
                product.UnitPrice = unitPrice;
            }
            else
            {
                product.UnitPrice = 0;
            }

            if (int.TryParse(tbInStock.Text, out int unitInStock))
            {
                product.UnitInStock = unitInStock;
            }
            else
            {
                product.UnitInStock = 0;
            }

            return product;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            load_Data();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product newProduct = GetProductFromUI();
                productRepository.AddProduct(newProduct);
                load_Data();
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product selectedProduct = (Product)lvProd.SelectedItem;

                if (selectedProduct != null)
                {
                    Product updatedProduct = GetProductFromUI();
                    updatedProduct.ProductId = selectedProduct.ProductId;
                    productRepository.UpdateProduct(updatedProduct);
                    load_Data();
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a product to update.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product selectedProduct = (Product)lvProd.SelectedItem;

                if (selectedProduct != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        productRepository.DeleteProduct(selectedProduct.ProductId);

                        load_Data();

                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to delete.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Product searchProduct = GetProductFromUI();


                var foundProducts = productRepository.SearchProduct(searchProduct);


                lvProd.ItemsSource = foundProducts;

                MessageBox.Show("Search completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
