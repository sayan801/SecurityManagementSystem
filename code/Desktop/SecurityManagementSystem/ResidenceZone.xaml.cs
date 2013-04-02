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
    /// Interaction logic for ResidenceZone.xaml
    /// </summary>
    public partial class ResidenceZone : UserControl
    {
        public ResidenceZone()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchResidenceData();
        }

        private void doregBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystemEngine.ResidenceInformation newResidence = new SecurityManagementSystemEngine.ResidenceInformation();

            newResidence.id = GenerateId();

            newResidence.name = headsNameTxtbox.Text;
            newResidence.houseNo = houseNoNameTxtbox.Text;
            newResidence.roomNo = roomNoTxtbox.Text;
            newResidence.contact = contactTxtbox.Text;
            newResidence.email = emailTxtbox.Text;
            newResidence.fmlyMbrs = fmlyMbrsTxtbox.Text;
            newResidence.visitingHour = visitingHourTxtbox.Text;
            newResidence.remark = remarkTxtbox.Text;

            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DoEnterResidence(newResidence);
        }
        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }



        ObservableCollection<ResidenceInformation> _allresidenceCollection = new ObservableCollection<ResidenceInformation>();


        public ObservableCollection<ResidenceInformation> allresidenceCollection
        {
            get
            {
                return _allresidenceCollection;
            }
        }

        private void fetchResidenceData()
        {
            List<ResidenceInformation> Residences = SecurityManagementSystemStorageInteraction.GetAllResidenceList();

            _allresidenceCollection.Clear();

            foreach (ResidenceInformation residence in Residences)
            {
                _allresidenceCollection.Add(residence);
            }
        }



        private ResidenceInformation GetSelectedContactItem()
        {

            ResidenceInformation residenceToDelete = null;

            if (residenceView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                ResidenceInformation i = (ResidenceInformation)residenceView.SelectedItem;

                residenceToDelete = _allresidenceCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return residenceToDelete;
        }
        private void deleteResidenceBtn_Click(object sender, RoutedEventArgs e)
        {
            ResidenceInformation residenceToDelete = GetSelectedContactItem();
            if (residenceToDelete != null)
            {
                _allresidenceCollection.Remove(residenceToDelete);
                SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DeleteResidence(residenceToDelete.id);
                fetchResidenceData();

            }
        }

    }
}
