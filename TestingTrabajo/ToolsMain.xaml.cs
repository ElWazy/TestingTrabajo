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

namespace TestingTrabajo
{
    /// <summary>
    /// Lógica de interacción para ToolsMain.xaml
    /// </summary>
    public partial class ToolsMain : Window
    {
        public ToolsMain()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();


        }

        

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnAddCat_Click(object sender, RoutedEventArgs e)
        {
            String newCategory = txtNombreCat.Text;
            cboCat.Items.Add(newCategory);
            txtNombreCat.Text = "";
        }


    }
}
