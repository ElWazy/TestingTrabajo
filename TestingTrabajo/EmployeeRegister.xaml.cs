using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TestingTrabajo.Models;
using TestingTrabajo.Persistence;

namespace TestingTrabajo
{
    /// <summary>
    /// Lógica de interacción para UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Window
    {
        ProfileRepository profileRepo;
        EmployeeRepository employeeRepo;

        public UserRegister()
        {
            InitializeComponent();
            string url = "datasource=localhost;port=3306;username=root;password=;database=testing_work";

            profileRepo = new MariaDBProfileRepository(url);
            employeeRepo = new MariaDBEmployeeRepository(url);

            List<Profile> profiles = profileRepo.GetAll();
            
            foreach (Profile profile in profiles)
            {
                cbxProfiles.Items.Add(profile.GetName());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(Profile.GenerateUUID(), txtProfile.Text);
            profileRepo.Save(profile);

            CleanForms();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = profileRepo.GetByName(
                    cbxProfiles.SelectedItem.ToString()
                );

            Employee employee = new Employee(
                    Employee.GenerateUUID(),
                    txtRut.Text,
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtEmail.Text,
                    Employee.GeneratePassword(txtPassword.Text),
                    txtBirthDate.Text,
                    int.Parse(txtSalary.Text),
                    profile.GetUuid()
                );

            employeeRepo.Register(employee);

            CleanForms();
        }
        
        private void CleanForms()
        {
            txtRut.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtBirthDate.Text = "";
            txtSalary.Text = "";
            txtProfile.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
