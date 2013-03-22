using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecurityManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void visitorMngBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.ManageVisitors ManageVisitorsobj = new SecurityManagementSystem.ManageVisitors();
            mainUG.Children.Clear();
            mainUG.Children.Add(ManageVisitorsobj);
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void permBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.Permission objPermission = new SecurityManagementSystem.Permission();
            mainUG.Children.Clear();
            mainUG.Children.Add(objPermission);
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.RegisterVisitor RegisterVisitorobj = new SecurityManagementSystem.RegisterVisitor();
            mainUG.Children.Clear();
            mainUG.Children.Add(RegisterVisitorobj);
        }

        

        private void vidBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.VideoSurveillance VideoSurveillanceObj = new SecurityManagementSystem.VideoSurveillance();
            mainUG.Children.Clear();
            mainUG.Children.Add(VideoSurveillanceObj);
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    SecurityManagementSystem.Login Loginobj = new SecurityManagementSystem.Login();
        //    mainUG.Children.Clear();
        //    mainUG.Children.Add(Loginobj);

         
         
        //}

        //private void internetMnu_Click(object sender, RoutedEventArgs e)
        //{
        //    System.Diagnostics.Process.Start("iexplore.exe", "http://www.msn.com");
        //}

        private void dologinBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userNameTxtbox.Text == "1" && passwordBox.Password == "1")
            {
                mainToolbar.IsEnabled = true;
                //loginBtn.Visibility = Visibility.Collapsed;
                SecurityManagementSystem.RegisterVisitor RegisterVisitorobj = new SecurityManagementSystem.RegisterVisitor();
                mainUG.Children.Clear();
                mainUG.Children.Add(RegisterVisitorobj);
                logoutBtn.Visibility = Visibility.Visible;
                //fstsptr.Visibility = Visibility.Collapsed;
                logoutsptr.Visibility = Visibility.Visible;
            }
            else
            {
                msgShow.Content = "Wrong Info";
                
            }
            
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            mainToolbar.IsEnabled = false;
            logoutBtn.Visibility = Visibility.Collapsed;
            //loginBtn.Visibility = Visibility.Visible;
            mainUG.Children.Clear();
            mainUG.Children.Add(mainLoginDoc);
            userTypeCombobox.SelectedIndex = 1;
            userNameTxtbox.Text = string.Empty;
            passwordBox.Password = string.Empty;
            //fstsptr.Visibility = Visibility.Visible;
            logoutsptr.Visibility = Visibility.Collapsed;
            msgShow.Content = "";

        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            userTypeCombobox.SelectedIndex = 2;
            userNameTxtbox.Text = string.Empty;
            passwordBox.Password = string.Empty;
            msgShow.Content = "Field Reseted";
        }

        private void residenceZoneBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.ResidenceZone ResidenceZoneObj = new SecurityManagementSystem.ResidenceZone();
            mainUG.Children.Clear();
            mainUG.Children.Add(ResidenceZoneObj);
        }

        private void employeeZoneBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.EmployeeZone EmployeeZoneobj = new SecurityManagementSystem.EmployeeZone();
            mainUG.Children.Clear();
            mainUG.Children.Add(EmployeeZoneobj);
        }

        private void securityGuardZone_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.SecurityGuardZone SecurityGuardZoneobj = new SecurityManagementSystem.SecurityGuardZone();
            mainUG.Children.Clear();
            mainUG.Children.Add(SecurityGuardZoneobj);
            
        }

        private void NotificationBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.Notifications objNotifications = new SecurityManagementSystem.Notifications();
            mainUG.Children.Clear();
            mainUG.Children.Add(objNotifications);
        }

        private void workorderZone_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.Workorder objWorkorder = new SecurityManagementSystem.Workorder();
            mainUG.Children.Clear();
            mainUG.Children.Add(objWorkorder);
        }

       

        

        
    }
}
