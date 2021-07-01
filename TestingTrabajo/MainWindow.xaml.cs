using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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



        private void logInCorrect(object sender, RoutedEventArgs e)
        {


            ToolsMain tools = new ToolsMain();

            String pass = pswbox.Password;
            String email = txtMail.Text;
            String expresion;
            bool validateMail;
            bool validatePass = false;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    validateMail = true;
                }  
                else
                {
                    validateMail = false;
                    Console.WriteLine(validateMail + " mail validator firstElse");
                }
            }
            else
            {
                validateMail = false;
                Console.WriteLine(validateMail + " mail validator secondElse");
            }

            if (pass.Length != 0)
            {
                validatePass = true;
            }
            else
            {

            }

            if (validateMail == true && validatePass == true)
            {
                tools.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña erroneos");
            }



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

 


        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPass.Text.Length != 0)
            {
                txtPass.IsEnabled = false;
                txtPass.Opacity = 1;
                txtPass.Visibility = Visibility.Collapsed;
                pswbox.Focus();

            }
        }
    }
}
