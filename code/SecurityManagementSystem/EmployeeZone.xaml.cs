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
using SecurityManagementSystemEngine;
using SecurityManagementSystemStorage;


namespace SecurityManagementSystem
{
    /// <summary>
    /// Interaction logic for EmployeeZone.xaml
    /// </summary>
    public partial class EmployeeZone : UserControl
    {
        public EmployeeZone()
        {
            InitializeComponent();
        }

        private void doregBtn_Click(object sender, RoutedEventArgs e)
        {

            SecurityManagementSystemEngine.EmployeeInformation newEmployee = new SecurityManagementSystemEngine.EmployeeInformation();

            newEmployee.id = GenerateId();

            newEmployee.name = employeeNameTxtbox.Text;
            newEmployee.addres = AddressNameTxtbox.Text;
            newEmployee.contact = contactTxtbox.Text;
            newEmployee.email = emailTxtbox.Text;
            newEmployee.homeNumber = homeNumberTxtbox.Text;
            newEmployee.joiningdate = joiningdateP.SelectedDate.Value;
            newEmployee.remark = remarkTxtbox.Text;

            SecurityManagementSystemStorage.SecurityManagementSystemStorage.DoEnterEmployee(newEmployee);


        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
