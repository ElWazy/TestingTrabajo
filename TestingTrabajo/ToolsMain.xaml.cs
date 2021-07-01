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
    /// Lógica de interacción para ToolsMain.xaml
    /// </summary>
    public partial class ToolsMain : Window
    {
        CategoryRepository categoryRepo;
        ToolRepository toolRepo;

        public ToolsMain()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            string url = "datasource=localhost;port=3306;username=root;password=;database=testing_work";

            categoryRepo = new MariaDBCategoryRepository(url);
            toolRepo = new MariaDBToolRepository(url);

            LoadCategoryCombo();
            LoadToolTable();
        }

        private void LoadToolTable()
        {
            List<Tool> tools = toolRepo.GetAll();

            // Aquí se deberia llenar la tabla con los datos traidos de la db
        }

        private void LoadCategoryCombo()
        {
            List<Category> categories = categoryRepo.GetAll();

            cboCat.Items.Clear();
            cboCatTool.Items.Clear();
            foreach (Category category in categories)
            {
                cboCat.Items.Add(category.Name);
                cboCatTool.Items.Add(category.Name);
            }
        }

        private void CleanTextBoxs()
        {
            txtNameTool.Text  = "";
            txtNombreCat.Text = "";
            txtStock.Text     = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //UserRegister register = new UserRegister();
            //register.Show();

            //this.Close();
        }

        private void btnAddCat_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category(
                    Category.GenerateUUID(),
                    txtNombreCat.Text
                );

            categoryRepo.Save(category);

            CleanTextBoxs();
            LoadCategoryCombo();
        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {

            Category category = categoryRepo.GetByName(cboCatTool.SelectedItem.ToString());

            Tool tool = new Tool(
                    Tool.GenerateUUID(),
                    txtNameTool.Text,
                    category.UUID,
                    int.Parse(txtStock.Text),
                    int.Parse(txtStock.Text)
                );

            toolRepo.Add(tool);

            CleanTextBoxs();
            LoadToolTable();
        }
    }
}
