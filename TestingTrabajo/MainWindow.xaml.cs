﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestingTrabajo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void ChangeWindow(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                DragMove();

            }
        }



        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.Foreground = Brushes.White;
                txtPass.Opacity = 1;

            }
            
        }

        private void logInCorrect(object sender, RoutedEventArgs e)
        {


            ToolsMain tools = new ToolsMain();

            
            tools.Show();
            this.Close();



        }

        private void txtMail_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (txtMail.Text == "Correo Electronico")
            {
                txtMail.Text = "";
                txtMail.Foreground = Brushes.White;
                txtMail.Opacity = 1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserRegister register = new UserRegister();
            register.Show();

            this.Close();
        }
    }
}
