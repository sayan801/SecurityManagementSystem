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
    /// Interaction logic for SecurityZone.xaml
    /// </summary>
    public partial class SecurityGuardZone : UserControl
    {
        public SecurityGuardZone()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchSecurityData();
        }
        private void doregBtn_Click(object sender, RoutedEventArgs e)
        {

            SecurityManagementSystemEngine.SecurityInformation newSecurity = new SecurityManagementSystemEngine.SecurityInformation();

            newSecurity.id = GenerateId();

            newSecurity.name = securityNameTxtbox.Text;
            newSecurity.addres = AddressNameTxtbox.Text;
            newSecurity.contact = contactTxtbox.Text;
            newSecurity.email = emailTxtbox.Text;
            newSecurity.homeNumber = homeNumberTxtbox.Text;
            newSecurity.joiningdate = joiningdateP.SelectedDate.Value;
            newSecurity.remark = remarkTxtbox.Text;

            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DoEnterSecurity(newSecurity);


        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }




        ObservableCollection<SecurityInformation> _allsecurityCollection = new ObservableCollection<SecurityInformation>();


        public ObservableCollection<SecurityInformation> allsecurityCollection
        {
            get
            {
                return _allsecurityCollection;
            }
        }

        private void fetchSecurityData()
        {
            List<SecurityInformation> Securitys = SecurityManagementSystemStorageInteraction.GetAllSecurityList();

            _allsecurityCollection.Clear();

            foreach (SecurityInformation security in Securitys)
            {
                _allsecurityCollection.Add(security);
            }
        }



    }
}
