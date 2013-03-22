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
        }


    }
}
