using DataAccess.DataAccess;
using DataAccess.Repository;
using SalesWPFApp.AdminWindow;
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
using static System.Collections.Specialized.BitVector32;

namespace SalesWPFApp.MemberWindows
{
    /// <summary>
    /// Interaction logic for UserProfileWindow.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        //eStoreContext context;
        //Vuong Quoc Anh
        IMemberRepository memberRepository;
        private Member currentMember;
        //Vuong Quoc Anh
        private readonly LoginWindow.UserRole userRole;
<<<<<<< HEAD
        //public int LoggedInMemberId { get; set; }
        public UserProfileWindow()
=======
        public string currentEmail = null;
        public UserProfileWindow(string email)
>>>>>>> 2c1080b21fe3ba225999b06d9c437e8ade278825
        {
            memberRepository = new MemberRepository();

            InitializeComponent();
            currentEmail = email;
            Closing += MainWindow_Closing;
            AdjustUIForUserRole();
            currentMember = memberRepository.GetMemberByEmail(currentEmail);
            Loaded += UserProfileWindow_Loaded;

        }

        private void UserProfileWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentMember != null)
            {
                txtEmail.Text = currentMember.Email;
                txtCountry.Text = currentMember.Country;
                txtCompanyName.Text = currentMember.CompanyName;
                txtCity.Text = currentMember.City;
                txtPassWord.Text = currentMember.Password;
            }
        }
        ////Vuong Quoc Anh
        //public UserProfileWindow(IMemberRepository repository)
        //{
        //    memberRepository = repository;
        //}
        //Vuong Quoc Anh


        // Adjust UI for user roles 
        private void AdjustUIForUserRole()
        {
            // For member
            MenuItem manageMenu = new MenuItem { Header = "Manage", Background = Brushes.White };
            manageMenu.Items.Add(new MenuItem { Header = "Profile", Background = Brushes.White });
            manageMenu.Items.Add(new MenuItem { Header = "Orders", Background = Brushes.White });
            manageMenu.Items.OfType<MenuItem>().First(item => item.Header.Equals("Orders")).Click += (s, e) => HandleOrdersClick();

            MenuItem logoutMenu = new MenuItem { Header = "Logout", Background = Brushes.White };
            logoutMenu.Click += (sender, e) => Logout();

            // Add to Menu bar 
            menuBar.Items.Add(manageMenu);
            menuBar.Items.Add(logoutMenu);
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

        //Vuong Quoc Anh

        private Member GetMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassWord.Text,
                    MemberId = Session.memberSession.MemberId
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetMemberObject();
                memberRepository.UpdateMember(member);
                Loaded += UserProfileWindow_Loaded;
                MessageBox.Show("Update success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Profile");
            }
        }
        //
    }
}
