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

        private void addResidenceBtn_Click(object sender, RoutedEventArgs e)
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

            residenceMainTC.SelectedIndex = 0;
            clearResidenceFields();
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



        private ResidenceInformation GetSelectedResidenceItem()
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
            ResidenceInformation residenceToDelete = GetSelectedResidenceItem();
            if (residenceToDelete != null)
            {
                _allresidenceCollection.Remove(residenceToDelete);
                SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DeleteResidence(residenceToDelete.id);
                fetchResidenceData();

            }
        }


        private void clearResidenceFields()
        {
            headsNameTxtbox.Text = houseNoNameTxtbox.Text = roomNoTxtbox.Text = contactTxtbox.Text = emailTxtbox.Text = fmlyMbrsTxtbox.Text = visitingHourTxtbox.Text = remarkTxtbox.Text = "";
        }

        private void resetResidenceBtn_Click(object sender, RoutedEventArgs e)
        {
            clearResidenceFields();
        }

        private void editResidenceBtn_Click(object sender, RoutedEventArgs e)
        {
            ResidenceInformation residenceToEdit = GetSelectedResidenceItem();
            if (residenceToEdit != null)
            {
                residenceMainTC.SelectedIndex = 1;
                addResidenceBtn.Visibility = Visibility.Collapsed;
                updateResidenceBtn.Visibility = Visibility.Visible;

                headsNameTxtbox.Text = residenceToEdit.name;
                houseNoNameTxtbox.Text = residenceToEdit.houseNo;
                roomNoTxtbox.Text = residenceToEdit.roomNo;
                contactTxtbox.Text = residenceToEdit.contact;
                emailTxtbox.Text = residenceToEdit.email;
                fmlyMbrsTxtbox.Text = residenceToEdit.fmlyMbrs;
                visitingHourTxtbox.Text = residenceToEdit.visitingHour;
                remarkTxtbox.Text = residenceToEdit.remark;

            }
        }

        private void updateResidenceBtn_Click(object sender, RoutedEventArgs e)
        {
            ResidenceInformation residenceToEdit = GetSelectedResidenceItem();

            
            residenceToEdit.name = headsNameTxtbox.Text;
            residenceToEdit.houseNo = houseNoNameTxtbox.Text;
            residenceToEdit.roomNo = roomNoTxtbox.Text;
            residenceToEdit.contact = contactTxtbox.Text;
            residenceToEdit.email = emailTxtbox.Text;
            residenceToEdit.fmlyMbrs = fmlyMbrsTxtbox.Text;
            residenceToEdit.visitingHour = visitingHourTxtbox.Text;
            residenceToEdit.remark = remarkTxtbox.Text;


            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.EditResidence(residenceToEdit);
            residenceMainTC.SelectedIndex = 0;
            clearResidenceFields();
            updateResidenceBtn.Visibility = Visibility.Collapsed;
            addResidenceBtn.Visibility = Visibility.Visible;
        }

    }
}
