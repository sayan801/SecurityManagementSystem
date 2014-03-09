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
    /// Interaction logic for Permission.xaml
    /// </summary>
    public partial class Permission : UserControl
    {
        public Permission()
        {
            InitializeComponent();
        }

        ObservableCollection<VisitorInformation> _visitorCollection = new ObservableCollection<VisitorInformation>();


        public ObservableCollection<VisitorInformation> visitorCollection
        {
            get
            {
                return _visitorCollection;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<VisitorInformation> visitors = SecurityManagementSystemStorageInteraction.GetAllVisitorList();

            _visitorCollection.Clear();

            foreach (VisitorInformation visitor in visitors)
            {
                _visitorCollection.Add(visitor);
            }



            List<ResidenceInformation> Residences = SecurityManagementSystemStorageInteraction.GetAllResidenceList();

            _allresidenceCollection.Clear();

            foreach (ResidenceInformation residence in Residences)
            {
                _allresidenceCollection.Add(residence);
            }


            List<EmployeeInformation> Employees = SecurityManagementSystemStorageInteraction.GetAllEmployeeList();

            _allemployeeCollection.Clear();

            foreach (EmployeeInformation employee in Employees)
            {
                _allemployeeCollection.Add(employee);
            }
        }




        ObservableCollection<ResidenceInformation> _allresidenceCollection = new ObservableCollection<ResidenceInformation>();


        public ObservableCollection<ResidenceInformation> allresidenceCollection
        {
            get
            {
                return _allresidenceCollection;
            }
        }



        ObservableCollection<EmployeeInformation> _allemployeeCollection = new ObservableCollection<EmployeeInformation>();


        public ObservableCollection<EmployeeInformation> allemployeeCollection
        {
            get
            {
                return _allemployeeCollection;
            }
        }

        private void visitorNameCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentVisitorId = (e.AddedItems[0] as VisitorInformation).id;
            PopulateItemsFromVisitorReg(currentVisitorId);
        }
        private void allowbyCBCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentEmployeeId = (e.AddedItems[0] as EmployeeInformation).id;
            PopulateItemsFromEmployeeReg(currentEmployeeId);
        }

        private void PopulateItemsFromVisitorReg(string visitorId)
        {
            VisitorInformation visitorinfo = SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.GetVisitorInfo(visitorId);

            visitorAddressNameTxtbox.Text = visitorinfo.name;
            idproofwithNoTxtbox.Text = visitorinfo.idinfo;


            //EmployeeInformation employeeinfo = SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.GetEmployeeInfo(visitorinfo.id);

            //employeeIdTxtbox.Text = employeeinfo.id;
            
        }

        private void PopulateItemsFromEmployeeReg(string employeeId)
        {
            EmployeeInformation employeeinfo = SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.GetEmployeeInfo(employeeId);

            employeeIdTxtbox.Text = employeeinfo.id;

        }
       
    }
}
