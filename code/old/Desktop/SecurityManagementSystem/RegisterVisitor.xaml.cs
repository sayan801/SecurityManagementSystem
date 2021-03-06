﻿using System;
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
    /// Interaction logic for RegisterVisitor.xaml
    /// </summary>
    public partial class RegisterVisitor : UserControl
    {
        public RegisterVisitor()
        {
            InitializeComponent();
        }

        private void doregBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityManagementSystemEngine.VisitorInformation newVisitor = new SecurityManagementSystemEngine.VisitorInformation();

            newVisitor.id = GenerateId();

            newVisitor.name = visitorNameTxtbox.Text;
            newVisitor.addres = visitorAddressNameTxtbox.Text;
            newVisitor.contact = contactTxtbox.Text;
            newVisitor.idinfo = idproofwithNoTxtbox.Text;
            newVisitor.viitortype = VisitorTypeCombobox.Text;
            newVisitor.purpose = purposeTxtbox.Text;
            newVisitor.empId = toWhomTxtbox.Text;
            newVisitor.signintime = signinDp.SelectedDate.Value;
            newVisitor.remark = remarkTxtbox.Text;
            newVisitor.expcttie = etwtTxtbox.Text;

            SecurityManagementSystemStorage.SecurityManagementSystemStorageInteraction.DoEnterVisetor(newVisitor);

        
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void takePhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = System.Environment.CurrentDirectory + "\\TwoCamerasTest.exe";
            System.Diagnostics.Process.Start(filePath);
        }

        private void resetRegVisitorBtn_Click(object sender, RoutedEventArgs e)
        {
            visitorNameTxtbox.Text = visitorAddressNameTxtbox.Text = contactTxtbox.Text = idproofwithNoTxtbox.Text = purposeTxtbox.Text = toWhomTxtbox.Text = remarkTxtbox.Text = etwtTxtbox.Text = "";
            signinDp.SelectedDate = DateTime.Now;
            VisitorTypeCombobox.SelectedIndex = 1;
        }
        
    }
}
