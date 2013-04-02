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
    /// Interaction logic for Workorder.xaml
    /// </summary>
    public partial class Workorder : UserControl
    {
        public Workorder()
        {
            InitializeComponent();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

            fetchWorkData();
        }

        private void GetOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystemEngine.WorkOrderInformation newWorkOrder = new SecurityManagementSystemEngine.WorkOrderInformation();

            newWorkOrder.id = GenerateId();

            newWorkOrder.orderBy = orderByCB.Text;
            newWorkOrder.workDetails = workDetailsTxtbox.Text;
            newWorkOrder.assignTo = assignToCB.Text;
            newWorkOrder.orderdate = orderdatedateP.SelectedDate.Value;
            newWorkOrder.roomNo = roomNoTxtbox.Text;

            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DoEnterWorkOrder(newWorkOrder);
            workorderTC.SelectedIndex = 0;
            

        }


        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }




        ObservableCollection<WorkOrderInformation> _allworkCollection = new ObservableCollection<WorkOrderInformation>();


        public ObservableCollection<WorkOrderInformation> allworkCollection
        {
            get
            {
                return _allworkCollection;
            }
        }

        private void fetchWorkData()
        {
            List<WorkOrderInformation> WorkOrders = SecurityManagementSystemStorageInteraction.GetAllWorkOrderList();

            _allworkCollection.Clear();

            foreach (WorkOrderInformation WorkOrder in WorkOrders)
            {
                _allworkCollection.Add(WorkOrder);
            }
        }


        private WorkOrderInformation GetSelectedContactItem()
        {

            WorkOrderInformation workOrderToDelete = null;

            if (orderView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                WorkOrderInformation i = (WorkOrderInformation)orderView.SelectedItem;

                workOrderToDelete = _allworkCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return workOrderToDelete;
        }
        private void deleteWorkOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            WorkOrderInformation workOrderToDelete = GetSelectedContactItem();
            if (workOrderToDelete != null)
            {
                _allworkCollection.Remove(workOrderToDelete);
                SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DeleteWorkOrder(workOrderToDelete.id);
                fetchWorkData();

            }
        }

        
    }
}
