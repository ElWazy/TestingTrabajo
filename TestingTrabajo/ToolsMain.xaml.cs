using System;
using System.Collections.Generic;
using System.Windows;
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
            List<FormatedTool> formatedTools = new List<FormatedTool>();

            foreach (Tool tool in tools)
            {
                Category category = categoryRepo.GetByUUID(tool.Category_id_fk);

                formatedTools.Add(
                        new FormatedTool(
                                tools.IndexOf(tool),
                                tool.Name,
                                category.Name,
                                tool.Stock,
                                tool.Real_stock
                            )
                    );
            }

            gridTools.ItemsSource = formatedTools;
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

        /**
         * Comentar a la hora de la exposicion
         */ 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserRegister register = new UserRegister();
            register.Show();

            this.Close();
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
            LoadToolTable();
        }

        private void btnUpdateCat_Click(object sender, RoutedEventArgs e)
        {
            Category oldCategory = categoryRepo.GetByName(
                    cboCat.SelectedItem.ToString()
                );

            Category category = new Category(
                    oldCategory.UUID,
                    txtNombreCat.Text
                );

            categoryRepo.Update(category);

            CleanTextBoxs();
            LoadCategoryCombo();
            LoadToolTable();
        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {

            Category category = categoryRepo.GetByName(cboCatTool.SelectedItem.ToString());
            try
            {
                Tool tool = new Tool(
                        Tool.GenerateUUID(),
                        txtNameTool.Text,
                        category.UUID,
                        int.Parse(txtStock.Text),
                        int.Parse(txtStock.Text)
                    );

                toolRepo.Add(tool);
            }
            catch (FormatException)
            {
                MessageBox.Show("El stock debe ser numerico");
            }

            CleanTextBoxs();
            LoadToolTable();
        }

   

        private void b1SetColor(object DatagridCell, RoutedEventArgs e)
        {
            MessageBox.Show("a");

        }

    }

























    internal class FormatedTool
    {
        private int id;
        private string name;
        private string category;
        private int stock;
        private int realStock;

        public FormatedTool(int id, string name, string category, int stock, int realStock)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.stock = stock;
            this.realStock = realStock;
        }



        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public int RealStock
        {
            get { return realStock; }
            set { realStock = value; }
        }

    }
}
