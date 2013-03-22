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

namespace SecurityManagementSystem
{
    /// <summary>
    /// Interaction logic for VideoSurveillanceControl.xaml
    /// </summary>
    public partial class VideoSurveillanceControl : UserControl
    {
        public VideoSurveillanceControl()
        {
            InitializeComponent();
            IsPlaying(false);
        }
        private void btnRec_Click(object sender, RoutedEventArgs e)
        {

        }
        #region IsPlaying(bool)
        private void IsPlaying(bool bValue)
        {
            btnStop.IsEnabled = bValue;
            btnMoveBackward.IsEnabled = bValue;
            btnMoveForward.IsEnabled = bValue;
            btnPlay.IsEnabled = bValue;
        }
        #endregion

        #region Play and Pause
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            IsPlaying(true);
            if (btnPlay.Content.ToString() == "Play")
            {
                MediaEL.Play();
                btnPlay.Content = "Pause";
            }
            else
            {
                MediaEL.Pause();
                btnPlay.Content = "Play";
            }
        }
        #endregion

        #region Stop
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MediaEL.Stop();
            btnPlay.Content = "Play";
            IsPlaying(false);
            btnPlay.IsEnabled = true;
        }
        #endregion

        #region Back and Forward
        private void btnMoveForward_Click(object sender, RoutedEventArgs e)
        {
            MediaEL.Position = MediaEL.Position + TimeSpan.FromSeconds(10);
        }

        private void btnMoveBackward_Click(object sender, RoutedEventArgs e)
        {
            MediaEL.Position = MediaEL.Position - TimeSpan.FromSeconds(10);
        }
        #endregion

        #region Open Media
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Video Files (*.wmv)|*.wmv";
            if (ofd.ShowDialog() == true)
            {
                MediaEL.Source = new Uri(ofd.FileName);
                btnPlay.IsEnabled = true;
            }
        }
        #endregion

        private void btnOpen_Click_1(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
