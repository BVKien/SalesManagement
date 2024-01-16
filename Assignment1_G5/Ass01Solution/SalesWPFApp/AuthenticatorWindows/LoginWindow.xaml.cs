using BusinessObject.Objects;
using DataAccess.DataAccess;
using Microsoft.Extensions.Configuration;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly MemberObject memberObject;
        private readonly IConfiguration configuration;

        public enum UserRole
        {
            Admin,
            Member
        }
        public UserRole LoggedInUserRole { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
            memberObject = new MemberObject();
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // Login 
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new eStoreContext())
            {
                string enteredEmail = txtEmail.Text;
                string enteredPassword = txtPassword.Password;

                bool isAuthorized = memberObject.Login(enteredEmail, enteredPassword);

                string adminEmail = configuration["AdminAccount:Email"];
                string adminPassword = configuration["AdminAccount:Password"];

                if (enteredEmail == adminEmail && enteredPassword == adminPassword)
                {
                    LoggedInUserRole = UserRole.Admin;
                    MessageBox.Show("Admin login successful!");
                    MainWindow mainWindow = new MainWindow(LoggedInUserRole);
                    mainWindow.currentEmail = enteredEmail;
                    mainWindow.Show();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    Session.memberSession = context.Members.FirstOrDefault(x => x.Email.Equals(enteredEmail) && x.Password.Equals(enteredPassword));
                    this.Hide();


                }
                else if (isAuthorized)
                {
                    LoggedInUserRole = UserRole.Member;
                    MessageBox.Show("Member login successful!");
                    MainWindow mainWindow = new MainWindow(LoggedInUserRole);
                    mainWindow.currentEmail = enteredEmail;
                    mainWindow.Show();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    Session.memberSession = context.Members.FirstOrDefault(x => x.Email.Equals(enteredEmail) && x.Password.Equals(enteredPassword));
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Login failed, email and password are incorrect");
                }
            }
        }

        // Cancel 
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // + pop up verified 
            Application.Current.Shutdown();
        }

        // Close 
        private void LoginWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // + pop up verified 
            Application.Current.Shutdown();
        }

        // Mouse down 
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
