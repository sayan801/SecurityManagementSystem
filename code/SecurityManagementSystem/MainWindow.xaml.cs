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

        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.RegisterVisitor RegisterVisitorobj = new SecurityManagementSystem.RegisterVisitor();
            mainUG.Children.Clear();
            mainUG.Children.Add(RegisterVisitorobj);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.Login Loginobj = new SecurityManagementSystem.Login();
            mainUG.Children.Clear();
            mainUG.Children.Add(Loginobj);
        }

        private void vidBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.VideoSurveillance VideoSurveillanceObj = new SecurityManagementSystem.VideoSurveillance();
            mainUG.Children.Clear();
            mainUG.Children.Add(VideoSurveillanceObj);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystem.Login Loginobj = new SecurityManagementSystem.Login();
            mainUG.Children.Clear();
            mainUG.Children.Add(Loginobj);

         
         
        }

        private void internetMnu_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://www.msn.com");
        }
    }
}
