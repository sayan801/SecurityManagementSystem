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
using System.Collections.ObjectModel;


namespace SecurityManagementSystem
{
    /// <summary>
    /// Interaction logic for EmployeeZone.xaml
    /// </summary>
    public partial class SecurityGuardZone : UserControl
    {
        public SecurityGuardZone()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchEmployeeData();
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

            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DoEnterEmployee(newEmployee);


        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }




        ObservableCollection<EmployeeInformation> _allemployeeCollection = new ObservableCollection<EmployeeInformation>();


        public ObservableCollection<EmployeeInformation> allemployeeCollection
        {
            get
            {
                return _allemployeeCollection;
            }
        }

        private void fetchEmployeeData()
        {
            List<EmployeeInformation> Employees = SecurityManagementSystemStorageInteraction.GetAllEmployeeList();

            _allemployeeCollection.Clear();

            foreach (EmployeeInformation employee in Employees)
            {
                _allemployeeCollection.Add(employee);
            }
        }



    }
}
