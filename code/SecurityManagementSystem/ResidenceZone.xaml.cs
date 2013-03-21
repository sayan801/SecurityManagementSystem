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
    /// Interaction logic for ResidenceZone.xaml
    /// </summary>
    public partial class ResidenceZone : UserControl
    {
        public ResidenceZone()
        {
            InitializeComponent();
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

            SecurityManagementSystemStorage.SecurityManagementSystemStorage.DoEnterResidence(newResidence);
        }
        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
