using DataAccess.DataAccess;
using DataAccess.Repository;
using SalesWPFApp.AdminWindow;
using SalesWPFApp.MemberWindows;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using System.Windows.Controls; // For DataGrid
using System.Windows.Controls.Primitives;
using System.Data; // For SelectionChangedEventArgs

namespace SalesWPFApp.AdminWindows
{
    /// <summary>
    /// Interaction logic for MembersManagerWindow.xaml
    /// </summary>
    public partial class MembersManagerWindow : Window
    {
        IMemberRepository memberRepository;
        private readonly LoginWindow.UserRole userRole;
        public MembersManagerWindow()
        {
            memberRepository = new MemberRepository();
            InitializeComponent();
            //Closing += MainWindow_Closing;
            AdjustUIForUserRole();
            onLoadTable();
        }
        /// <summary>
        /// load table
        /// </summary>
        private void onLoadTable()
        {
            tableMember.ItemsSource = memberRepository.GetAll();
        }

        private void onLoadTable(List<Member> members)
        {
            tableMember.ItemsSource = members;
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

        private void btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                memberRepository.CreateMember(GetMemberObject());
                MessageBox.Show("Add new member successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                onLoadTable();
            }

        }
        private Member GetMemberObject()
        {
            Member member = new Member();
            try
            {
                member = new Member
                {
                    Email = inputEmail.Text,
                    CompanyName = inputCompanyName.Text,
                    City = inputCity.Text,
                    Country = inputCountry.Text,
                    Password = inputPassword.Text
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get member");
            }

            return member;

        }
        private Member GetMemberObject(int id)
        {
            Member member = memberRepository.GetMember(id);
            try
            {
                member.Email = inputEmail.Text;
                member.CompanyName = inputCompanyName.Text;
                member.City = inputCity.Text;
                member.Country = inputCountry.Text;
                member.Password = inputPassword.Text;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get member");
            }

            return member;

        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetMemberObject(getIdPicked());
                if (member == null)
                {
                    MessageBox.Show("Not found member id");
                    return;
                }
                memberRepository.UpdateMember(member);
                MessageBox.Show("Update member successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                onLoadTable();

            }
        }
        private int getIdPicked()
        {

            var item = (Member)tableMember.SelectedItem;
            if (item == null)
            {
                throw new Exception("Please select a member in the table");
            }
            var res = item.MemberId;
            return res;

        }
        private void btnRemove(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetMemberObject();
                member.MemberId = getIdPicked();
                if (memberRepository.GetMember(member.MemberId) == null)
                {
                    MessageBox.Show("Not found member id");
                    return;
                }
                memberRepository.DeleteMember(member.MemberId);
                MessageBox.Show("Remove member successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                onLoadTable();
            }
        }

        /// <summary>
        /// search event btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// @author: gitzno - thuyht
        /// @date: 16/01/2024
        private void btnSearch(object sender, RoutedEventArgs e)
        {
            List<Member> members = new List<Member>();
            try
            {
                if (inputSearch.Text == "")
                {
                    members = memberRepository.GetAll();
                }
                else
                {
                    List<Member> memberz = memberRepository.GetAll();
                    foreach (var item in memberz)
                    {
                        if (item.Email.Contains(inputSearch.Text))
                        {
                            members.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { onLoadTable(members); }
        }
    }
}
