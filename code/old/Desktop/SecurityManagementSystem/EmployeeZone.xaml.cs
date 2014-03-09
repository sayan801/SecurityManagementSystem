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
    public partial class EmployeeZone : UserControl
    {
        public EmployeeZone()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchEmployeeData();
        }
        private void addEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

            SecurityManagementSystemEngine.EmployeeInformation newEmployee = new SecurityManagementSystemEngine.EmployeeInformation();

            newEmployee.id = GenerateId();

            newEmployee.name = employeeNameTxtbox.Text;
            newEmployee.addres = AddressNameTxtbox.Text;
            newEmployee.contact = contactTxtbox.Text;
            newEmployee.email = emailTxtbox.Text;
            newEmployee.homeNumber = homeNumberTxtbox.Text;
            newEmployee.joiningdate = joiningdateP.SelectedDate.Value;
            newEmployee.employeeType= employeeTypeCombobox.Text;
            newEmployee.remark = remarkTxtbox.Text;

            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DoEnterEmployee(newEmployee);
            EmployeeTC.SelectedIndex = 0;
            clearEmployeeFields();

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

      

        private EmployeeInformation GetSelectedEmployeeItem()
        {

            EmployeeInformation employeeToDelete = null;

            if (employeeView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                EmployeeInformation i = (EmployeeInformation)employeeView.SelectedItem;

                employeeToDelete = _allemployeeCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return employeeToDelete;
        }
        private void deleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInformation employeeToDelete = GetSelectedEmployeeItem();
            if (employeeToDelete != null)
            {
                _allemployeeCollection.Remove(employeeToDelete);
                SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DeleteEmployee(employeeToDelete.id);
                fetchEmployeeData();

            }
        }

        private void clearEmployeeFields()
        {
            employeeNameTxtbox.Text = AddressNameTxtbox.Text = contactTxtbox.Text = emailTxtbox.Text = homeNumberTxtbox.Text = employeeTypeCombobox.Text = remarkTxtbox.Text = "";
            joiningdateP.SelectedDate = DateTime.Now;
        }

        private void resetEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            clearEmployeeFields();
        }



        private void editEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInformation employeeToEdit = GetSelectedEmployeeItem();
            if (employeeToEdit != null)
            {
                EmployeeTC.SelectedIndex = 1;
                addEmployeeBtn.Visibility = Visibility.Collapsed;
                updateEmployeeBtn.Visibility = Visibility.Visible;
                employeeNameTxtbox.Text = employeeToEdit.name;
                AddressNameTxtbox.Text = employeeToEdit.addres;
                contactTxtbox.Text = employeeToEdit.contact;
                emailTxtbox.Text = employeeToEdit.email;
                homeNumberTxtbox.Text = employeeToEdit.homeNumber;
                joiningdateP.SelectedDate = employeeToEdit.joiningdate;
                employeeTypeCombobox.Text = employeeToEdit.employeeType;
                remarkTxtbox.Text = employeeToEdit.remark;
            }
        }

        private void updateEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInformation employeeToEdit = GetSelectedEmployeeItem();

            employeeToEdit.name = employeeNameTxtbox.Text;
            employeeToEdit.addres = AddressNameTxtbox.Text;
            employeeToEdit.contact = contactTxtbox.Text;
            employeeToEdit.email = emailTxtbox.Text;
            employeeToEdit.homeNumber = homeNumberTxtbox.Text;
            employeeToEdit.joiningdate = joiningdateP.SelectedDate.Value;
            employeeToEdit.employeeType = employeeTypeCombobox.Text;
            employeeToEdit.remark = remarkTxtbox.Text;

            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.EditEmployee(employeeToEdit);
            EmployeeTC.SelectedIndex = 0;
            clearEmployeeFields();
            updateEmployeeBtn.Visibility = Visibility.Collapsed;
            addEmployeeBtn.Visibility = Visibility.Visible;
        }


    }
}
