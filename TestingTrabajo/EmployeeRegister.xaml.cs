using System;
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
using System.Windows.Shapes;
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
                Console.WriteLine(profile);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(Profile.GenerateUUID(), txtProfile.Text);
            profileRepo.Save(profile);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
