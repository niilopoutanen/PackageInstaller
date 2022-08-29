﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFinstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager filemanager = new FileManager();
        public MainWindow()
        {
            InitializeComponent();
            InstallPanel.Visibility = Visibility.Hidden;
            InstallDonePanel.Visibility = Visibility.Hidden;
            InstallDonePanel.Margin = new Thickness(0, 0, 0, 0);
            SameVersionPanel.Visibility = Visibility.Hidden;
            SameVersionPanel.Margin = new Thickness(0, 0, 0, 0);
            OlderVersionPanel.Visibility = Visibility.Hidden;
            OlderVersionPanel.Margin = new Thickness(0, 0, 0, 0);
            UninstallPanel.Visibility = Visibility.Hidden;
            UninstallPanel.Margin = new Thickness(0, 0, 0, 0);

            bool IsAppInstalled = filemanager.IsAppInstalled();
            if (IsAppInstalled == true)
            {
                UninstallPanel.Visibility = Visibility.Visible;
            }
            else if (IsAppInstalled == false)
            {
                InstallPanel.Visibility = Visibility.Visible;
            }
        }


        private async void InstallApp()
        {
            Storyboard sb = (this.FindResource("InstallButtonAnim") as Storyboard).Clone();
            Storyboard.SetTarget(sb, InstallButton);
            sb.Begin();
            await Task.Delay(500);

            InstallPanel.Visibility = Visibility.Hidden;
            InstallDonePanel.Visibility = Visibility.Visible;
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizeApp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void OpenLink(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/niilopoutanen") { UseShellExecute = true });
        }
        private void InstallButton_Click(object sender, MouseButtonEventArgs e)
        {
            InstallApp();
        }
    }
}
