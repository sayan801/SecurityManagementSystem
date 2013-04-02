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
    /// Interaction logic for ManageVisitors.xaml
    /// </summary>
    public partial class ManageVisitors : UserControl
    {
        public ManageVisitors()
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
            fetchVisitorData();
        }

        private void fetchVisitorData()
        {
            List<VisitorInformation> visitors = SecurityManagementSystemStorageInteraction.GetAllVisitorList();

            _visitorCollection.Clear();

            foreach (VisitorInformation visitor in visitors)
            {
                _visitorCollection.Add(visitor);
            }
        }




        private VisitorInformation GetSelectedContactItem()
        {

            VisitorInformation visitorToDelete = null;

            if (visitorView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                VisitorInformation i = (VisitorInformation)visitorView.SelectedItem;

                visitorToDelete = _visitorCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return visitorToDelete;
        }
        private void deleteVisitorBtn_Click(object sender, RoutedEventArgs e)
        {
            VisitorInformation visitorToDelete = GetSelectedContactItem();
            if (visitorToDelete != null)
            {
                _visitorCollection.Remove(visitorToDelete);
                SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DeleteVisitor(visitorToDelete.id);
                fetchVisitorData();

            }
        }
    }
}
