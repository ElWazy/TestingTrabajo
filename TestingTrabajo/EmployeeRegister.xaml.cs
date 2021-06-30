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

        public UserRegister()
        {
            InitializeComponent();
            string url = "datasource=localhost;port=3306;username=root;password=;database=testing_work";

            profileRepo = new MariaDBProfileRepository(url);

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

            txtProfile.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
