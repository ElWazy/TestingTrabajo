using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TestingTrabajo.Models;
using TestingTrabajo.Persistence;

namespace TestingTrabajo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeRepository employeeRepo;
        
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            string url = "datasource=localhost;port=3306;username=root;password=;database=testing_work";

            employeeRepo = new HarcodedEmployeeRepository();
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

            String email = txtMail.Text;

            String expresion;
            bool validateMail;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    validateMail = true;
                    Employee employee = employeeRepo.Login(
                            txtMail.Text,
                            pswbox.Password
                        );

                    if (employee != null)
                    {
                        tools.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no se encuentra en la bd.");
                    }


                }
                else
                {
                    validateMail = false;
                    Console.WriteLine(validateMail + " mail validator firstElse");
                    MessageBox.Show("Correo Invalido !");
                }
            }
            else
            {
                validateMail = false;
                Console.WriteLine(validateMail + " mail validator secondElse");
                MessageBox.Show("Correo Invalido !");
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
